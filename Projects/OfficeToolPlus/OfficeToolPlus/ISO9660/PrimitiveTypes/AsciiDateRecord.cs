namespace ISO9660.PrimitiveTypes
{
    internal class AsciiDateRecord {
		// field													contents
		// --------													---------------------------------------------------------
		public byte[] Year = new byte[4] { 48, 48, 48, 48 };		// year, as four ASCII digits

		public byte[] Month = new byte[2] { 48, 48 };				/* month, as two ASCII digits, where
	                                                                 * 01=January, 02=February, etc.
	                                                                 */

		public byte[] DayOfMonth = new byte[2] { 48, 48 };			/* day of month, as two ASCII digits, in the range
	                                                                 * from 01 to 31
	                                                                 */

		public byte[] Hour = new byte[2] { 48, 48 };				// hour, as two ASCII digits, in the range from 00 to 23

		public byte[] Minute = new byte[2] { 48, 48 };				// minute, as two ASCII digits, in the range from 00 to 59

		public byte[] Second = new byte[2] { 48, 48 };				// second, as two ASCII digits, in the range from 00 to 59

		public byte[] HundredthsOfSecond = new byte[2] { 48, 48 };	/* hundredths of a second, as two ASCII digits, in the range
	                                                                 * from 00 to 99
	                                                                 */

		public sbyte TimeZone;										/* offset from Greenwich Mean Time, in 15-minute intervals,
	                                                                 * as a twos complement signed number, positive for time
	                                                                 * zones east of Greenwich, and negative for time zones
	                                                                 * west of Greenwich
	                                                                 */
	}
}
