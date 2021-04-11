## Office Tool Plus 部署 Office 說明

---

在這裡，您可以管理您目前已安裝的 Office 產品和語言套件。若尚未安裝 Office，亦可以全新安裝 Office。**但由於 Microsoft 軟體限制，Office 僅限安裝在系統硬碟中**

在應用程式功能區中，***Lync*** 代表 ***Skype for Business***，***Groove*** 代表 ***OneDrive for Business***。Bing 是一个用于 Chrome 和 Edge 的扩展，若要获取更多信息，请访问 [Microsoft 必应搜索和 Microsoft 365 企业应用版](https://docs.microsoft.com/zh-tw/deployoffice/microsoft-search-bing).

而如果要在下載模式中自行設定 Office 安裝檔案的儲存路徑，請修改 ***進階設定功能區 -> 安裝設定*** 中的 ***來源位址*** 屬性。

### 目錄

---

1. 部署模式說明
2. 頻道說明
3. 安裝模組說明
4. 应用程序首选项说明
5. 附註

### 部署模式說明

---

全新安裝意旨是在一台完全沒有安裝 Office 的電腦中部署 Office；修改安裝意旨是在已有安裝 Office 的電腦上部署 Office。

修改安裝可以是新增/解除安裝產品、語言套件，亦可以是新增/移除應用程式。點選「開始部署」後，您所做的一切更動都將套用於您現有的 Office 中。

#### 下載時安裝 模式

此模式可用於全新安裝，亦可以修改目前已安裝的 Office。下載時安裝 模式僅僅會在安裝時下載所需文件，安裝完畢後即刻刪除。若您的網際網路連線狀況不佳，使用此模式時可能會耗費異常多的時間，甚至安裝失敗。`建議修改安裝時使用此模式`。

#### 下載後安裝 模式

此模式可用於全新安裝，亦可以修改目前已安裝的 Office。下載後安裝 模式會將 Office 安裝時所需的文件，完整的保留在您的電腦中。若您安裝時定義的組件較少，則完整下載會消耗額外的數據流量。`建議全新安裝時使用此模式`。

#### 使用已下載的安裝檔案安裝

此模式可用於全新安裝，亦可以修改目前已安裝的 Office。使用此模式時。您必須設定 Office 安裝檔案中其中一個 CAB 文件（任選一個），Office ISO 檔案須先掛載或是解壓縮後才能檢視 CAB 文件。如果您選擇此功能，但無設定安裝文件，Office Tool Plus 將會在部署時預設使用**下載時安裝**模式。

#### 建立 ISO 檔案

*使用此模式時，您必須將已下載的 Office 安裝檔案儲存於與 Office Tool Plus 相同路徑的位址。*

你可以创建一个带默认部署设置的 ISO，要这样做，请确保你在创建 ISO 前配置了 Office 的安装，例如添加产品和语言。然后点击 “开始部署” 以创建 ISO 文件。

当用户在 ISO 模式下启动 Office Tool Plus 时，程序将会载入默认配置并询问用户是否开始安装 Office.

如果你没有进行任何配置，则用户需要手动配置 Office 的安装，如同我们大多数人使用的那样。

#### 下載安裝檔案

此模式僅會下載 Office 安裝文件，不會進行 Office 的安裝部署。

`使用此模式時，至少新增一個語言套件。否則下載可能會缺失某些檔案。`

#### 編輯設定

此模式僅用於編輯部署設定，並匯出部署設定（.XML 檔案）而已。不會檢測目前電腦上的 Office 安裝狀態，亦不會對已安裝的 Office 進行任何變更。

### 頻道說明

---

`Office 2019 永久企業版：`

Office 2019 大量授權版的專屬頻道。

**功能更新：** 無

**安全性更新：** 每個月一次更新，預計在每個月的第二個星期二。

`目前通道（預設）：`

**功能更新：** 在新功能就緒後，即會推送更新（約每個月一次），無特定計畫。

**安全性更新：** 每個月一次，預計在每個月的第二個星期二。

`半年通道：`

**功能更新：** 每年兩次更新（一月和七月），預計在當月的第二個星期二。

**安全性更新：** 每個月一次，預計在每個月的第二個星期二。

注意！我們不推薦任何人使用預覽性質的頻道，如要瞭解更多說明，請檢視本說明文件的文末，查看 Microsoft 的詳細說明。

### 安裝模組說明

---

Office 部署工具是 Microsoft 發布的，用於進階部署 Office 的工具。

Office Tool Plus 模組是我們自行編寫的安裝模組。雖然功能沒有 Office 部署工具的全面，但也是可以用於基礎安裝 Office。

#### Office Tool Plus 模組不支援的功能

- 不支援記錄檔設定
- 不支援設定預設管理器
- 不支援設定更新截止時間
- 不支援變更架構
- 不支援強制更新
- 不支援移除電腦中的 MSI 版本的 Office
- 不支援自動安裝與先前 MSI 版本相同的語言
- 不支持将首选项应用于 Office 应用程序

注意：**若想享完整的安裝體驗，請務必使用 Office 部署工具。**

### 应用程序首选项说明

---

`应用程序首选项由微软提供数据，其文本均为机器翻译，可能存在某些语法错误，请以英文版本的为准。`

应用程序首选项使你可以在部署 Office 前进行 Office 的设置，包括 VBA 宏通知、默认文件位置和默认文件格式。

除此之外，你还可以将应用程序首选项应用到现有的 Office 中，配置完毕后，在 *查看 XML 代码* 的子菜单中选择 *将首选项应用于 Office 应用程序* 即可，Office 部署程序会自动应用设置。

您所定义的应用程序首选项将应用于设备的所有现有用户以及未来添加到该设备的任何新用户。如果在 Office 应用程序运行时应用首选项，则新的设置将在 Office 下次运行时生效。

### 附註：取得更多資訊，請訪問以下網站

---

[Office 部署工具官方網站](https://aka.ms/ODT)

[Office 部署工具的設定選項](https://docs.microsoft.com/zh-tw/deployoffice/office-deployment-tool-configuration-options)

[隨選即用的 Office 部署工具支援的產品 ID 清單](https://docs.microsoft.com/zh-tw/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Microsoft 365 Apps 更新通道的概觀](https://docs.microsoft.com/zh-tw/deployoffice/overview-update-channels)

[Microsoft 365 Apps 的更新歷程記錄 (依日期列出)](https://docs.microsoft.com/zh-tw/officeupdates/update-history-microsoft365-apps-by-date)

[Office 2019 的更新通道](https://docs.microsoft.com/zh-tw/DeployOffice/office2019/update#update-channel-for-office-2019)
