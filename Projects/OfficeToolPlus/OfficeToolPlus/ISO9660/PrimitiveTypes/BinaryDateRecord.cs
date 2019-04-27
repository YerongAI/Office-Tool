namespace ISO9660.PrimitiveTypes
{
    internal class BinaryDateRecord {
		public byte Year;					// number of years since 1900

		public byte Month;					// month, where 1=January, 2=February, etc.

		public byte DayOfMonth;				// day of month, in the range from 1 to 31

		public byte Hour;					// hour, in the range from 0 to 23

		public byte Minute;					// minute, in the range from 0 to 59

		public byte Second;					/* second, in the range from 0 to 59
	                                         * (for DOS this is always an even number)
	                                         */
	}
}
