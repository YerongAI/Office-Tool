## 嗨！欢迎使用 Office Tool Plus

---

Office Tool Plus 是一个强大且实用的 Office 部署工具。

Office Tool Plus 基于 [Office 部署工具](https://aka.ms/ODT)和 [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office) 制作，可以很方便的部署 Office，其内置迅雷引擎可帮助您更快地下载 Office，当然，你也可以使用 Office Tool Plus 内置的各种小工具或者功能快捷、方便地激活和管理 Office 哦！

[官方博客](https://www.coolhub.top/)

[视频教程](https://space.bilibili.com/23627347)

[QQ 群](https://otp.landian.vip/zh-cn/#about)

[微信公众号（可加微信群）](https://otp.landian.vip/grouplink/wechat.html)

### Office Tool Plus 快捷键

---

- <kbd>Esc</kbd>: 返回到主页
- <kbd>F1</kbd>: 显示帮助
- <kbd>F5</kbd>: 刷新信息/重置配置
- <kbd>Ctrl + 1</kbd>: 切换到部署页面
- <kbd>Ctrl + 2</kbd>: 切换到激活页面
- <kbd>Ctrl + 3</kbd>: 切换到工具箱页面
- <kbd>Ctrl + N</kbd>: 显示通知页面
- <kbd>Ctrl + T</kbd>: 显示设置页面
- <kbd>Ctrl + B</kbd>: 显示关于页面
- <kbd>Ctrl + P</kbd>: 显示/隐藏命令行
- <kbd>Ctrl + D</kbd>: 开始部署 Office (仅限部署页面)
- <kbd>Ctrl + O</kbd>: 导入 XML 配置文件 (仅限部署页面)
- <kbd>Ctrl + S</kbd>: 导出 XML 配置文件 (仅限部署页面)
- <kbd>Ctrl + E</kbd>: 显示 XML 配置代码 (仅限部署页面)

Tip：使用鼠标的前进/后退按钮也可以切换页面哦！

### Office Tool Plus 命令 (使用 Ctrl + P)

---

通过命令可以直达自己想要的功能，也可以做到批量设置哦！`命令不区分大小写，按照输入顺序执行。`如果路径中含有空格，请使用 "" (英文双引号) 将路径包括起来。

**/setImage [Path]** 手动指定背景图，Path: 背景图路径（支持 JPG，PNG，支持本地路径以及 HTTP 路径）

**/clImage** 清除当前背景图

**/addProduct [ProductID]** 添加一个或多个产品，ProductID: 产品 ID，例如：O365ProPlusRetail 或 O365ProPlusRetail,VisioProRetail

**/addLang [LanguageID]** 添加一个或多个语言包，Language ID: 语言包 ID，例如：zh-cn 或者 zh-cn,en-us，使用 ja-jp_proof 可以添加 ja-jp 的校对工具，而不是完整的语言包

**/setApps [AppsID]** 设置`要安装`哪些应用程序，使用英文逗号分隔每个应用程序 ID，例如：Word,Excel,PowerPoint，未设置的应用程序将不会被安装

**/setExApps [AppsID]** 设置`不要安装`哪些应用程序，使用方法同 /setApps

**/deployArch [index]** 设置体系结构，0 代表 32 位，1 代表 64 位

**/deployChl [index]** 设置通道，0 代表列表中的第一项，如 0 表示 Office 2019 企业长期版通道，3 代表当前通道。

**/deployMode [index]** 设置部署模式，0 代表列表中的第一项，如 0 代表下载时安装，5 代表仅配置

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
