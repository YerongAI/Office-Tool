using System.IO;
using OTP.Export;

namespace IsoCreator.DirectoryTree
{

    /// <summary>
    /// The file (folder element).
    /// </summary>
    internal class IsoFile : IsoFolderElement {

		#region Fields

		private readonly string m_fullPath;
		private readonly uint m_size;
		private uint m_extent;

		#endregion

		#region Constructors

		public IsoFile( FileInfo file, string childNumber )
			: base( file, false, childNumber ) {

			m_fullPath = file.FullName;
			m_size = (uint)file.Length;
		}

		#endregion

		#region Properties

		public override uint Extent1 {
			get {
				return m_extent;
			}
			set {
				m_extent = value;
			}
		}

		public override uint Extent2 {
			get {
				return m_extent;
			}
			set {
				m_extent = value;
			}
		}

		public override uint Size1 {
			get {
				return m_size;
			}
		}

		public override uint Size2 {
			get {
				return m_size;
			}
		}

		public override bool IsDirectory {
			get {
				return false;
			}
		}

		#endregion

		#region I/O Methods

		public void Write( BinaryWriter writer, ProgressDelegate Progress ) {
			if ( m_extent > 0 && m_size > 0 ) {
				
				FileStream source = new FileStream( m_fullPath, FileMode.Open, FileAccess.Read );
				BinaryReader reader = new BinaryReader( source );

				// The write buffer is 1MB long. I haven't given too much study into this particular field, so 
				// feel free to change according two whatever writing speed is optimal.
				int bucket = (int)IsoAlgorithm.SectorSize*512; // 1 MB
				byte[] buffer = new byte[bucket];
				while ( true ) {
					int bytesRead = reader.Read( buffer, 0, bucket );

					if ( bytesRead == 0 ) {
						break;
					}

					if ( bytesRead == bucket ) {
						writer.Write( buffer );
					} else {
						writer.Write( buffer, 0, bytesRead );
						if ( bytesRead%IsoAlgorithm.SectorSize != 0 ) {
							writer.Write( new byte[IsoAlgorithm.SectorSize-( bytesRead%IsoAlgorithm.SectorSize )] );
						}
						break;
					}

					Progress( this, new ProgressEventArgs( (int)( writer.BaseStream.Length/IsoAlgorithm.SectorSize ) ) );
				}

				reader.Close();
                source.Close();
			}
		}

		#endregion

	}
}
