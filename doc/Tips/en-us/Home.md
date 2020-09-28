## Welcome

---

Office Tool Plus is a powerful and useful tool for Office deployments.

Office Tool Plus is based on [Microsoft's Office Deployment Tool](https://aka.ms/ODT) and [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office).

[Telegram group](https://otp.landian.vip/grouplink/telegram.html)

[Telegram channel](https://t.me/otp_channel)

[WeChat group](https://otp.landian.vip/grouplink/wechat.html)

### Office Tool Plus Shortcut Keys

---

- <kbd>Esc</kbd>: Back Home.
- <kbd>F1</kbd>: Help.
- <kbd>F5</kbd>: Refresh and reset Information.
- <kbd>Ctrl + 1</kbd>: Switch to deploy page.
- <kbd>Ctrl + 2</kbd>: Switch to activate page.
- <kbd>Ctrl + 3</kbd>: Switch to toolbox page.
- <kbd>Ctrl + N</kbd>: Display notification panel.
- <kbd>Ctrl + T</kbd>: Display settings panel.
- <kbd>Ctrl + B</kbd>: Display about panel.
- <kbd>Ctrl + P</kbd>: Show/Hide command box.
- <kbd>Ctrl + D</kbd>: Start deploy Office (On deploy page).
- <kbd>Ctrl + O</kbd>: Import XML confuguration (On deploy page).
- <kbd>Ctrl + S</kbd>: Export XML confuguration (On deploy page).
- <kbd>Ctrl + E</kbd>: Show XML codes (On deploy page).

Tip: You can also switch pages using the mouse forward/back button.

### Office Tool Plus Command (Ctrl + P)

---

通过命令可以直达自己想要的功能，也可以做到批量设置哦！`命令不区分大小写，按照输入顺序执行。`如果路径中含有空格，请使用 "" (英文双引号) 将路径包括起来。

**/setImage [Path]** 手动指定背景图，Path: 背景图路径（支持 JPG，PNG，支持本地路径以及 HTTP 路径）

**/clImage** 清除当前背景图

**/addProduct [ProductID]** 添加一个或多个产品，ProductID: 产品 ID，例如：O365ProPlusRetail 或 O365ProPlusRetail,VisioProRetail

**/addLang [LanguageID]** 添加一个或多个语言包，Language ID: 语言包 ID，例如：zh-cn 或者 zh-cn,en-us，使用 ja-jp_proof 可以添加 ja-jp 的校对工具，而不是完整的语言包

**/setApps [AppsID]** 设置`要安装`哪些应用程序，使用英文逗号分隔每个应用程序 ID，例如：Word,Excel,PowerPoint，未设置的应用程序将不会被安装

**/setExApps [AppsID]** 设置`不要安装`哪些应用程序，使用方法同 /setApps

**/deployArch [index]** 设置体系结构，0 代表 32 位，1 代表 64 位

**/deployChl [index]** 设置通道，0 代表 Office 2019 企业长期版通道，6 代表开发通道

**/deployMode [index]** 设置部署模式，0 代表下载时安装，5 代表仅配置

**/deployModule [index]** 设置安装模块，0 代表 Office 部署工具，1 代表 Office Tool Plus

**/setSources [Path]** 指定安装 Office 时，应从哪里取得 Office 安装文件，如果为空则使用 Office CDN 作为源，在下载模式，这个属性用于定义应将 Office 安装文件储存在哪里

**/setVersion [Version]** 指定下载/安装 Office 时，应使用哪个版本的 Office，例如 16.0.12527.20278

**/refresh** 重新加载部署页面的所有数据

**/loadChannels** 在部署页面中加载额外的通道

**/loadXML [Path]** 加载一个 XML 文件，支持本地以及 HTTP 路径

**/startDeploy** 开始部署

**/osppILByID [ProductID]** 安装指定产品的 Office 许可证， ProductID: 产品 ID，例如：MondoVolume

**/osppinpkey:[value]** 安装指定的 Office 密钥，例如：/osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** 卸载指定的 Office 密钥，例如：/osppunpkey:XXXXX

**/osppsethst:[value]** 设置 KMS 主机地址，例如：/osppsethst:kms.example.com

**/osppsetprt:[value]** 设置 KMS 主机端口，默认 1688，例如：/osppsetprt:1688

**/osppact** 激活 Office 客户端产品

其它 OSPP 参数使用方法类似，在每个命令前添加 ospp 字眼即可，OSPP 帮助文档可从[微软官方文档](https://docs.microsoft.com/zh-cn/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)取得。
