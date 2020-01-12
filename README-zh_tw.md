# Office Tool Plus

[⬅ 返回](https://github.com/YerongAI/Office-Tool)

歡迎使用 Office Tool Plus ，這是一個用來管理、下載、安裝 Office 的工具。

這個應用程式是參考、使用微軟 [Office Deployment Tool](https://docs.microsoft.com/zh-tw/DeployOffice/overview-of-the-office-2016-deployment-tool) 製作的。將零散的系統指令集結成圖形化介面，讓大眾能快速直覺的部署 Office、客製化安裝 Office。

除了能夠部署 Office 之外，也能修改已安裝 Office 相關設定、移除單項產品、新增語言等。 <sup>[註一]</sup>

[註一] 僅限 `Click To Run`。

## 系統需求

 - Windows 7 SP1, Windows 8 和 Windows 10

 - Windows Server 2008 R2 SP1, Windows Server 2012 以上版本

 - **Microsoft .NET Framework 4.6.1 以上版本**

### 下載 Microsoft .NET Framework 4.6.1

 - [Web 安裝程式](http://go.microsoft.com/fwlink/?LinkId=780597)

 - [離線安裝程式](http://go.microsoft.com/fwlink/?LinkId=780601)

 - [Microsoft .Net Framework 4.6.1 語言套件 （離線安裝程式）](http://go.microsoft.com/fwlink/?LinkId=780604)

## 下載

 - [官方網站](https://otp.landian.vip/)

 - [臺灣備用官方網站](https://otp.cotpear.com/zh-tw/) <sup>[註二]</sup>

 - [備用載點](https://delivery.yuntu.dev/office-tool/) （感謝 [云图小镇](https://www.yuntu.dev/) 提供）

[註二] 由於主要官方網站伺服器於中國，在某些時刻連線不穩定，若網站無法開啟，請使用[臺灣備用官方網站](https://otp.cotpear.com/zh-tw/)。

## 微軟相關知識庫

- [自訂安裝選項說明](https://docs.microsoft.com/zh-tw/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

## 快速入門

*在開始之前，請先備妥 Office 正版授權（產品金鑰），Office Tool Plus 並沒有免費啟用 Office 的功能。*

首先，請至《部署》功能頁中，新增想要安裝的產品，然後按下「開始部署」即可開始您的安裝。另外，您也可以變更其他安裝設定，讓您的 Office 更符合您心意！

## 合法性

Office Tool Plus 使用 微軟 [Office Deployment Tool](https://docs.microsoft.com/zh-tw/DeployOffice/overview-of-the-office-2016-deployment-tool) 參考製作的，
主要是在 Office Deployment Tool 基礎上再新增了相關功能來更加便利的部署 Office。

### 關於啟用授權模組

啟用授權模組是使用微軟的 ospp.vbs (Office Software Protect Platform) 及相關檔案製作的。所有授權操作皆由 ospp.vbs 執行。

為了使用者能夠更好理解啟用時的相關內容，我們也進行了相關檔案的翻譯。（完整翻譯 zh-cn, zh-tw）

若想查詢相關檔案的操作說明，你可以在 ````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"```` 找到。（需安裝 Office）

## 感謝以下提供者及合作者

- (ar-ps) العربية (الأراضي الفلسطينية) / Ibrahim
- (de-de) Deutsch (Deutschland) / [Berny23](https://steamcommunity.com/id/Berny23)
- (en-us) English (United States) / [Moedog](https://prprpr.love)
- (es-es) Español (España, alfabetización internacional) / Xoseba
- (fr-fr) Français (France) / Drake4478
- (it-it) Italiano (Italia) / [garf02](https://github.com/garf02)
- (ja-jp) 日本語 (日本) / [秋山ヘイワ](https://github.com/akio1321)
- (ko-kr) 한국어(대한민국) / [Jay Jang](http://www.yaeyaya.com)
- (pl-pl) Polski (Polska) / JakubDriver
- (pt-br) Português (Brasil) / [Hélio de Souza](https://tinyurl.com/hdstec)
- (tr-tr) Türkçe (Türkiye) / Turan Furkan Topak
- (vi-vn) Tiêng Việt (Việt Nam) / [phuocding](https://github.com/phuocding)
- (zh-cn) 简体中文 (中国) / **官方语言 (Official language)**
- (zh-tw) 繁體中文 (台灣) / [Yi Chi](https://www.cotpear.com)

## 協助我們進行本地化工作

我們歡迎社群上的任何人協助我們進行本地化工作。若你想加入我們，請參考以下說明。

1. Fork this repository.

2. 打開任一你看得懂的語言文件（例如 ````zh-cn.xaml````），並另存新檔成你的語言代碼、對應的路徑，例如 ````OfficeToolPlus/Language/zh-tw.xaml````。

3. Make a Pull Request.

### 如何測試本地化（語言）文件

1. 下載你的語言文件到電腦中。

2. 開啟 Office Tool Plus。

3. 開啟 `設定` 功能頁，按一下 ````Load localization file````。

4. 選擇並開啟你的語言文件。

若你的本地化（語言）文件並無程式語法錯誤，Office Tool Plus 將會載入你的語言文件。在這之後，程式可能會顯示無法正常連線伺服器，這是正常的。當你正式提交相關文件後，我們將會設定相關配置。

### 本地化之後

若你願意無限期的為 Office Tool Plus 進行當地的管理，我們會授予你 Administrator Permission。你可以利用此權限，建立新公告、設定背景圖片、修改說明等。
