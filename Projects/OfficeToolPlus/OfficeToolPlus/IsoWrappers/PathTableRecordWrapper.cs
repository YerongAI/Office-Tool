using System;
using System.IO;
using ISO9660.PrimitiveTypes;
using ISO9660.Enums;

namespace IsoCreator.IsoWrappers
{
    internal class PathTableRecordWrapper {

        #region Fields

        private Endian m_endian = Endian.LittleEndian;

		private VolumeType m_volumeDescriptorType = VolumeType.Primary;

		#endregion

		#region Constructors
		public PathTableRecordWrapper(uint extentLocation, ushort parentNumber, string name ) {
            SetPathTableRecord( extentLocation, parentNumber, name );
		}

        #endregion

        #region Properties

        public PathTableRecord Record { get; set; } = new PathTableRecord();

        public Endian Endian {
			get {
				return m_endian;
			}
			set {
				if ( value != m_endian ) {
					Record.ExtentLocation = IsoAlgorithm.ChangeEndian( Record.ExtentLocation );
					Record.ParentNumber = IsoAlgorithm.ChangeEndian( Record.ParentNumber );
				}
				m_endian = value;
			}
		}

		public VolumeType VolumeDescriptorType {
			get {
				return m_volumeDescriptorType;
			}
			set {
				if ( Record==null || Record.Identifier.Length == 1 && Record.Identifier[0] == 0 ) {
					m_volumeDescriptorType = value;
					return;
				}
				if ( m_volumeDescriptorType != value && 
					( m_volumeDescriptorType == VolumeType.Suplementary ||  
					value == VolumeType.Suplementary ) ) {


					switch ( value ) {
						case VolumeType.Suplementary:

						Record.Identifier = IsoAlgorithm.AsciiToUnicode( Record.Identifier );
						Record.Length = (byte)( Record.Identifier.Length );

						if ( Record.Identifier.Length > 255 ) {
							throw new Exception( "Depasire!" );
						}

						break;

						default:

						Record.Identifier = IsoAlgorithm.UnicodeToAscii( Record.Identifier );
						Record.Length = (byte)( Record.Identifier.Length );

						if ( Record.Identifier.Length > 255 ) {
							throw new Exception( "Depasire!" );
						}

						break;

					}

				}
				m_volumeDescriptorType = value;
			}
		}
		#endregion

		#region Set Methods

		private void SetPathTableRecord(uint extentLocation, ushort parentNumber, byte[] identifier ) {
			if ( Record == null ) {
				Record = new PathTableRecord();
			}

			Record.Length = (byte)identifier.Length;

			if ( identifier.Length > 255 ) {
				throw new Exception( "Depasire!" );
			}

			Record.Identifier = identifier;

			Record.ExtentLocation = extentLocation;
			Record.ParentNumber = parentNumber;

			if ( m_volumeDescriptorType == VolumeType.Suplementary && ( identifier.Length>1 || identifier[0]!=0 ) ) {
				m_volumeDescriptorType = VolumeType.Primary;
                VolumeDescriptorType = VolumeType.Suplementary;
			}
		}

		public void SetPathTableRecord(uint extentLocation, ushort parentNumber, string name ) {
			if ( m_endian == Endian.BigEndian ) {
				extentLocation = IsoAlgorithm.ChangeEndian( extentLocation );
				parentNumber = IsoAlgorithm.ChangeEndian( parentNumber );
			}

			byte[] identifier;
			if ( name != "." ) {
				identifier = IsoAlgorithm.StringToByteArray( name );
			} else {
				// If this is the root dir, then the identifier is 0.
				identifier = new byte[1] { 0 };
			}

            SetPathTableRecord( extentLocation, parentNumber, identifier );
		}

		#endregion

		#region I/O Methods

		public int Write( BinaryWriter writer ) {
			if ( Record == null ) {
                Record = new PathTableRecord
                {
                    Length = 1,
                    Identifier = new byte[1] { 65 }
                };
            }

			writer.Write( Record.Length );
			writer.Write( Record.ExtendedLength );
			writer.Write( Record.ExtentLocation );
			writer.Write( Record.ParentNumber );
			writer.Write( Record.Identifier );

			if ( Record.Length%2 == 1 ) {
				writer.Write( (byte)0 );
			}

			return 8+Record.Length+( Record.Length%2 );
		}

		#endregion
	}
}
