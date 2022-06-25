#### 9.0.2

1. The shortcut key of opening command box changed from **Ctrl + P** to **Ctrl + `**
2. Added tooltip for navigation bar items.
3. Fixed an issue that some languages could not be loaded.
4. Other bug fixes and performance improvement.

> Since **Ctrl + P** conflicts with the Print command, we had to change the shortcut to open the command box.

##### Deploy

1. When the user-defined version number does not match the retrieved version number, closing the window can cancel the download.
2. Application preferences now show loading progress.
3. Optimized MAK settings.
4. Fixed an issue where the Office version was incorrectly obtained in some cases.

##### Activate

1. Licenses support searching and filtering by list. [#527](https://github.com/YerongAI/Office-Tool/issues/527)
2. Support for reloading Office information via `F5` and `Ctrl + R`.
3. Support for displaying activation information via `Ctrl + D`.
4. Support for clearing operation result via `Ctrl + E`.
5. Support for opening licenses list via `Ctrl + Shift + P`.

##### Toolbox

1. Fixed an issue that when deleting the default template, an error was occurred because the file did not exist.
