using IsoCreator;

namespace ISO9660.PrimitiveTypes
{
    internal class DirectoryRecord {
		// field									contents
		// ------------------------------			---------------------------------------------------------
		// [1]
		public byte Length = IsoAlgorithm.DefaultDirectoryRecordLength;
													// 34, the number of bytes in the record (which must be even)

		// [2]
		public byte ExtendedAttributeLength = 0;	// always 0 in DOS [number of sectors in extended attribute record]

		// [3-10]
		public ulong ExtentLocation;				/* number of the first sector of file data or directory
	                                                 * (zero for an empty file), as a both endian double word
	                                                 */

		// [11-18]
		public ulong DataLength;					/* number of bytes of file data or length of directory,
	                                                 * excluding the extended attribute record,
	                                                 * as a both endian double word
	                                                 */

		// [19-24]
		public BinaryDateRecord Date = new BinaryDateRecord();
													// Details in struct DateRecord			

		// [25]
		public sbyte TimeZone;						/* offset from Greenwich Mean Time, in 15-minute intervals,
	                                                 * as a twos complement signed number, positive for time
	                                                 * zones east of Greenwich, and negative for time zones
	                                                 * west of Greenwich (DOS ignores this field)
	                                                 */

		// [26]
		public byte FileFlags;						/* flags, with bits as follows:
	                                                 * bit     value
	                                                 * ------  ------------------------------------------
	                                                 * 0 (LS)  0 for a norma1 file, 1 for a hidden file
	                                                 * 1       0 for a file, 1 for a directory
	                                                 * 2       0 [1 for an associated file]
	                                                 * 3       0 [1 for record format specified]
	                                                 * 4       0 [1 for permissions specified]
	                                                 * 5       0
	                                                 * 6       0
	                                                 * 7 (MS)  0 [1 if not the final record for the file]
	                                                 */

		// [27]
		public byte FileUnitSize = 0;				// 0 [file unit size for an interleaved file]

		// [28]
		public byte InterleaveGapSize = 0;			// 0 [interleave gap size for an interleaved file]

		// [29-32]
		public uint VolumeSequnceNumber = 0x01000001;
													// 1, as a both endian word [volume sequence number]

		// [33]
		public byte LengthOfFileIdentifier;			// the identifier length

		// [34-...]
		public byte[] FileIdentifier;				// identifier

		// A directory record must have even number of bytes. (!!)
	}
}
