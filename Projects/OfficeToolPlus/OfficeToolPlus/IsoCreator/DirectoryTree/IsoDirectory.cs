using System.IO;
using System.Collections;
using OTP.Export;
using ISO9660.Enums;
using IsoCreator.IsoWrappers;

namespace IsoCreator.DirectoryTree
{

    /// <summary>
    /// The directory (folder element).
    /// </summary>
    internal class IsoDirectory : IsoFolderElement {

        #region Fields

											// The directory memorizes two sizes:
		private uint m_size1;				// The size in sectors occupied by all the short-ascii-named children.
		private uint m_size2;				// The size in sectors occupied by all the full-unicode-named children.

		private uint m_extent1;			// The number of the first sector occupied by the short-ascii-named directory.
		private uint m_extent2;         // The number of the first sector occupied by the full-unicode-named directory.
                                        // The children (that is the files and subfolders) of the directory.

        #endregion

        #region Constructors

        #region Real directories


        private void CalculateSize() {
			// Calculate the size of the current directory:
			m_size1 = 1;
			m_size2 = 1; // The size of the directory in sectors.

            uint position1 = (uint)2 * IsoAlgorithm.DefaultDirectoryRecordLength;
            uint position2 = (uint)2 * IsoAlgorithm.DefaultDirectoryRecordLength;

			foreach ( IsoFolderElement child in Children ) {
                uint size1;
				if ( child.IsDirectory ) {
					// A directory record of a sub-dir has the size equal to 33 + lengthOf(<sub-dir name>)
					size1 = (uint)( child.ShortName.Length + IsoAlgorithm.DefaultDirectoryRecordLength - 1 );
				} else {
					// A directory record of a file has the size equal to 
					// 33 + lengthOf(<file name>) + lengthOf(";1") - the standard suffix for file names in ISO9660
					size1 = (uint)( child.ShortName.Length+2 + IsoAlgorithm.DefaultDirectoryRecordLength - 1 );
				}
				if ( size1 % 2 == 1 ) {
					size1++;
				}

				// If a directory record is bigger than the space left in the sector, it will be written in a new sector.
				if ( position1 + size1 > IsoAlgorithm.SectorSize ) {
					// Increment the size of the current directory:
					m_size1++;
					position1 = size1;
				} else {
					position1 += size1;
				}

                uint size2;
				// The normal name length is multiplied by 2, since the names are memorized in unicode characters,
				// which ocupy 2 bytes instead of one.
				if ( child.IsDirectory ) {
					size2 = (uint)( 2 * child.LongName.Length + IsoAlgorithm.DefaultDirectoryRecordLength - 1 );
				} else {
					size2 = (uint)( 2 * ( child.LongName.Length+2 ) + IsoAlgorithm.DefaultDirectoryRecordLength - 1 );
				}
				if ( size2 % 2 == 1 ) {
					size2++;
				}

				if ( position2 + size2 > IsoAlgorithm.SectorSize ) {
					m_size2++;
					position2 = size2;
				} else {
					position2 += size2;
				}
			}
		}


		private void Initialize( DirectoryInfo directory, uint level, ProgressDelegate Progress ) {

			FileSystemInfo[] children = directory.GetFileSystemInfos();

			if ( children != null ) {
                Progress?.Invoke(this, new ProgressEventArgs(0, children.Length));
                int childNumberLength = children.Length.ToString().Length;
				for ( int i=0; i<children.Length; i++ ) {

					IsoFolderElement child;
					string childNumber = string.Format( "{0:D" + childNumberLength.ToString() + "}", i );
					if ( children[i].GetType() == typeof( DirectoryInfo ) ) {
						child = new IsoDirectory( this, (DirectoryInfo)children[i], level + 1, childNumber );
					} else {
						child = new IsoFile( (FileInfo)children[i], childNumber );
					}

					Children.Add( child );

                    Progress?.Invoke(this, new ProgressEventArgs(i));
                }
			}
			Children.Sort();

            CalculateSize();
		}

		// For ROOT !!
		public IsoDirectory( DirectoryInfo directory, uint level, string childNumber, ProgressDelegate Progress )
			: base( directory, true, childNumber ) {
			Parent = this;

            Initialize( directory, level, Progress );
		}

		public IsoDirectory( IsoDirectory parent, DirectoryInfo directory, uint level, string childNumber )
			: base( directory, false, childNumber ) {
			Parent = parent;

            Initialize( directory, level, null );
		}

		#endregion

		#endregion

		#region Properties

		/// <summary>
		/// Calculates the size of the current directory (including all subdirectories, but not files).
		/// </summary>
		public uint TotalDirSize {
			get {
                uint result = ( Size1 + Size2 ) / IsoAlgorithm.SectorSize;
				foreach ( IsoFolderElement child in Children ) {
					if ( child.IsDirectory ) {
						result += ( (IsoDirectory)child ).TotalDirSize;
					}
				}

				return result;
			}
		}

		/// <summary>
		/// Calculates the size of the current directory (including files and folders).
		/// </summary>
		public uint TotalSize {
			get {
                uint result = ( Size1 + Size2 )/IsoAlgorithm.SectorSize;
				foreach ( IsoFolderElement child in Children ) {
					if ( !child.IsDirectory ) {
						result += child.Size1/IsoAlgorithm.SectorSize;
						if ( child.Size1%IsoAlgorithm.SectorSize != 0 ) {
							result++;
						}
					} else {
						result += ( (IsoDirectory)child ).TotalSize;
					}
				}

				return result;
			}
		}

        public FolderElementList Children { get; } = new FolderElementList();

        public IsoDirectory Parent { get; }

        public ushort Number { get; set; }

        public override uint Extent1 {
			get {
				return m_extent1;
			}
			set {
				m_extent1 = value;
			}
		}

		public override uint Extent2 {
			get {
				return m_extent2;
			}
			set {
				m_extent2 = value;
			}
		}

		/// <summary>
		/// Size1 in bytes.
		/// </summary>
		public override uint Size1 {
			get {
				return m_size1*IsoAlgorithm.SectorSize;
			}
		}

		/// <summary>
		/// Size2 in bytes.
		/// </summary>
		public override uint Size2 {
			get {
				return m_size2*IsoAlgorithm.SectorSize;
			}
		}

		public override bool IsDirectory {
			get {
				return true;
			}
		}

		#endregion

		#region I/O Methods

		public void WriteFiles( BinaryWriter writer, ProgressDelegate Progress ) {

			foreach ( IsoFolderElement child in Children ) {
				if ( !child.IsDirectory ) {
					((IsoFile)child).Write( writer, Progress );
					Progress( this, new ProgressEventArgs( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) ) );
				}
			}

			foreach ( IsoFolderElement child in Children ) {
				if ( child.IsDirectory ) {
					( (IsoDirectory)child ).WriteFiles( writer, Progress );
					Progress( this, new ProgressEventArgs( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) ) );
				}
			}
		}

		public void Write( BinaryWriter writer, VolumeType type ) {
			DirectoryRecordWrapper record;

            uint extent = ( type == VolumeType.Primary ) ? Extent1 : Extent2;
            uint size = ( type == VolumeType.Primary ) ? Size1 : Size2;
            uint parentExtent = ( type == VolumeType.Primary ) ? Parent.Extent1 : Parent.Extent2;
            uint parentSize = ( type == VolumeType.Primary ) ? Parent.Size1 : Parent.Size2;

			// First write the current directory and the parent. ("." and "..")
			record = new DirectoryRecordWrapper( extent, size, Date, IsDirectory, "." );
			record.Write( writer );

			record = new DirectoryRecordWrapper( parentExtent, parentSize, Parent.Date, Parent.IsDirectory, ".." );
			record.Write( writer );

			// Everything else is written after the first two sectors (current dir and parent).
			int position = 2 * IsoAlgorithm.DefaultDirectoryRecordLength;

			foreach ( IsoFolderElement child in Children ) {

                uint childExtent = ( type == VolumeType.Primary ) ? child.Extent1 : child.Extent2;
                uint childSize = ( type == VolumeType.Primary ) ? child.Size1 : child.Size2;
				string childName = ( type == VolumeType.Primary ) ? child.ShortName : child.LongName;

                record = new DirectoryRecordWrapper(childExtent, childSize, child.Date, child.IsDirectory, childName)
                {
                    VolumeDescriptorType = type
                };

                if ( record.Length + position > IsoAlgorithm.SectorSize ) {
					writer.Write( new byte[IsoAlgorithm.SectorSize-position] );
					position = 0;
				}
				position += record.Write( writer );
			}

			writer.Write( new byte[IsoAlgorithm.SectorSize-position] );
		}

		public int WritePathTable( BinaryWriter writer, bool isRoot, Endian endian, VolumeType type ) {
			PathTableRecordWrapper pathTableRecord;
            uint extent = ( type == VolumeType.Primary ) ? Extent1 : Extent2;
			string name = ( type == VolumeType.Primary ) ? ShortName : LongName;
			if ( isRoot ) {
				pathTableRecord = new PathTableRecordWrapper( extent, Parent.Number, "." );
			} else {
				pathTableRecord = new PathTableRecordWrapper( extent, Parent.Number, name );
			}
			pathTableRecord.VolumeDescriptorType = type;
			pathTableRecord.Endian = endian;
			
			return pathTableRecord.Write( writer );
		}

		#endregion

		#region Set Extent Methods

		public void SetFilesExtent( ref uint currentExtent ) {
			foreach ( IsoFolderElement child in Children) {
				if ( !child.IsDirectory ) {
					if ( child.Size1 == 0 ) {
						child.Extent1 = 0;
					} else {
						child.Extent1 = currentExtent;
						currentExtent += child.Size1/IsoAlgorithm.SectorSize;
						if ( child.Size1%IsoAlgorithm.SectorSize != 0 ) {
							currentExtent++;
						}
					}
				}
			}

			foreach ( IsoFolderElement child in Children) {
				if ( child.IsDirectory ) {
					( (IsoDirectory)child ).SetFilesExtent( ref currentExtent );
				}
			}
		}

		public static void SetExtent1( ArrayList stack, int index, uint currentExtent ) {
			if ( index >= stack.Count ) {
				return;
			}

			IsoDirectory currentDir = (IsoDirectory)stack[index];
			currentDir.Extent1 = currentExtent;

            uint newCurrentExtent = currentExtent + currentDir.Size1/IsoAlgorithm.SectorSize;
			foreach ( IsoFolderElement child in currentDir.Children ) {
				if ( child.IsDirectory ) {
					stack.Add( child );
				}
			}
			SetExtent1( stack, index+1, newCurrentExtent );
		}

		public static void SetExtent2( ArrayList stack, int index, uint currentExtent ) {
			if ( index >= stack.Count ) {
				return;
			}

			IsoDirectory currentDir = (IsoDirectory)stack[index];
			currentDir.Extent2 = currentExtent;

            uint newCurrentExtent = currentExtent + currentDir.Size2/IsoAlgorithm.SectorSize;
			foreach ( IsoFolderElement child in currentDir.Children ) {
				if ( child.IsDirectory ) {
					stack.Add( child );
				}
			}
			SetExtent2( stack, index+1, newCurrentExtent );
		}

		#endregion
	}
}