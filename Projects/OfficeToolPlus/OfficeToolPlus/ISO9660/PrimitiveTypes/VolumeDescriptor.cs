using IsoCreator;

namespace ISO9660.PrimitiveTypes
{
    internal class VolumeDescriptor {
		// field													contents
		// ------------------------------							---------------------------------------------------------
		// [1]
		public byte VolumeDescType;									// 1, 2, 255

		// [2-7]
		public byte[] StandardIdentifier = new byte[6] { 67, 68, 48, 48, 49, 1 };
																	/* 67, 68, 48, 48, 49 ( that is "CD001" ) and 1, respectively 
																	 * (same as Volume Descriptor Set Terminator)
																	 */

		// [8]
		public byte Reserved1 = 0;									// 0

		// [9-40]
		public byte[] SystemId = IsoAlgorithm.MemSet( IsoAlgorithm.SystemIdLength, IsoAlgorithm.AsciiBlank );// system identifier

		// [41-72]
		public byte[] VolumeId = IsoAlgorithm.MemSet( IsoAlgorithm.VolumeIdLength, IsoAlgorithm.AsciiBlank );// volume identifier

		// [73-80]
		public ulong Reserved2 = 0;								// 0

		// [81-88]
		public ulong VolumeSpaceSize;								// total number of sectors, as a both endian double word

		public byte[] Reserved3_1 = new byte[3] { 37, 47, 69 };		// [89-91]
		// [92-120]
		public byte[] Reserved3_2 = new byte[29];					// zeros

		// [121-124]
		public uint VolumeSetSize = 0x01000001;					// 1, as a both endian word [volume set size]

		// [125-128]
		public uint VolumeSequenceNumber = 0x01000001;			// 1, as a both endian word [volume sequence number]

		// [129-132]
		public uint SectorkSize = 0x00080800;						// 2048 (the sector size), as a both endian word

		// [133-140]
		public ulong PathTableSize;								// path table length in bytes, as a both endian double word

		// [141-144]
		public uint TypeLPathTable;								/* number of first sector in first little endian path table,
	                                                                 * as a little endian double word
	                                                                 */

		// [145-148]
		public uint OptionalTypeLPathTable = 0;					/* number of first sector in second little endian path table,
	                                                                 * as a little endian double word, or zero if there is no
	                                                                 * second little endian path table
	                                                                 */

		// [149-152]
		public uint TypeMPathTable; /* a inverser */				/* number of first sector in first big endian path table,
	                                                                 * as a big endian double word
	                                                                 */

		// [153-156]
		public uint OptionalTypeMPathTable = 0; /* a inverser */	/* number of first sector in second big endian path table,
	                                                                 * as a big endian double word, or zero if there is no
	                                                                 * second big endian path table
	                                                                 */

		// [157-190]
		public DirectoryRecord RootDirRecord = new DirectoryRecord();// root directory record

		// [191-318]
		public byte[] VolumeSetId = IsoAlgorithm.MemSet( IsoAlgorithm.VolumeSetIdLength, IsoAlgorithm.AsciiBlank );					
																	// volume set identifier

		// [319-446]
		public byte[] PublisherId = IsoAlgorithm.MemSet( IsoAlgorithm.PublisherIdLength, IsoAlgorithm.AsciiBlank );					
																	// publisher identifier

		// [447-574]
		public byte[] PreparerId = IsoAlgorithm.MemSet( IsoAlgorithm.PreparerIdLength, IsoAlgorithm.AsciiBlank );
																	// data preparer identifier

		// [575-702]
		public byte[] ApplicationId = IsoAlgorithm.MemSet( IsoAlgorithm.ApplicationIdLength, IsoAlgorithm.AsciiBlank );				
																	// application identifier

		// [703-739]
		public byte[] CopyrightFileId = IsoAlgorithm.MemSet( IsoAlgorithm.CopyrightFileIdLength, IsoAlgorithm.AsciiBlank );			
																	// copyright file identifier

		// [740-776]
		public byte[] AbstractFileId = IsoAlgorithm.MemSet( IsoAlgorithm.AbstractFileIdLength, IsoAlgorithm.AsciiBlank );				
																	// abstract file identifier

		// [777-813]
		public byte[] BibliographicFileId = IsoAlgorithm.MemSet( IsoAlgorithm.BibliographicFileIdLength, IsoAlgorithm.AsciiBlank );	
																	// bibliographical file identifier

		// [814-830]
		public AsciiDateRecord CreationDate = new AsciiDateRecord();// date and time of volume creation

		// [831-847]
		public AsciiDateRecord ModificationDate = new AsciiDateRecord();// date and time of most recent modification

		// [848-864]
		public AsciiDateRecord ExpirationDate = new AsciiDateRecord();	// date and time when volume expires

		// [865-881]
		public AsciiDateRecord EffectiveDate = new AsciiDateRecord();	// date and time when volume is effective

		// [882]
		public byte FileStructureVersion = 1;						// 1

		// [883]
		public byte Reserved4 = 0;									// 0

		// [884-1395]
		public byte[] ApplicationData = new byte[512];				// reserved for application use (usually zeros)

		// [1396-2048]
		public byte[] Reserved5 = new byte[653];					// zeros
		// TOTAL 2048 bytes
	}
}
