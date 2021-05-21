## Deploy Office

---

In the page, you can manage and install Office. **Due to Microsoft's limitations, you can only install Office to your system drive.**

In applications, ***Lync*** stands for ***Skype for Business***，***Groove*** stands for ***OneDrive for Business***.

Bing is a extension for Chrome and Edge etc. For more information, visit [Microsoft Search in Bing and Microsoft 365 Apps for enterprise](https://docs.microsoft.com/en-us/deployoffice/microsoft-search-bing).

To define where to save files in download mode, change the value of  ***Source path*** in ***Installation settings***.

### Contents

---

1. Products
2. Languages
3. Update Channel
4. Deploy Mode
5. Deploy Module
6. Applications Preferences
7. More Information

### Products

---

Defines which products to download or install. The first product determines the context for the Microsoft Office First Run Experience.

### Languages

---

When no language is added, the Office language will be set to match system language.

In download mode, the language pack will not be downloaded if no language is added.

If you define multiple languages, the first language determines the Shell UI culture, including shortcuts, right-click context menus, and tooltips.

If you decide that you want to change the Shell UI language after an initial installation, you have to uninstall and reinstall Office.

### Update Channel

---

`Office 2019 Perpetual Enterprise:`

For Office 2019 Volume products only.

**No feature updates.**

**Security updates:** Once a month, on the second Tuesday of the month.

`Office 2021 Perpetual Enterprise (upcoming):`

For Office 2021 Volume products only.

**You must use Office Tool Plus module to install Office 2021 products at this time.**

**No feature updates.**

**Security updates:** Once a month, on the second Tuesday of the month.

`Current Channel (Normal):`

**Feature updates:** As soon as they’re ready (usually once a month), but on no set schedule.

**Security updates:** Once a month, on the second Tuesday of the month.

`Semi-Annual Enterprise Channel:`

**Feature updates:** Twice a year (in January and July), on the second Tuesday of the month

**Security updates:** Once a month, on the second Tuesday of the month.

Note: We do not recommend using the beta channel.

### Deploy Mode

---

Fresh install is means to install Office on a machine which have never install before.

On the other hand, you can add products, or language packs to your exist Office installation. Add or remove applications from Office suite.

#### Install while downloading

*Download required files only. Fewer data used.*

We recommend you to use it when changing a exist Office installation.

If you have a bad Internet connection, this will take a lot of time.

#### Install after download

*Download all files.*

We recommend you to use it when install Office on a new machine.

#### Use an existing installation source

To use it, you need to choose any of the CAB files. If not, we will fallback to *Install while downloading*.

If you are using an ISO file, you need to mount it first and then select the CAB file.

#### Create ISO file

*Requires Office installation files stored in the Office Tool Plus directory.* If not, please download Office installation files first.

You can create an ISO file with default settings. To do so, configure Office installation, such as adding products and languages, then click "Start deploy" to begin creating ISO file.

If you do not configuration, the user will need to configure it as if it were used normally.

#### Download only

The mode won't start installation, download files only. Before start download, make sure you add a language pack at least.

#### Edit config only

The mode won't start installation, for exporting XML files only.

### Deploy Module

---

The Office Deployment Tool is an official Microsoft tool for deploying Office.

#### Features Not Supported in Office Tool Plus Module

- Not support of Configuration Manager
- Not support of update deadline
- Not support of migrate architecture
- Not support of force update.
- Not support of remove existing MSI versions of Office
- Not support of install the same language as the previous MSI version.
- Not support of Office applications preferences.

Note: **For a complete installation experience, be sure to use the Office Deployment Tool.**

### Applications Preferences

---

`Application preferences are data provided by Microsoft, these texts are machine translated and may contain some grammatical errors.`

The function allow you defines application preferences for Office Apps, including VBA Macro notifications, default file locations, and default file format.

You can apply new application preferences to client computers that already have Office installed. Click "Applying preferences for Office applications" in the "View XML code" submenu.

The app preferences are applied to all existing users of the device and any new users added to the device in the future. If you apply application preferences when Office apps are running, the preferences will be applied when Office is next restarted.

### More Information

---

[Office Deployment Tool Official Website](https://aka.ms/ODT)

[Configuration options for the Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[List of Product IDs which are supported by the Office Deployment Tool for Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Overview of update channels for Microsoft 365 Apps](https://docs.microsoft.com/en-us/deployoffice/overview-update-channels)

[Update history for Microsoft 365 Apps](https://docs.microsoft.com/en-us/officeupdates/update-history-microsoft365-apps-by-date)

[Update channel for Office 2019](https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019)
