using System;
using System.IO;

namespace IsoCreator.DirectoryTree
{

    /// <summary>
    /// Base class for all folder elements (files and subfolders).
    /// </summary>
    internal abstract class IsoFolderElement {

        #region Fields

        private string m_shortIdent;    /* The shortIdent is used for the DOS short-ascii-name. I haven't given too much 
										 * effort into making it right. It isn't of much use these days.
										 */

        #endregion

        #region Constructors

        public IsoFolderElement( FileSystemInfo folderElement, bool isRoot, string childNumber ) {
			Date = folderElement.CreationTime;
			LongName = folderElement.Name;

			// If you need to use the short name, then you may want to change the naming method.
			if ( isRoot ) {
				m_shortIdent = ".";
				LongName = ".";
			} else {
				if ( LongName.Length > 8 ) {
					m_shortIdent = LongName.Substring( 0, 8 - childNumber.Length ).ToUpper().Replace( ' ', '_' ).Replace( '.', '_' );
					m_shortIdent += childNumber;
				} else {
					m_shortIdent = LongName.ToUpper().Replace( ' ', '_' ).Replace( '.', '_' );
				}
			}

			if ( LongName.Length > IsoAlgorithm.FileNameMaxLength ) {
				LongName = LongName.Substring( 0, IsoAlgorithm.FileNameMaxLength - childNumber.Length ) + childNumber;
			}

		}

		#endregion

		#region Abstract properties

		public abstract uint Extent1 {
			get;
			set;
		}

		public abstract uint Extent2 {
			get;
			set;
		}

		public abstract uint Size1 {
			get;
		}

		public abstract uint Size2 {
			get;
		}

		public abstract bool IsDirectory {
			get;
		}

        public DateTime Date { get; }

        public string ShortName {
			get {
				return m_shortIdent;
			}
			set {
				m_shortIdent = value;
			}
		}

        public string LongName { get; }

        #endregion

        #region I/O Methods

        #endregion
    }
}
