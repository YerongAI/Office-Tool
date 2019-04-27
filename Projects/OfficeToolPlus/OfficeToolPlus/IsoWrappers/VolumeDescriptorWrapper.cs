using System;
using System.IO;
using ISO9660.PrimitiveTypes;
using ISO9660.Enums;

namespace IsoCreator.IsoWrappers
{
    internal class VolumeDescriptorWrapper {
		#region Fields

		private VolumeDescriptor m_volumeDescriptor = new VolumeDescriptor();

		private VolumeType m_volumeDescriptorType = VolumeType.Primary;

		private DirectoryRecordWrapper m_rootDirRecord;
		private DateWrapper m_creationDate;
		private DateWrapper m_modificationDate;
		private DateWrapper m_expirationDate;
		private DateWrapper m_effectiveDate;

		#endregion

		#region Constructors

		public VolumeDescriptorWrapper( string volumeName, uint volumeSpaceSize, uint pathTableSize, uint typeLPathTable, uint typeMPathTable,
									DirectoryRecordWrapper root, DateTime creationDate, DateTime modificationDate, sbyte timeZone ) {

            SetVolumeDescriptor( volumeName, volumeSpaceSize, pathTableSize, typeLPathTable, typeMPathTable, root, creationDate,
									  modificationDate, timeZone );
		}
		#endregion

		#region Properties
		public VolumeType VolumeDescriptorType {
			get {
				return m_volumeDescriptorType;
			}
			set {
				if ( m_volumeDescriptorType != value && 
					( m_volumeDescriptorType == VolumeType.Suplementary ||  
					value == VolumeType.Suplementary ) ) {

					if ( m_volumeDescriptor != null ) {
						switch ( value ) {
							case VolumeType.Suplementary:

							m_volumeDescriptor.SystemId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.SystemId, IsoAlgorithm.SystemIdLength );
							m_volumeDescriptor.VolumeId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.VolumeId, IsoAlgorithm.VolumeIdLength );
							m_volumeDescriptor.VolumeSetId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.VolumeSetId, IsoAlgorithm.VolumeSetIdLength );
							m_volumeDescriptor.PublisherId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.PublisherId, IsoAlgorithm.PublisherIdLength );
							m_volumeDescriptor.PreparerId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.PreparerId, IsoAlgorithm.PreparerIdLength );
							m_volumeDescriptor.ApplicationId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.ApplicationId, IsoAlgorithm.ApplicationIdLength );
							m_volumeDescriptor.CopyrightFileId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.CopyrightFileId, IsoAlgorithm.CopyrightFileIdLength );
							m_volumeDescriptor.AbstractFileId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.AbstractFileId, IsoAlgorithm.AbstractFileIdLength );
							m_volumeDescriptor.BibliographicFileId = IsoAlgorithm.AsciiToUnicode( m_volumeDescriptor.BibliographicFileId, IsoAlgorithm.BibliographicFileIdLength );

							break;

							default:

							m_volumeDescriptor.SystemId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.SystemId, IsoAlgorithm.SystemIdLength );
							m_volumeDescriptor.VolumeId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.VolumeId, IsoAlgorithm.VolumeIdLength );
							m_volumeDescriptor.VolumeSetId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.VolumeSetId, IsoAlgorithm.VolumeSetIdLength );
							m_volumeDescriptor.PublisherId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.PublisherId, IsoAlgorithm.PublisherIdLength );
							m_volumeDescriptor.PreparerId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.PreparerId, IsoAlgorithm.PreparerIdLength );
							m_volumeDescriptor.ApplicationId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.ApplicationId, IsoAlgorithm.ApplicationIdLength );
							m_volumeDescriptor.CopyrightFileId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.CopyrightFileId, IsoAlgorithm.CopyrightFileIdLength );
							m_volumeDescriptor.AbstractFileId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.AbstractFileId, IsoAlgorithm.AbstractFileIdLength );
							m_volumeDescriptor.BibliographicFileId = IsoAlgorithm.UnicodeToAscii( m_volumeDescriptor.BibliographicFileId, IsoAlgorithm.BibliographicFileIdLength );

							break;

						}
					}
				}

				m_volumeDescriptorType = value;
				if ( m_volumeDescriptor != null ) {
					m_volumeDescriptor.VolumeDescType = (byte)value;
				}
			}
		}
		#endregion

		#region Set Methods

		private void SetVolumeDescriptor( byte[] systemId, byte[] volumeId, ulong volumeSpaceSize, ulong pathTableSize,
                                          uint typeLPathTable, uint typeMPathTable, DirectoryRecord rootDirRecord,
										  AsciiDateRecord creationDate, AsciiDateRecord modificationDate,
										  AsciiDateRecord expirationDate, AsciiDateRecord effectiveDate ) {

			if ( m_volumeDescriptor == null ) {
				m_volumeDescriptor = new VolumeDescriptor();
			}

			m_volumeDescriptor.VolumeDescType = (byte)m_volumeDescriptorType;

			systemId.CopyTo( m_volumeDescriptor.SystemId, 0 );
			volumeId.CopyTo( m_volumeDescriptor.VolumeId, 0 );
			m_volumeDescriptor.VolumeSpaceSize = volumeSpaceSize;
			m_volumeDescriptor.PathTableSize = pathTableSize;
			m_volumeDescriptor.TypeLPathTable = typeLPathTable;
			m_volumeDescriptor.TypeMPathTable = typeMPathTable;

			m_volumeDescriptor.RootDirRecord = rootDirRecord;
			m_rootDirRecord = new DirectoryRecordWrapper( rootDirRecord );

			m_volumeDescriptor.CreationDate = creationDate;
			m_creationDate = new DateWrapper( creationDate );

			m_volumeDescriptor.ModificationDate = modificationDate;
			m_modificationDate = new DateWrapper( modificationDate );

			m_volumeDescriptor.ExpirationDate = expirationDate;
			m_expirationDate = new DateWrapper( expirationDate );

			m_volumeDescriptor.EffectiveDate = effectiveDate;
			m_effectiveDate = new DateWrapper( effectiveDate );
		}

        private void SetVolumeDescriptor( string systemId, string volumeId, uint volumeSpaceSize, uint pathTableSize,
                                          uint typeLPathTable, uint typeMPathTable, DirectoryRecordWrapper rootDir, DateTime creationDate, DateTime modificationDate, sbyte timeZone ) {

			byte[] lSystemId;
			byte[] lVolumeId;

			if ( VolumeDescriptorType == VolumeType.Primary ) {

				lSystemId = IsoAlgorithm.StringToByteArray( systemId, IsoAlgorithm.SystemIdLength );
				lVolumeId = IsoAlgorithm.StringToByteArray( volumeId, IsoAlgorithm.VolumeIdLength );

			} else if ( VolumeDescriptorType == VolumeType.Suplementary ) {

				lSystemId = IsoAlgorithm.AsciiToUnicode( systemId, IsoAlgorithm.SystemIdLength );
				lVolumeId = IsoAlgorithm.AsciiToUnicode( volumeId, IsoAlgorithm.VolumeIdLength );

			} else {
				if ( m_volumeDescriptor == null ) {
					m_volumeDescriptor = new VolumeDescriptor();
				}
				m_volumeDescriptor.VolumeDescType = (byte)m_volumeDescriptorType;
				return;
			}

            ulong lVolumeSpaceSize = IsoAlgorithm.BothEndian( volumeSpaceSize );
            ulong lPathTableSize = IsoAlgorithm.BothEndian( pathTableSize );

            // typeLPathTable remains unchanged, but typeMPathTable has to change byte order.
            uint lTypeMPathTable = IsoAlgorithm.ChangeEndian( typeMPathTable );
			DateWrapper lCreationDate = new DateWrapper( creationDate, timeZone );

			DateWrapper lModificationDate = new DateWrapper( modificationDate, timeZone );

			DateWrapper bufferDate = new DateWrapper( IsoAlgorithm.NoDate );

            SetVolumeDescriptor( lSystemId, lVolumeId, lVolumeSpaceSize, lPathTableSize, typeLPathTable, lTypeMPathTable,
									  rootDir.Record, lCreationDate.AsciiDateRecord, lModificationDate.AsciiDateRecord,
									  bufferDate.AsciiDateRecord, bufferDate.AsciiDateRecord );
		}

		public void SetVolumeDescriptor( string volumeName, uint volumeSpaceSize, uint pathTableSize, uint typeLPathTable,
                                         uint typeMPathTable, DirectoryRecordWrapper root, DateTime creationDate, DateTime modificationDate, sbyte timeZone ) {

            SetVolumeDescriptor( " ", volumeName, volumeSpaceSize, pathTableSize, typeLPathTable, typeMPathTable,
									  root, creationDate, modificationDate, timeZone );
		}

		#endregion

		#region I/O Methods

		public int Write( BinaryWriter writer ) {
			if ( m_volumeDescriptor == null ) {
				return 0;
			}

			writer.Write( (byte)m_volumeDescriptor.VolumeDescType );
			writer.Write( m_volumeDescriptor.StandardIdentifier );

			if ( VolumeDescriptorType == VolumeType.SetTerminator ) {
				writer.Write( new byte[IsoAlgorithm.SectorSize - 7] );
				return (int)IsoAlgorithm.SectorSize;
			}

			writer.Write( m_volumeDescriptor.Reserved1 );
			writer.Write( m_volumeDescriptor.SystemId );
			writer.Write( m_volumeDescriptor.VolumeId );
			writer.Write( m_volumeDescriptor.Reserved2 );
			writer.Write( m_volumeDescriptor.VolumeSpaceSize );

			if ( m_volumeDescriptorType == VolumeType.Suplementary ) {
				writer.Write( m_volumeDescriptor.Reserved3_1 );
			} else {
				writer.Write( new byte[3] );
			}
			writer.Write( m_volumeDescriptor.Reserved3_2 );
			writer.Write( m_volumeDescriptor.VolumeSetSize );
			writer.Write( m_volumeDescriptor.VolumeSequenceNumber );
			writer.Write( m_volumeDescriptor.SectorkSize );
			writer.Write( m_volumeDescriptor.PathTableSize );
			writer.Write( m_volumeDescriptor.TypeLPathTable );
			writer.Write( m_volumeDescriptor.OptionalTypeLPathTable );
			writer.Write( m_volumeDescriptor.TypeMPathTable );
			writer.Write( m_volumeDescriptor.OptionalTypeMPathTable );

			m_rootDirRecord.VolumeDescriptorType = VolumeDescriptorType;
			m_rootDirRecord.Write( writer );

			writer.Write( m_volumeDescriptor.VolumeSetId );
			writer.Write( m_volumeDescriptor.PublisherId );
			writer.Write( m_volumeDescriptor.PreparerId );
			writer.Write( m_volumeDescriptor.ApplicationId );
			writer.Write( m_volumeDescriptor.CopyrightFileId );
			writer.Write( m_volumeDescriptor.AbstractFileId );
			writer.Write( m_volumeDescriptor.BibliographicFileId );

			m_creationDate.WriteAsciiDateRecord( writer );
			m_modificationDate.WriteAsciiDateRecord( writer );
			m_expirationDate.WriteAsciiDateRecord( writer );
			m_effectiveDate.WriteAsciiDateRecord( writer );

			writer.Write( m_volumeDescriptor.FileStructureVersion );
			writer.Write( m_volumeDescriptor.Reserved4 );
			writer.Write( m_volumeDescriptor.ApplicationData );
			writer.Write( m_volumeDescriptor.Reserved5 );

			return (int)IsoAlgorithm.SectorSize;
		}

		#endregion
	}
}
