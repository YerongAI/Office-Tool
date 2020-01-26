本功能頁所提供的功能是部署 Office，讓您能便利的管理 Office 各項隱藏設定。若您尚未安裝 Office，也可以進行全新安裝。

*如果需要相關繁體中文文章教學，請至  [Cotpear Office Tool 目錄](https://www.cotpear.com/p/office-tool-taiwan-official-website.html)，尋找你需要的說明。*

## 主要功能說明

1. 全新安裝 Office
2. 查詢版本資訊
3. 安裝模組
4. 變更產品、語言
5. Office 365 各項產品識別碼對照表
6. 下載安裝文件
7. Office 設定（管理設定）

## 全新安裝 Office

在部署全新安裝時，請在左側介面中，點選「新增產品」，點選後即會看到選擇產品欄，請選擇您想要安裝的產品名稱。另外，由於 Microsoft 的關係，Office 無法修改安裝位址。**請注意，某些產品名稱是一樣的，但識別碼是不同的，請再三確認。**
如果您不希望安裝產品中的某項應用程式，請在選擇欄位下方將該應用程式取消勾選。
**另外，Groove 代表 OneDrive for Business，Lync 代表 Skype for Business。**

`請注意：若您安裝的產品是 Office 2019 大量授權版，請確保您選取的頻道為 Office 2019 永久企業版，否則安裝將會失敗。（其他產品不受限此限制）`

### 選擇安裝語言

在部署全新安裝時，Office Tool Plus 會自動讀取您電腦的使用語言，並使用該語言為 Office 進行安裝。若 Office 完全不支援您電腦的使用語言，Office Tool Plus 將會以 [en-us] - English (US) 作為安裝語言。
若您想要安裝其他語言，請在右側介面中點選「新增語言套件」，並在隨後顯示的畫面中選擇語言（`新增的語言套件類型至少需要一個是選擇「完整」，否則安裝可能會失敗`）。

### 頻道設定

Office 2019, Visio 2019, Project 2019 大量授權版產品僅可以安裝《Office 2019 長期企業版》頻道，並且不可以與其他產品同時存在（安裝）。（其他版本不受限）
如果安裝了 Office 365，也同時想使用 Visio 的話，請選擇 Visio 2016 一般販售版或大量授權版。（Project  同）

若您不在意 Office 每次更新帶來的新功能，建議您選擇半年通道，除此之外，我們推薦您使用每月通道。
**另外，如果您因為使用了任何測試版通道而遭遇 Office 錯誤，請自行承擔。 **

## 查詢版本資訊

您可以點選《版本資訊》中的「查詢版本編號」來查詢各個頻道中的 Office 版本、Office 發布日期。查閱完畢後，您可以在下載安裝文件、安裝 Office 時設定指定版本（預設設定最新版本）。

## 安裝模組
---

Office Tool Plus 提供了多樣式的安裝模組，提供您不同的安裝需求。

### Office 部署工具

Office 部署工具是微軟給予企業部署的工具，Office Tool Plus 大多的功能都是依靠此工具來編寫的。

### Office Tool Plus

Office Tool Plus 模組是我們自己所編寫的小模組，其目的是為了略過 Office 部署工具的某些限制。雖然功能沒有像 Office 部署工具那麼全面，但也可以使 Office 能正常安裝。

**如果您要在 Windows 7 上安裝 Office 2019 大量授權版，請務必使用 Office Tool Plus 模組！**

#### Office Tool Plus 模組中不支援的功能

- 不支援安裝完成後新增工具列捷徑
- 不支援記錄功能（及選項設定）
- 不支援設定管理器
- 不支援設定更新截止時間
- 不支援變更架構
- 不支援強制更新
- 不支援移除現有的 MSI 版本的 Office
- 不支援安裝與先前 MSI 版本的相同的語言

---

當您在使用 Office 部署工具時遭到問題，也不妨使用 Office Tool Plus 模組嘗試安裝喔！

[Office 部署工具概觀↗](https://aka.ms/ODT)

[Office 部署工具的設定選項↗](https://docs.microsoft.com/zh-tw/DeployOffice/configuration-options-for-the-office-2016-deployment-tool#product-element)

[Office 部署設定工具↗](https://config.office.com)


## 變更產品、語言

當您的電腦中已安裝 Office，則您就可以使用 Office Tool Plus 來新增或移除產品。

### 新增產品、語言

如果您需要多個產品或語言，請直接在該功能區點選「新增」，依照您的想法設定該視窗所顯示的內容即可。`請注意：為了避免發生錯誤，請不要重複安裝任何產品、語言。`

### 修改產品（應用程式）

如果您安裝了包含數個應用程式的產品（例如 Office 365，包含了 Word, PowerPoint, Excel, Outlook  等產品），當您需要解除安裝某個應用程式，請先選取該產品，再取消選取該應用程式，然後點選「開始部署」即可。

### 移除產品、語言套件

勾選您想解除安裝的產品或語言，再點選「開始部署」按鈕旁的「更多功能」（下三角形）按鈕，點選「解除安裝已選取的產品/語言」即可。

## Office 365 各項產品識別碼對照表

```
Office 365 專業增強版	O365ProPlusRetail
Office 365 企業版 E3	O365ProPlusRetail
Office 365 企業版 E4	O365ProPlusRetail
Office 365 企業版 E5	O365ProPlusRetail
Office 365 中型企業版	O365ProPlusRetail
Office 365 商務版	O365BusinessRetail
Office 365 商務進階版	O365BusinessRetail
Office 365 商務基本版	O365SmallBusPremRetail
Office 365 家庭版	O365HomePremRetail
Office 365 個人版	O365HomePremRetail
```

更多資訊請查看 [隨選即用的 Office 部署工具所支援的產品識別碼↗](https://docs.microsoft.com/zh-tw/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## 下載安裝文件

在這項功能裡，我們提供下載 Office 的離線安裝檔，連線 Microsoft Office CDN 伺服器下載安裝文件。您可以在下載之後將檔案製作成 ISO 映像檔、分享給其他人，節省數據消耗及時間。

### 如何下載？

請點選介面右側《安裝文件管理》中的「選擇檔案」按鈕旁的「更多功能」（下三角形）按鈕，再點選「下載安裝文件」。點選後即會看到相關設定，請依照您的想法設定下載內容（頻道、架構、語言等）。Office Tool Plus 已預設下載您電腦使用的語言，

![下載安裝文件說明圖](https://server.coolhub.top/otp/config/zh-tw/img/下載安裝文件說明圖.png)

### 下載引擎

Office Tool Plus 除了支援《Office 部署工具》下載安裝檔案之外，我們也有提供《迅雷》下載引擎，加快下載速度。這兩種下載引擎並沒有多大的差別，但《Office 部署工具》下載時**不會顯示下載進度**、**不支援下載限速**、**設定代理**。`請注意：如果《迅雷》引擎在下載時發生問題，請嘗試使用《Office 部署工具》進行下載。`

#### 設定迅雷限速

若要在迅雷下載時設定限速，請在點選「開始」後，在下載進度條的正下方，點選速度數字，即會顯示限速設定，請依您的需求設置。若要解除限速，輸入 0 即可。

![設定迅雷限速說明圖](https://server.coolhub.top/otp/config/zh-tw/img/限速說明圖.png)

### 更多資訊請查看以下網站

[Office 365 專業增強版更新通道的概觀↗](https://docs.microsoft.com/zh-tw/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Office 365 專業增強版的更新歷程記錄↗](https://docs.microsoft.com/zh-tw/officeupdates/update-history-office365-proplus-by-date)

[Office 2019 的更新通道↗](https://docs.microsoft.com/zh-cn/DeployOffice/office2019/update#update-channel-for-office-2019)

## Office 設定（管理設定）

在這項功能裡，我們提供對《Office 更新頻道》進行修改、修改 Office 帳戶所有者、修復 Office，結束修改後請記得儲存。

*提醒您：如果您點選了「重新讀取」，部署功能頁所有的 Office 資料將會重新載入。某些設定會重置為預設值。*

### 如何開啟功能表

請將鼠標移動到部署功能頁的最右側，即可顯示 Office 管理設定。（鼠標移動至下方說明圖的所圈畫的紅色框框中）

![Office 設定（管理設定）說明圖](https://server.coolhub.top/otp/config/zh-tw/img/Office 設定（管理設定）說明圖.png)

### 重新讀取

當您`左鍵`點選「重新讀取」後，功能頁中的所有數據將會重新載入，某些設定將會被**重設為預設值**；當您`右鍵`「重新讀取」後，功能頁中的所有數據將會**清空且不再自動讀取**，這個功能常用於建立 ISO 檔案時使用。
