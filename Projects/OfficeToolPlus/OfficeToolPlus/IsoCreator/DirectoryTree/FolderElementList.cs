using System.Collections;

namespace IsoCreator.DirectoryTree
{
    /// <summary>
    /// This class represents a collection of folder elements (files and folders) which can be sorted by name.
    /// </summary>
    internal class FolderElementList : CollectionBase {

		#region Comparer

		public class DirEntryComparer : IComparer {
			#region IComparer Members

			public int Compare( object x, object y ) {
				string nameX = ( (IsoFolderElement)x ).LongName;
				string nameY = ( (IsoFolderElement)y ).LongName;

				return string.Compare( nameX, nameY, false );
			}

			#endregion
		}

		#endregion

		public void Add( IsoFolderElement value ) {
            InnerList.Add( value );
		}

		public void Sort() {
			DirEntryComparer dirEntryComparer = new DirEntryComparer();
            InnerList.Sort( dirEntryComparer );
		}
	}
}
