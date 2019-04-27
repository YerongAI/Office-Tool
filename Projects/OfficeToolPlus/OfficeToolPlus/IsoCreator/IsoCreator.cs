using System;
using System.IO;
using System.Collections;
using OTP.Export;
using ISO9660.Enums;
using IsoCreator.DirectoryTree;
using IsoCreator.IsoWrappers;

namespace IsoCreator
{
    public class IsoCreator {

		#region Iso Creator Args Class

		/// <summary>
		/// Used for sending parameters to ParameterizedThreadStart delegate function.
		/// Contains the natural arguments for Folder2Iso function.
		/// </summary>
		public class IsoCreatorFolderArgs {
            #region Properties

            public string FolderPath { get; }

            public string IsoPath { get; }

            public string VolumeName { get; }

            #endregion

            #region Constructors

            public IsoCreatorFolderArgs( string folderPath, string isoPath, string volumeName ) {
				FolderPath = folderPath;
				IsoPath = isoPath;
				VolumeName = volumeName;
			}

			#endregion
		}

		/// <summary>
		/// Used for sending parameters to ParameterizedThreadStart delegate function.
		/// Contains the natural arguments for Folder2Iso function.
		/// </summary>

		#endregion

		#region Writing Methods

		#region Helper Methods (SetDirectoryNumbers(dirArray))

		/// <summary>
		/// Sets the directory numbers according to the ISO 9660 standard, so that Path Tables could be built. (root=1, first child=2, etc.)
		/// The order of the directories is as following:
		/// 1. If two directories are on different levels, then the one on the lowest level comes first;
		/// 2. If the directories are on the same level, but have different parents, then they are ordered in the same order as their parents.
		/// 3. If the directories have the same parent, then they are sorted according to their name (lexicographic).
		/// </summary>
		/// <param name="dirArray">An array of SORTED IsoDirectories according to the ISO 9660 standard.</param>
		private void SetDirectoryNumbers( IsoDirectory[] dirArray ) {
			if ( dirArray == null ) {
				return;
			}
			for ( int i=0; i<dirArray.Length; i++ ) {
				( (IsoDirectory)dirArray[i] ).Number = (ushort)( i+1 );
			}
		}

		#endregion

		/// <summary>
		/// Writes the first 16 empty sectors of an ISO image.
		/// </summary>
		/// <param name="writer">A binary writer to write the data.</param>
		private void WriteFirst16EmptySectors( BinaryWriter writer ) {
			for ( int i=0; i<16; i++ ) {
				writer.Write( new byte[IsoAlgorithm.SectorSize] );
			}
		}

		/// <summary>
		/// Writes three volume descriptors speciffic to the ISO 9660 Joliet:
		/// 1. Primary volume descriptor;
		/// 2. Suplementary volume descriptor;
		/// 3. Volume descriptor set terminator.
		/// </summary>
		/// <param name="writer">A binary writer to write the data.</param>
		/// <param name="volumeName">A normal string representing the desired name of the volume. 
		/// (the maximum standard length for this string is 16 for Joliet, so if the name is larger 
		/// than 16 characters, it is truncated.)</param>
		/// <param name="root">The root IsoDirectory, representing the root directory for the volume.</param>
		/// <param name="volumeSpaceSize">The ISO total space size IN SECTORS. 
		/// (For example, if the ISO space size is 1,427,456 bytes, then the volumeSpaceSize will be 697)</param>
		/// <param name="pathTableSize1">The first path table size (for the primary volume) IN BYTES.</param>
		/// <param name="pathTableSize2">The second path table size (for the suplementary volume) IN BYTES.</param>
		/// <param name="typeLPathTable1">The location (sector) of the first LITTLE ENDIAN path table.</param>
		/// <param name="typeMPathTable1">The location (sector) of the first BIG ENDIAN path table.</param>
		/// <param name="typeLPathTable2">The location (sector) of the second LITTLE ENDIAN path table.</param>
		/// <param name="typeMPathTable2">The location (sector) of the second BIG ENDIAN path table.</param>
		private void WriteVolumeDescriptors( BinaryWriter writer,
											 string volumeName,
											 IsoDirectory root,
                                             uint volumeSpaceSize,
                                             uint pathTableSize1, uint pathTableSize2,
                                             uint typeLPathTable1, uint typeMPathTable1,
                                             uint typeLPathTable2, uint typeMPathTable2 ) {

			// Throughout this program I have respected the convention of refering to the root as "."; 
			// However, one should not confuse the root with the current directory, also known as "." (along with the parent directory, "..").

			// Primary Volume Descriptor:

			// Create a Directory Record of the root and the volume descriptor.
			DirectoryRecordWrapper rootRecord = new DirectoryRecordWrapper( root.Extent1, root.Size1, root.Date, root.IsDirectory, "." );
            VolumeDescriptorWrapper volumeDescriptor = new VolumeDescriptorWrapper(volumeName, volumeSpaceSize, pathTableSize1, typeLPathTable1, typeMPathTable1, rootRecord, DateTime.Now, DateTime.Now, 8)
            {
                VolumeDescriptorType = VolumeType.Primary
            };
            volumeDescriptor.Write( writer );

			// Suplementary volume descriptor:

			rootRecord = new DirectoryRecordWrapper( root.Extent2, root.Size2, root.Date, root.IsDirectory, "." );
            volumeDescriptor = new VolumeDescriptorWrapper(volumeName, volumeSpaceSize, pathTableSize2, typeLPathTable2, typeMPathTable2, rootRecord, DateTime.Now, DateTime.Now, 8)
            {
                VolumeDescriptorType = VolumeType.Suplementary
            };
            volumeDescriptor.Write( writer );

			// Volume descriptor set terminator:

			volumeDescriptor.VolumeDescriptorType = VolumeType.SetTerminator;
			volumeDescriptor.Write( writer );
		}

		/// <summary>
		/// Writes the containings of each directory
		/// </summary>
		/// <param name="writer">A binary writer to write the data.</param>
		/// <param name="dirArray">An array of IsoDirectories to be written.</param>
		/// <param name="type">The type of writing to be performed:
		/// Primary - corresponding to the Primary Volume Descriptor (DOS Speciffic - 8 letter ASCII upper case names)
		/// Suplementary - corresponding to the Suplementary Volume Descriptor (Windows speciffic - 101 letter Unicode names)</param>
		private void WriteDirectories( BinaryWriter writer, IsoDirectory[] dirArray, VolumeType type ) {
			if ( dirArray == null ) {
				return;
			}
			for ( int i=0; i<dirArray.Length; i++ ) {
				dirArray[i].Write(writer, type);
                OnProgress( (int)(writer.BaseStream.Length/IsoAlgorithm.SectorSize) );
			}
		}

		/// <summary>
		/// Writes a path table corresponding to a given directory structure.
		/// The order of the directories is as following (ISO 9660 standard):
		/// 1. If two directories are on different levels, then the one on the lowest level comes first;
		/// 2. If the directories are on the same level, but have different parents, then they are ordered in the same order as their parents.
		/// 3. If the directories have the same parent, then they are sorted according to their name (lexicographic).
		/// </summary>
		/// <param name="writer">A binary writer to write the data.</param>
		/// <param name="dirArray">An array of IsoDirectories representing the directory structure.</param>
		/// <param name="endian">The byte order of numbers (little endian or big endian).</param>
		/// <param name="type">The type of writing to be performed:
		/// Primary - corresponding to the Primary Volume Descriptor (DOS Speciffic - 8 letter ASCII upper case names)
		/// Suplementary - corresponding to the Suplementary Volume Descriptor (Windows speciffic - 101 letter Unicode names)</param>
		/// <returns>An integer representing the total number of bytes written.</returns>
		private int WritePathTable( BinaryWriter writer, IsoDirectory[] dirArray, Endian endian, VolumeType type ) {
			if ( dirArray == null ) {
				return 0;
			}

			int bytesWritten = 0;
			for ( int i=0; i<dirArray.Length; i++ ) {
				// The directory list is sorted according to the ISO 9660 standard, so the first one (0) should be the root.
				bytesWritten += dirArray[i].WritePathTable( writer, ( i==0 ), endian, type );
			}

			// A directory must ocupy a number of bytes multiple of 2048 (the sector size).
			writer.Write( new byte[IsoAlgorithm.SectorSize - ( bytesWritten%IsoAlgorithm.SectorSize )] );

			return bytesWritten;
		}

		#endregion

		#region Folder to ISO

		/// <summary>
		/// Writes an ISO with the contains of the folder given as a parameter.
		/// </summary>
		/// <param name="rootDirectoryInfo">The folder to be turned into an iso.</param>
		/// <param name="writer">A binary writer to write the data.</param>
		/// <param name="volumeName">The name of the volume created.</param>
		private void Folder2Iso( DirectoryInfo rootDirectoryInfo, BinaryWriter writer, string volumeName ) {

			ArrayList dirList;
			IsoDirectory[] dirArray;

            OnProgress( "Initializing ISO root directory...", 0, 1 );

			IsoDirectory root = new IsoDirectory( rootDirectoryInfo, 1, "0", Progress );

            //
            // Folder structure and path tables corresponding to the Primary Volume Descriptor:
            //

            OnProgress( "Preparing first set of directory extents...", 0, 1 );

            dirList = new ArrayList
            {
                root
            };

            // Set all extents corresponding to the primary volume descriptor;
            // Memorize the SORTED directories in the dirList list.
            // The first extent (corresponding to the root) should be at the 19th sector 
            // (which is the first available sector: 0-15 are empty and the next 3 (16-18) 
            // are occupied by the volume descriptors).
            IsoDirectory.SetExtent1( dirList, 0, 19 );

            OnProgress( 1 );

            OnProgress( "Calculating directory numbers...", 0, 1 );

			dirArray = new IsoDirectory[dirList.Count];
			dirList.ToArray().CopyTo( dirArray, 0 );        // Copy to an array the sorted directory list.

            SetDirectoryNumbers( dirArray );            // Set the directory numbers, used in the path tables.

            OnProgress( 1 );

            OnProgress( "Preparing first set of path tables...", 0, 2 );

			// Create a memory stream where to temporarily save the path tables. 
			// (We can't write them directly to the file, because we first have to write - by convention - 
			// the directories. For now, we cannot do that, since we don't know the files' extents.
			// Those will be calculated later, when we know the actual size of the path tables, because
			// the files come at the end of the file, after the path tables.)
			// I used this algorihm, although a little backword, since this is the algorithm NERO uses,
			// and I gave them credit for choosing the best one ;)
			MemoryStream memory1 = new MemoryStream();
			BinaryWriter memoryWriter1 = new BinaryWriter( memory1 );

			// Calculate the position of the first little endian path table, which comes right after the last directory.
			IsoDirectory lastDir = dirArray[dirArray.Length-1];
            uint typeLPathTable1 = lastDir.Extent1 + lastDir.Size1/IsoAlgorithm.SectorSize;

            WritePathTable( memoryWriter1, dirArray, Endian.LittleEndian, VolumeType.Primary );

            OnProgress( 1 );

            // Calculate the position of the first big endian path table.
            uint typeMPathTable1 = typeLPathTable1 + (uint)( memory1.Length )/IsoAlgorithm.SectorSize;

            uint pathTableSize1 = (uint)WritePathTable( memoryWriter1, dirArray, Endian.BigEndian, VolumeType.Primary );

            OnProgress( 2 );

            //
            // end
            //

            //
            // Folder structure and path tables corresponding to the Suplementary Volume Descriptor:
            //

            OnProgress( "Preparing second set of directory extents...", 0, 1 );

            dirList = new ArrayList
            {
                root
            };

            uint currentExtent = typeLPathTable1 + (uint)( memory1.Length )/IsoAlgorithm.SectorSize;

			IsoDirectory.SetExtent2( dirList, 0, currentExtent );

			dirArray = new IsoDirectory[dirList.Count];
			dirList.ToArray().CopyTo( dirArray, 0 );

            OnProgress( 1 );

            OnProgress( "Preparing second set of path tables...", 0, 2 );

			MemoryStream memory2 = new MemoryStream();
			BinaryWriter memoryWriter2 = new BinaryWriter( memory2 );

			lastDir = dirArray[dirArray.Length-1];
            uint typeLPathTable2 = lastDir.Extent2 + lastDir.Size2/IsoAlgorithm.SectorSize;

            WritePathTable( memoryWriter2, dirArray, Endian.LittleEndian, VolumeType.Suplementary );

            OnProgress( 1 );

            uint typeMPathTable2 = typeLPathTable2 + (uint)( memory2.Length )/IsoAlgorithm.SectorSize;

            uint pathTableSize2 = (uint)WritePathTable( memoryWriter2, dirArray, Endian.BigEndian, VolumeType.Suplementary );

            OnProgress( 2 );

            //
            // end
            //

            OnProgress( "Initializing...", 0, 1 );

			// Now that we know the extents and sizes of all directories and path tables, 
			// all that remains is to calculate files extent:
			currentExtent = typeLPathTable2 + (uint)( memory2.Length )/IsoAlgorithm.SectorSize;
			root.SetFilesExtent( ref currentExtent );

            // Calculate the total size in sectors of the file to be made.
            uint volumeSpaceSize = 19;
			volumeSpaceSize += root.TotalSize;

//			volumeSpaceSize += root.TotalDirSize;

			volumeSpaceSize += (uint)memory1.Length / IsoAlgorithm.SectorSize;
			volumeSpaceSize += (uint)memory2.Length / IsoAlgorithm.SectorSize;

			// Prepare the buffers for the path tables.
			byte[] pathTableBuffer1 = memory1.GetBuffer();
			Array.Resize( ref pathTableBuffer1, (int)memory1.Length );

			byte[] pathTableBuffer2 = memory2.GetBuffer();
			Array.Resize( ref pathTableBuffer2, (int)memory2.Length );

			// Close the memory streams.
			memory1.Close();
			memory2.Close();
			memoryWriter1.Close();
			memoryWriter2.Close();

            OnProgress( 1 );

            //
            // Now all we have to do is to write all information to the ISO:
            //

            OnProgress( "Writing data to file...", 0, (int)volumeSpaceSize );

            // First, write the 16 empty sectors.
            WriteFirst16EmptySectors( writer );

            OnProgress( (int)(writer.BaseStream.Length/IsoAlgorithm.SectorSize) );

            // Write the three volume descriptors.
            WriteVolumeDescriptors(
				writer,	volumeName,	root,
				volumeSpaceSize,
				pathTableSize1, pathTableSize2,
				typeLPathTable1, typeMPathTable1,
				typeLPathTable2, typeMPathTable2 );

            OnProgress( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) );

            // Write the directories in a manner corresponding to the Primary Volume Descriptor.
            WriteDirectories( writer, dirArray, VolumeType.Primary );

			// Write the first two path tables.
			writer.Write( pathTableBuffer1 );

            OnProgress( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) );

            // Write the directories in a manner corresponding to the Suplementary Volume Descriptor.
            WriteDirectories( writer, dirArray, VolumeType.Suplementary );

			// Write the other two path tables.
			writer.Write( pathTableBuffer2 );

            OnProgress( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) );

			// Write the files.
			root.WriteFiles( writer, Progress );

			// That's it ;)
		}

		/// <summary>
		/// Writes an ISO with the contains of the folder given as a parameter.
		/// </summary>
		/// <param name="folderPath">The path of the folder to be turned into an iso.</param>
		/// <param name="isoPath">The path of the iso file.</param>
		/// <param name="volumeName">The name of the volume to be created.</param>
		public void Folder2Iso( string folderPath, string isoPath, string volumeName ) {
			try {
				FileStream isoFileStream = new FileStream( isoPath, FileMode.Create );
				BinaryWriter writer = new BinaryWriter( isoFileStream );
				DirectoryInfo rootDirectoryInfo = new DirectoryInfo( folderPath );
				try {
					Folder2Iso( rootDirectoryInfo, writer, volumeName );

					writer.Close();
					isoFileStream.Close();

                    OnFinished( "ISO writing process finished succesfully" );
				} catch ( Exception ex ) {
					writer.Close();
					isoFileStream.Close();
					throw ex;
				}
			} catch ( System.Threading.ThreadAbortException ex ) {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                OnAbort( "Aborted" );
			} catch ( Exception ex ) {
                OnAbort( ex.Message );
			}
		}

		/// <summary>
		/// Writes an ISO with the speciffications contained in the IsoCreatorArgs object given as parameter.
		/// </summary>
		/// <param name="data">An IsoCreatorFolderArgs object.</param>
		public void Folder2Iso( object data ) {
			if ( data.GetType() != typeof( IsoCreatorFolderArgs ) ) {
				return;
			}

			IsoCreatorFolderArgs args = (IsoCreatorFolderArgs)data;
            Folder2Iso( args.FolderPath, args.IsoPath, args.VolumeName );
		}

		#endregion

		#region Events

		public event ProgressDelegate Progress;

		public event FinishDelegate Finish;

		public event AbortDelegate Abort;

		private void OnFinished( string message ) {
            Finish?.Invoke(this, new FinishEventArgs(message));
        }

		private void OnProgress( int current ) {
            Progress?.Invoke(this, new ProgressEventArgs(current));
        }

        private void OnProgress( string action, int current, int maximum ) {
            Progress?.Invoke(this, new ProgressEventArgs(action, current, maximum));
        }

		private void OnAbort( string message ) {
            Abort?.Invoke(this, new AbortEventArgs(message));
        }

		#endregion
	}
}
