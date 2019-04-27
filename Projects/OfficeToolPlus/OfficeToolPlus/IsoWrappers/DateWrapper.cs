using System;
using System.IO;
using ISO9660.PrimitiveTypes;

namespace IsoCreator.IsoWrappers
{
    internal class DateWrapper {

        #region Fields
        private DateTime m_date;

        #endregion

        #region Properties

        public BinaryDateRecord BinaryDateRecord { get; set; }

        public AsciiDateRecord AsciiDateRecord { get; set; }

        public DateTime Date {
			get {
				return m_date;
			}
			set {
				m_date = value;
                SetAsciiDateRecord( value );
                SetBinaryDateRecord( value );
			}
		}

		#endregion

		#region Constructor(s)

		public DateWrapper( DateTime date ) {
            Date = date;
		}

		public DateWrapper( DateTime date, sbyte timeZone ) {
			m_date = date;
            SetAsciiDateRecord( date, timeZone );
            SetBinaryDateRecord( date );
		}

		public DateWrapper( BinaryDateRecord dateRecord ) {
			BinaryDateRecord = dateRecord;
            SetAsciiDateRecord( 1900+dateRecord.Year, dateRecord.Month, dateRecord.DayOfMonth, dateRecord.Hour, dateRecord.Minute, dateRecord.Second, 0, 8 );
			m_date = new DateTime( 1900+dateRecord.Year, dateRecord.Month, dateRecord.DayOfMonth, dateRecord.Hour, dateRecord.Minute, dateRecord.Second );
		}

		public DateWrapper( AsciiDateRecord dateRecord ) {
			AsciiDateRecord = dateRecord;

			byte year = (byte)( Convert.ToInt32( IsoAlgorithm.ByteArrayToString( dateRecord.Year ) ) - 1900 );
			byte month = Convert.ToByte( IsoAlgorithm.ByteArrayToString( dateRecord.Month ) );
			byte dayOfMonth = Convert.ToByte( IsoAlgorithm.ByteArrayToString( dateRecord.DayOfMonth ) );
			byte hour = Convert.ToByte( IsoAlgorithm.ByteArrayToString( dateRecord.Hour ) );
			byte minute = Convert.ToByte( IsoAlgorithm.ByteArrayToString( dateRecord.Minute ) );
			byte second = Convert.ToByte( IsoAlgorithm.ByteArrayToString( dateRecord.Second ) );
			int millisecond = Convert.ToInt32( IsoAlgorithm.ByteArrayToString( dateRecord.HundredthsOfSecond ) ) * 10;

            SetBinaryDateRecord( year, month, dayOfMonth, hour, minute, second );
			m_date = new DateTime( 1900+year, month, dayOfMonth, hour, minute, second, millisecond );
		}

		#endregion

		#region Set Methods

		private void SetBinaryDateRecord( byte year, byte month, byte dayOfMonth, byte hour, byte minute, byte second ) {
			if ( BinaryDateRecord == null ) {
				BinaryDateRecord = new BinaryDateRecord();
			}

			BinaryDateRecord.Year = year;
			BinaryDateRecord.Month = month;
			BinaryDateRecord.DayOfMonth = dayOfMonth;
			BinaryDateRecord.Hour = hour;
			BinaryDateRecord.Minute = minute;
			BinaryDateRecord.Second = second;
		}

		private void SetBinaryDateRecord( DateTime date ) {
            SetBinaryDateRecord(
				(byte)( date.Year - 1900 ),
				(byte)date.Month,
				(byte)date.Day,
				(byte)date.Hour,
				(byte)date.Minute,
				(byte)date.Second
			);
		}

		private void SetAsciiDateRecord( int year, int month, int dayOfMonth, int hour, int minute, int second, int hundredthsOfSecond, sbyte timeZone ) {
			if ( AsciiDateRecord == null ) {
				AsciiDateRecord = new AsciiDateRecord();
			}

			string sYear = string.Format( "{0:D4}", year%10000 );
			string sMonth = string.Format( "{0:D2}", month );
			string sDay = string.Format( "{0:D2}", dayOfMonth );
			string sHour = string.Format( "{0:D2}", hour );
			string sMinute = string.Format( "{0:D2}", minute );
			string sSecond = string.Format( "{0:D2}", second );
			string sHundredths = string.Format( "{0:D2}", hundredthsOfSecond );

			AsciiDateRecord.Year = IsoAlgorithm.StringToByteArray( sYear );
			AsciiDateRecord.Month = IsoAlgorithm.StringToByteArray( sMonth );
			AsciiDateRecord.DayOfMonth = IsoAlgorithm.StringToByteArray( sDay );
			AsciiDateRecord.Hour = IsoAlgorithm.StringToByteArray( sHour );
			AsciiDateRecord.Minute = IsoAlgorithm.StringToByteArray( sMinute );
			AsciiDateRecord.Second = IsoAlgorithm.StringToByteArray( sSecond );
			AsciiDateRecord.HundredthsOfSecond = IsoAlgorithm.StringToByteArray( sHundredths );
			AsciiDateRecord.TimeZone = timeZone;
		}

		private void SetAsciiDateRecord( DateTime date, sbyte timeZone ) {
            SetAsciiDateRecord( date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond/10, timeZone );
		}

		private void SetAsciiDateRecord( DateTime date ) {
            SetAsciiDateRecord( date, 8 );
		}

		#endregion

		#region I/O Methods

		public int WriteBinaryDateRecord( BinaryWriter writer ) {
			if ( BinaryDateRecord == null ) {
				return 0;
			}

			writer.Write( new byte[6] { 
					BinaryDateRecord.Year, 
					BinaryDateRecord.Month, 
					BinaryDateRecord.DayOfMonth, 
					BinaryDateRecord.Hour, 
					BinaryDateRecord.Minute, 
					BinaryDateRecord.Second 
				} );

			return 6;
		}

		public int WriteAsciiDateRecord( BinaryWriter writer ) {
			if ( AsciiDateRecord == null ) {
				return 0;
			}

			writer.Write( AsciiDateRecord.Year );
			writer.Write( AsciiDateRecord.Month );
			writer.Write( AsciiDateRecord.DayOfMonth );
			writer.Write( AsciiDateRecord.Hour );
			writer.Write( AsciiDateRecord.Minute );
			writer.Write( AsciiDateRecord.Second );
			writer.Write( AsciiDateRecord.HundredthsOfSecond );
			writer.Write( AsciiDateRecord.TimeZone );

			return 17;
		}

		#endregion
	}
}
