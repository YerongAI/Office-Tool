namespace ISO9660.PrimitiveTypes
{
    internal class PathTableRecord {
		public byte Length;					// N, the identifier length (or 1 for the root directory)

		public byte ExtendedLength = 0;		// 0 [number of sectors in extended attribute record]

		public uint ExtentLocation;		/* number of the first sector in the directory, as a
	                                         * double word
	                                         */

		public ushort ParentNumber;			/* number of record for parent directory (or 1 for the root
	                                         * directory), as a word; the first record is number 1,
	                                         * the second record is number 2, etc.
	                                         */

		public byte[] Identifier;			// identifier (or 0 for the root directory)

		// One record must have even number of bytes.
	}
}
