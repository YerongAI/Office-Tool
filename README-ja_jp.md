# Office Tool Plus

[⬅ 戻る](https://github.com/YerongAI/Office-Tool)

Office Tool Plusは、Officeを管理、ダウンロード、インストールするための小さなツールボックスです。

Office Tool Plusは、MicrosoftのOffice 展開ツール[ODT]に基づいています(https://docs.microsoft.com/ja-jp/DeployOffice/overview-of-the-office-2016-deployment-tool)、Office Tool Plusを使用すると、Officeの迅速な展開、Office展開のカスタマイズ、インストールするもの、インストールしないものをセットアップできます。

さらに、Office Tool Plusを使用して、インストールされたOfficeの管理（Click To Runベースのみ）、構成の変更、個々の製品のアンインストール、または言語パックの追加を行うことができます。

## システム要求

Windows 7 SP1、Windows 8 と Windows 10。

Windows Server 2008 R2 SP1、Windows Server 2012以降。

`Microsoft .NET Framework 4.6.1以降`

### ダウンロード Microsoft .NET Framework 4.6.1

[オンラインインストーラー](http://go.microsoft.com/fwlink/?LinkId=780597)

[オフラインインストーラー](http://go.microsoft.com/fwlink/?LinkId=780601)

[Microsoft .Net Framework 4.6.1 言語パック](http://go.microsoft.com/fwlink/?LinkId=780604)

## ダウンロード Office Tool Plus

[公式サイト](https://otp.landian.vip/)

[バックアップサイト](https://delivery.yuntu.dev/office-tool/) by [Yuntu](https://www.yuntu.dev/)

## 技術資料

[構成オプションの説明](https://docs.microsoft.com/ja-jp/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

## クイックスタート

最初にインストールファイルをダウンロードしてから、オフラインでインストールすることをお勧めします。 これにより、ネットワークの状態によるエラーが防止されます。

Officeをインストールするには、展開ページに移動し、インストールする製品とアプリケーションを追加して、展開を開始します。 必要に応じて、他の設定を変更できます。

インストールが完了したら、有効なライセンスでOfficeをアクティブ化する必要があります。

## アプリケーションの正当性

Office Tool Plusは、MicrosoftのOffice 展開ツール[ODT]に基づいています(https://docs.microsoft.com/ja-jp/DeployOffice/overview-of-the-office-2016-deployment-tool)、上記の内容に基づいて、いくつかのアクセス可能な機能を追加して、より簡単に使用できるようにしました。

### アクティベーションについて

アクティベーションモジュールは、Microsoftのospp.vbs（Office Software Protect Platform）に基づいています。 すべてのアクティベーションは、ospp.vbsによって実行されます。

OSPPの操作手順は````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"````で確認できます（Officeのインストールが必要です）。

## ユーザーインターフェイスの翻訳者に感謝

- (ar-ps) العربية (الأراضي الفلسطينية) / Ibrahim
- (de-de) Deutsch (Deutschland) / [Berny23](https://steamcommunity.com/id/Berny23)
- (en-us) English (United States) / [Moedog](https://prprpr.love)
- (es-es) Español (España, alfabetización internacional) / Xoseba
- (fr-fr) Français (France) / Drake4478
- (id-id) Bahasa Indonesia (Indonesian) / [Ida Bagus Anom Sanjaya](https://fb.me/Anom.Sanjaya17)
- (it-it) Italiano (Italia) / [garf02](https://github.com/garf02)
- (ja-jp) 日本語 (日本) / [秋山ヘイワ](https://github.com/akio1321)
- (ko-kr) 한국어(대한민국) / [Jay Jang](http://www.yaeyaya.com)
- (pl-pl) Polski (Polska) / JakubDriver
- (pt-br) Português (Brasil) / [Hélio de Souza](https://tinyurl.com/hdstec)
- (tr-tr) Türkçe (Türkiye) / Turan Furkan Topak
- (vi-vn) Tiêng Việt (Việt Nam) / [phuocding](https://github.com/phuocding)
- (zh-cn) 简体中文 (中国) / **官方语言 (Official language)**
- (zh-tw) 繁體中文 (台灣) / [Yi Chi](https://www.cotpear.com)

## Help With Localization

We encourage everyone to help with localization. The following is how to do.

1. Fork this repository

2. Translate ````ja-jp.xaml```` to your own language then save it like ````ja-jp.xaml````

3. Copy it to the right path, like OfficeToolPlus/Language/ja-jp.xaml

4. Make a Pull Request.

### How To Test Your Translation

1. Save your translation file to a path, like ````D:\Date\ja-jp.xaml````.

2. Open application.

3. Go to settings page, click ````Load localization file.````

4. Select the file that you just saved.

After that, application will load your translation, if you are adding a new translation to application, it will show: failed to connect to server. It's normal.

### What is More

````For each translator, we will give them an Admin app that allows you to change the announcement and upload a background image.```` [Send a e-mail](mailto:yerong@coolhub.top) ````to us.````
