# Office Tool Plus Translation Guidelines

XAML files are localized files used by Office Tool Plus. We recommend that you use VS Code or another editor for translation.

> If you have any questions about translation, you can open an issue for help.

## Special strings

### TO DO Remarks

For better working, I will add some to do marks. Search "TO DO" on files to find out what needs to be processed.

```xml
<!-- TO DO: Translate -->
<sys:String x:Key="Menu">Menu</sys:String>
```

**After TO DO is done, you need to remove the remarks:**

```xml
<sys:String x:Key="Menu">菜单</sys:String>
```

### Others

Don't change any strings or words like this:

```xml
<!-- Channels Name -->
{0}
{1}
&#x000A;
```

This remarks or escape characters should be kept as original.

## Proper nouns

Products name and channels name is named by Microsoft, if possible, we should keep it same as Microsoft used.

Products and channels name can be found on Microsoft docs or Office applications.

- [Office Products name (partial)](https://docs.microsoft.com/en-us/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)
- [Office Channels name](https://docs.microsoft.com/en-us/deployoffice/overview-update-channels)
- [Office customization Tool](https://go.microsoft.com/fwlink/?linkid=854077)

> Note: Some text may be translated by machine, and you will need to decide how to translate these proper names.

## Error codes

There will be some error codes here, such as:

```xml
<sys:String x:Key="ToolboxResetSPPSvcDescription">This will reset the configuration of Software Protection service. Applies to "Server execution failed (0x80080005)" when activating Office.</sys:String>
```

We recommend using the Microsoft translation as a reference and then making further optimizations and changes where possible.

To get the error code description in your language, you can open `CMD` or `PowerShell` and run the following command:

```batch
slui 0x2a <errorCode>

-› slui 0x2a 0x80080005
```

> Also, you can query error code description in the Office Tool Plus toolbox.

## File formats name

File extensions shoule be same as Windows or Office displayed.

To get the file formats information, you can open Office applications, create a blank document. Then press F12 to save as, then you will see a window which contains all file formats that you want.

> Also you can search it on Google.

## Programs name and processes name

Programs name can be found on Microsoft's website. You can try to search it on Google, here is some example links:

- [Office Deployment Tool](https://aka.ms/ODT)

Some processes name should be same as Windows diaplayed.

- Software Protection: you can find it on *Start -> Windows Administrative Tools -> Services*.
- Windows Management Instrumentation: you can find it on *Start -> Windows Administrative Tools -> Services*.
