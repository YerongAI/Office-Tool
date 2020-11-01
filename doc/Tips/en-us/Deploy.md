## Deploy Office

---

In the page, you can manage and install Office. **Due to Microsoft's limitations, you can only install Office to your system drive.**

In applications, ***Lync*** stands for ***Skype for Business***，***Groove*** stands for ***OneDrive for Business***

To define where to save files in download mode, change the value of  ***Source path*** in ***Installation settings***.

### Contents

---

1. Deploy Mode
2. Office Update Channel
3. Deploy Module
4. More Information

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

`If you add products or language packs, Office Tool Plus will create XML configuration when creating ISO file. When users start Office Tool Plus in ISO mode, Office Tool Plus will ask the user if they want to start the installation.`

#### Download only

The mode won't start installation, download files only. Before start download, make sure you add a language pack at least.

#### Edit config only

The mode won't start installation, for exporting XML files only.

### Office Update Channel

---

`Office 2019 Perpetual Enterprise:`

For Office 2019 Volume edition only.

**No feature updates.**

**Security updates:** Once a month, on the second Tuesday of the month.

`Current Channel (Normal):`

**Feature updates:** As soon as they’re ready (usually once a month), but on no set schedule.

**Security updates:** Once a month, on the second Tuesday of the month.

`Semi-Annual Enterprise Channel:`

**Feature updates:** Twice a year (in January and July), on the second Tuesday of the month

**Security updates:** Once a month, on the second Tuesday of the month.

Note: We do not recommend using the beta channel.

### Deploy Module

---

The Office Deployment Tool is an official Microsoft tool for deploying Office.

#### Features Not Supported in Office Tool Plus Module

- Not support of log options
- Not support of Configuration Manager
- Not support of update deadline
- Not support of migrate architecture
- Not support of force update.
- Not support of remove existing MSI versions of Office
- Not support of install the same language as the previous MSI version.

Note: **For a complete installation experience, be sure to use the Office Deployment Tool.**

### More Information

---

[Office Deployment Tool Official Website](https://aka.ms/ODT)

[Configuration options for the Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[List of Product IDs which are supported by the Office Deployment Tool for Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Overview of update channels for Microsoft 365 Apps](https://docs.microsoft.com/en-us/deployoffice/overview-update-channels)

[Update history for Microsoft 365 Apps](https://docs.microsoft.com/en-us/officeupdates/update-history-microsoft365-apps-by-date)

[Update channel for Office 2019](https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019)
