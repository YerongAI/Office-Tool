# Office Tool Plus Translation Guidelines

XAML files are localized files used by Office Tool Plus. We recommend that you use VS Code or another editor for translation.

> If you have any questions about translation, you can open an issue for help.

## Special strings

Don't change any strings or words like this:

```xml
<!-- Channels Name -->
{0}
{1}
&#x000A;
```

This remarks or escape characters should be kept as original.

### Proper nouns

Products name and channels name is named by Microsoft, if possible, we should keep it same as Microsoft used.

Products and channels name can be found on Microsoft docs or Office applications.

- [Office Products name (partial)](https://docs.microsoft.com/en-us/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)
- [Office Channels name](https://docs.microsoft.com/en-us/deployoffice/overview-update-channels)
- [Office customization Tool](https://go.microsoft.com/fwlink/?linkid=854077)

> Note: Some text may be translated by machine, and you will need to decide how to translate these proper names.

### File formats name

File extensions shoule be same as Windows or Office displayed.

To get the file formats information, you can open Office applications, create a blank document. Press <kbd>F12</kbd> to save as, then you will see a window which contains all file formats that you want.

> Also you can search it on Google.

### Programs name and processes name

Programs name can be found on Microsoft's website. You can try to search it on Google, here is some example links:

- [Office Deployment Tool](https://aka.ms/ODT)

Some processes name should be same as Windows displayed.

- Software Protection: you can find it on *Start -> Windows Administrative Tools -> Services*.
- Windows Management Instrumentation: you can find it on *Start -> Windows Administrative Tools -> Services*.

## How to load and test new translation

On the latest version of Office Tool Plus, press <kbd>Ctrl + Shift + P</kbd> to open command box. Enter command `/loaddict <path to localization file>`, such as `/loaddict "D:\Test\en-us.xaml"`.

To remove the loaded resource, use command `/cldict`.
