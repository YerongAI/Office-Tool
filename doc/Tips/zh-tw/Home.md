## 嗨！歡迎使用 Office Tool Plus！

---

Office Tool Plus 是一款多功能集於一身的 Office 部署工具。

Office Tool Plus 的部分功能是基於 [Office 部署工具](https://aka.ms/ODT)和 [OSPP](https://docs.microsoft.com/zh-tw/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office) 製作，讓您能享受主控權更高的部署 Office 體驗；其內建 Thunder 下載加速模組，協助您更節省時間。亦歡迎您能夠體驗其他 Office Tool Plus 提供的各式小工具、強大的功能，使您能更方便地啟用和管理 Office 哦！

[作者部落格](https://www.coolhub.top/)

[台灣維護管理團隊 Cotpear](https://www.cotpear.com/)

[台灣維護管理團隊主頁](https://www.cotpear.com/p/office-tool-taiwan-official-website.html)

[Telegram 頻道](https://t.me/ot_channel_tw)

### Office Tool Plus 快捷键

---

- <kbd>Esc</kbd>: 回到主畫面
- <kbd>F1</kbd>: 檢視說明
- <kbd>F5</kbd>: 重新載入畫面/恢復預設設定
- <kbd>Ctrl + 1</kbd>: 切換到部署功能頁
- <kbd>Ctrl + 2</kbd>: 切換到啟用功能頁
- <kbd>Ctrl + 3</kbd>: 切換到工具箱功能頁
- <kbd>Ctrl + N</kbd>: 開啟通知畫面
- <kbd>Ctrl + T</kbd>: 開啟設定畫面
- <kbd>Ctrl + B</kbd>: 開啟關於畫面
- <kbd>Ctrl + P</kbd>: 開啟/關閉命令列
- <kbd>Ctrl + D</kbd>: 開始部署 Office (僅限部署頁面)
- <kbd>Ctrl + O</kbd>: 匯入 XML 設定文件 (僅限部署頁面)
- <kbd>Ctrl + S</kbd>: 匯出 XML 設定文件 (僅限部署頁面)
- <kbd>Ctrl + E</kbd>: 顯示 XML 設定代碼 (僅限部署頁面)

小密技：使用滑鼠的向前、向後按鈕亦可切換功能頁哦！

### Office Tool Plus 指令 (按下 Ctrl + P 開啟命令列)

---

透過 Office Tool Plus 內建的指令，即可直接呼叫自己需要的功能，達到大量設定的功效哦！`指令不區分大小寫，軟體將按照指令先後執行。`如果路徑中包含空格，請使用 "" (半形雙引號)，將路徑包括起來。

**/setImage [Path]** 手動指令背景圖片，Path: 背景圖片路徑（支援 JPG，PNG，支援本機路徑和 HTTP 位址）

**/clImage** 清除目前顯示的背景圖片

**/addProduct [ProductID]** 新增一個(多個)產品。ProductID: 產品識別碼，例如：O365ProPlusRetail 或 O365ProPlusRetail,VisioProRetail。

**/addLang [LanguageID]** 新增一個(多個)語言套件。Language ID: 語言套件識別碼，例如：zh-cn 或者 zh-cn,en-us；若輸入 ja-jp_proof 可以新增 ja-jp 的校訂套件，而不是完整的語言套件。

**/setApps [AppsID]** 設定`要安裝`的應用程式。使用半形逗號(,)分隔各個應用程式識別碼。例如：Word,Excel,PowerPoint，未設定的應用程式不會被安裝。

**/setExApps [AppsID]** 設定`不要安裝`的應用程式，使用方法同 /setApps。

**/deployArch [index]** 設定安裝架構，0 代表 32 位元，1 代表 64 位元。

**/deployChl [index]** 設定頻道，0 代表設定選項中的第一項。例如：0 為 Office 2019 永久企業版通道；3 為目前通道。

**/deployMode [index]** 設定部署模式，0 代表設定選項中的第一項。例如：0 為下載時安裝；5 為編輯設定。

**/deployModule [index]** 設定安裝模組，0 代表 Office 部署工具，1 代表 Office Tool Plus

**/setSources [Path]** 指定安裝 Office 位址，如為空則使用 Microsoft Office CDN 作為下載位址。在下載安裝檔案模式時，這個指令用於定義 Office 安裝文件儲存位置。

**/setVersion [Version]** 指定下載/安裝 Office 的版本。例如 16.0.12527.20278 版。

**/refresh** 重新載入部署功能頁中的所有數據。

**/loadChannels** 開啟隱藏的 Office 安裝頻道。（部署功能頁）

**/loadXML [Path]** 匯入 XML 設定文件，支援使用本機路徑或 HTTP 位址。

**/startDeploy** 開始部署。

**/installiSlide** 单独安装 iSlide

**/getProductKey [ProductID]** 获取产品密钥，若是批量产品，返回 GVLK，其他产品则返回默认密钥。ProductID: 产品 ID，例如：ProPlus2019Volume

**/osppILByID [ProductID]** 安裝指定的 Office 產品授權文件。ProductID: 產品識別碼，例如：MondoVolume。

**/osppinpkey:[value]** 安裝指定的 Office 金鑰。例如：/osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX。

**/osppunpkey:[value]** 移除指定的 Office 金鑰（輸入金鑰的末 5 碼）。例如：/osppunpkey:XXXXX。

**/osppsethst:[value]** 設定 KMS 伺服器位址，例如：/osppsethst:kms.example.com。

**/osppsetprt:[value]** 設定 KMS 主機連接埠，預設 1688。例如：/osppsetprt:1688。

**/osppact** 啟用 Office 客戶端產品。

還有更多的 OSPP 指令，請參考 [Microsoft OSPP 技術文件](https://docs.microsoft.com/zh-tw/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)，在 Microsoft 技術文件中提到的指令前加上 ospp，即可適用在 Office Tool Plus。

謝謝您的閱讀，祝您使用愉快。
