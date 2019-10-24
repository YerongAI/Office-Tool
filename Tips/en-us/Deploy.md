# About Deployment

Here you can manage the currently installed Office products and language packs. If you don't have Office installed, you can do a fresh install.

You can query the version number and the release date on each channel in Version Information. After that, you can specify the version at the time of download or installation. If it's not specified, the latest version will be specified by default.

## Contents

---

1. Installation Module
2. Channel Setting
3. Fresh Install
4. Add Or Remove Products/Language Packs
5. Office 365 Product ID
6. Installation Files
7. Download Installation Files
8. Office Configuration

## Installation Module

---

Office Deployment Tool is a Microsoft official tool for deploying Office, and Office Tool Plus supports almost all of its parameter settings.
Office Tool Plus Module is a small module that we developed to install Office. Its functionality is not as powerful as the Office Deployment Tool, but it also allows Office to be installed smoothly.

[Office Deployment Tool Official Site](https://aka.ms/ODT)

[Configuration options for the Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office Customization Tool](https://config.office.com/deploymentsettings)

**If you want to install Office 2019 Volume in Windows 7, please change module to Office Tool Plus!**

`Note: When you have problems installing with the Office Deployment Tool, try the Office Tool Plus module!`

## Channel Setting

---

`Office, Visio, Project 2019 [Volume] only support the Office 2019 Perpetual Enterprise Channel, and can't be mixed with other products (Like Office 365).`
If you want to install Visio while you have Office 365 installed, choose Visio 2016 Retail/Volume or Visio 2019 Retail (Project is the same).

Office 2016/2019 [Retail]/365 can choose other channels (Except Office 2019 Perpetual Enterprise Channel). We recommend using Monthly Channel, and office workers who don't care about new features can choose Semi-Annual Channel. **If you are experiencing problems with Targeted/Insider/Dogfood Channel, please resolve them yourself.**

## Fresh Install

---

Before start, we recommend reading the Channel Setting section first.

Click [+ Add product] button and select what you want. For Office/Visio, you can uncheck unwanted apps **(Groove means OneDrive for Business, Lync means Skype for Business)**.

Click [+ Add language pack] button and select your language. If you didn't specify a language pack, Office Tool Plus will match the system language by default (If it can't be adapted, [en-us] - English (US) will be installed as the main language).

Then click [Deploy Office] button to start.

`Note: If you manually added language packs, please add at least one language pack of type [Full].`

## Add Or Remove Products/Language Packs

---

If Office is already installed on your computer, you can add or remove products/language packs through Office Tool Plus.

### Add Products/Language Packs

Just click [+ Add product] button and select what you want. 

`Note: To avoid problems, do NOT add an installed product/language pack.`

### Change Products

If you have a product with several apps installed such as Office 365, including Word, PowerPoint, Excel, Outlook, etc. If you want to uninstall an app, please select this product first, then uncheck unwanted apps, finally click the [Deploy Office] button.

### Remove Products/Language Packs

Check the products/language packs you want to uninstall in the list, then click the submenu "Uninstall selected product(s)/language pack(s)" of [Deploy Office] button to start.

## Office 365 Product ID

---

```txt
Office 365 ProPlus		O365ProPlusRetail
Office 365 Enterprise E3		O365ProPlusRetail
Office 365 Enterprise E4		O365ProPlusRetail
Office 365 Enterprise E5		O365ProPlusRetail
Office 365 Midsize		O365ProPlusRetail
Office 365 Business		O365BusinessRetail
Office 365 Business Premium	O365BusinessRetail
Office Small Business Premium	O365SmallBusPremRetail
Office 365 Home			O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

For more information, please visit [Product IDs that are supported by the Office Deployment Tool for Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## Installation Files

---

The installation files is the installation package for Office. Office Tool Plus can download Office installation files from Microsoft servers and make ISO images. After downloading the installation files, you can use offline installation or share them to others to save bandwidth or reduce time.

Click the submenu "Download installation files" of Installation Files Manage to start. You can set it up yourself or use the Office Tool Plus default settings, then click [Start] button to download.

### More Information

[Overview of update channels for Office 365 ProPlus](https://docs.microsoft.com/en-us/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Update history for Office 365 ProPlus](https://docs.microsoft.com/en-us/officeupdates/update-history-office365-proplus-by-date)

[Update channel for Office 2019](https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019)

## Download Installation Files

---

In addition to downloading installation files using Office Deployment Tool, Office Tool Plus also includes Thunder, allowing users to download Office installation files quickly. They have no difference in basic functions, `but only Thunder supports display download progress, setting speed limits, and setting proxy.` If there is a problem with Thunder download, please try to switch the engine to the Office Deployment Tool.

### Thunder Speed Limit Setting

To set the speed limit when using Thunder download, please click the download speed when downloading, and then set the speed limit in the pop-up prompt box. To cancel the speed limit, enter 0.

## Office Configuration

---

`On the right side of the deployment page, you can call out the Office Configuration panel.`
Office Tool Plus supports modifying the Office update channel and also supports modifying the owner displayed in Office. Once edited, click [Save] to apply the settings.

Also if you have a problem with Office, you can try to fix Office here.

**Note: If you click [Reload], the products and language packs list on the left will be reloaded and some settings will be reset to default.**
