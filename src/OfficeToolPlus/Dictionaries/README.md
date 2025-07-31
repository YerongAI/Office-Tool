# Office Tool Plus Translation Guidelines

XAML files are localized files used by Office Tool Plus. We recommend that you use VS Code or another editor for translation.

> If you have any questions about translation, you can open an issue for help.

## Special strings

Do NOT change any strings or words like this:

```xml
<!-- Channels Name -->
{0}
{1}
&#x000A;
PlaceHolder
```

This remarks or escape characters should be kept as original.

### Proper nouns

Products name and channels name is named by Microsoft, if possible, we should keep it same as Microsoft used.

Products and channels name can be found on Microsoft docs or Office applications.

- [Office Channels name](https://learn.microsoft.com/en-us/microsoft-365-apps/updates/overview-update-channels)

> Note: Some text may be translated by machine, and you will need to decide how to translate these proper names.

### File formats name

File extensions shoule be same as Windows or Office displayed.

To get the file formats information, you can open Office applications, create a blank document. Press <kbd>F12</kbd> to open the save dialog, then you will see a window which contains all file formats that you want.

> Also you can search it on Google.

### Programs name and processes name

Programs name can be found on Microsoft's website. You can try to search it on Google, here is some example links:

- [Office Deployment Tool](https://aka.ms/ODT)

Some processes name should be same as Windows displayed.
