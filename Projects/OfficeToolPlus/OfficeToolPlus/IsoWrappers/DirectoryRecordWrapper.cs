using System;
using System.IO;
using ISO9660.PrimitiveTypes;
using ISO9660.Enums;

namespace IsoCreator.IsoWrappers
{

    /// <summary>
    /// Wrapper for ISO9660.PrimitiveTypes.DirectoryRecord
    /// </summary>
    internal class DirectoryRecordWrapper {
		#region Fields

		private DirectoryRecord m_record = new DirectoryRecord();
		private DateWrapper m_date;
		private VolumeType m_volumeDescriptorType = VolumeType.Primary;

		#endregion

		#region Properties

		public DirectoryRecord Record {
			get {
				return m_record;
			}
			set {
				m_record = value;
				m_date.BinaryDateRecord = m_record.Date;
			}
		}

		public VolumeType VolumeDescriptorType {
			get {
				return m_volumeDescriptorType;
			}
			set {
				if ( m_record.FileIdentifier.Length == 1 && m_record.FileIdentifier[0] <= 1 ) {
					m_volumeDescriptorType = value;
					return;
				}

				if ( m_volumeDescriptorType != value && 
					( m_volumeDescriptorType == VolumeType.Suplementary ||  
					value == VolumeType.Suplementary ) ) {

					if ( m_record != null ) {
						switch ( value ) {
							case VolumeType.Suplementary:

							m_record.FileIdentifier = IsoAlgorithm.AsciiToUnicode( m_record.FileIdentifier );
							m_record.LengthOfFileIdentifier = (byte)m_record.FileIdentifier.Length;
							m_record.Length = (byte)( 33 + m_record.LengthOfFileIdentifier + ( 1 - m_record.LengthOfFileIdentifier%2 ) );

							if ( 33 + m_record.LengthOfFileIdentifier + ( 1 - m_record.LengthOfFileIdentifier%2 ) > 255 ) {
								throw new Exception( "Depasire!" );
							}

							break;

							default:

							m_record.FileIdentifier = IsoAlgorithm.UnicodeToAscii( m_record.FileIdentifier );
							m_record.LengthOfFileIdentifier = (byte)m_record.FileIdentifier.Length;
							m_record.Length = (byte)( 33 + m_record.LengthOfFileIdentifier + ( 1 - m_record.LengthOfFileIdentifier%2 ) );

							if ( m_record.FileIdentifier.Length > 255 || 
								33 + m_record.LengthOfFileIdentifier + ( 1 - m_record.LengthOfFileIdentifier%2 ) > 255 ) {

								throw new Exception( "Depasire!" );
							}

							break;

						}
					}
				}
				m_volumeDescriptorType = value;
			}
		}
		public byte Length {
			get {
				return m_record.Length;
			}
		}

		#endregion

		#region Constructors
		public DirectoryRecordWrapper(uint extentLocation, uint dataLength, DateTime date, bool isDirectory, string name ) {
            SetDirectoryRecord( extentLocation, dataLength, date, isDirectory, name );
		}

		public DirectoryRecordWrapper( DirectoryRecord directoryRecord ) {
			m_record = directoryRecord;
			m_date = new DateWrapper( directoryRecord.Date );
		}

		#endregion

		#region Set Methods

		private void SetDirectoryRecord(ulong extentLocation, ulong dataLength, BinaryDateRecord date, sbyte timeZone, byte fileFlags, byte[] fileIdentifier ) {
			if ( m_record == null ) {
				m_record = new DirectoryRecord();
			}

			m_record.ExtentLocation = extentLocation;
			m_record.DataLength = dataLength;

			m_record.Date = date;

			m_record.TimeZone = timeZone;
			m_record.FileFlags = fileFlags;

			m_record.LengthOfFileIdentifier = (byte)fileIdentifier.Length;
			m_record.FileIdentifier = fileIdentifier;

			m_record.Length = (byte)( m_record.LengthOfFileIdentifier+33 );
			if ( m_record.Length%2 == 1 ) {
				m_record.Length++;
			}

			if ( fileIdentifier.Length > 255 ||
				m_record.LengthOfFileIdentifier+33 > 255 ) {

				throw new Exception( "Depasire!" );
			}

			if ( m_volumeDescriptorType == VolumeType.Suplementary && 
				( ( fileFlags & 2 ) == 0 || 
				  fileIdentifier.Length != 1 || fileIdentifier[0] > 1 ) ) {

				m_volumeDescriptorType = VolumeType.Primary;
                VolumeDescriptorType = VolumeType.Suplementary;
			}
		}

		private void SetDirectoryRecord(uint extentLocation, uint dataLength, DateTime date, sbyte timeZone, bool isDirectory, string name ) {
			m_date = new DateWrapper( date );
			byte fileFlags = ( isDirectory ) ? (byte)2 : (byte)0;

			byte[] fileIdentifier;
			if ( name == "." ) {
				fileIdentifier = new byte[1] { 0 };
			} else if ( name == ".." ) {
				fileIdentifier = new byte[1] { 1 };
			} else {
				if ( isDirectory ) {
					fileIdentifier = IsoAlgorithm.StringToByteArray( name );
				} else {
					fileIdentifier = IsoAlgorithm.StringToByteArray( name + ";1" );
				}
			}

            SetDirectoryRecord(
					IsoAlgorithm.BothEndian( extentLocation ),
					IsoAlgorithm.BothEndian( dataLength ),
					m_date.BinaryDateRecord,
					timeZone,
					fileFlags,
					fileIdentifier
			);
		}

		public void SetDirectoryRecord(uint extentLocation, uint dataLength, DateTime date, bool isDirectory, string name ) {
            SetDirectoryRecord( extentLocation, dataLength, date, (sbyte)8, isDirectory, name );
		}

		#endregion

		#region I/O Methods

		public int Write( BinaryWriter writer ) {
			if ( m_record == null ) {
				return 0;
			}

			writer.Write( m_record.Length );
			writer.Write( m_record.ExtendedAttributeLength );
			writer.Write( m_record.ExtentLocation );
			writer.Write( m_record.DataLength );

			m_date.WriteBinaryDateRecord( writer );

			writer.Write( m_record.TimeZone );
			writer.Write( m_record.FileFlags );
			writer.Write( m_record.FileUnitSize );
			writer.Write( m_record.InterleaveGapSize );
			writer.Write( m_record.VolumeSequnceNumber );
			writer.Write( m_record.LengthOfFileIdentifier );
			writer.Write( m_record.FileIdentifier );

			if ( m_record.LengthOfFileIdentifier%2 == 0 ) {
				writer.Write( (byte)0 );
			}

			return m_record.Length;
		}

		#endregion
	}
}
