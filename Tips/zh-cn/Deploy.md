# 部署 Office 说明

在这里，您可以管理当前已安装的 Office 产品和语言包。如果没有安装 Office，则可以进行全新安装。**由于微软限制，Office 仅可以安装在系统盘上。**

您可以在版本信息中查询当前每个通道上 Office 发布的版本以及发布日期。查询完毕后，您可以在下载或者安装时选择历史版本。默认安装最新版本。

## 目录

---

1. 安装模块说明
2. 通道设置说明
3. 全新安装说明
4. 增删产品/语言说明
5. Office 365 产品 ID 对照表
6. 安装文件说明
7. Office 配置说明

## 安装模块说明

---

Office 部署工具是微软官方发布的一个用于部署 Office 的工具，其中 Office Tool Plus 几乎支持其所有的参数设定。
Office Tool Plus 模块是我们自行编写的一个安装 Office 的小模块，虽然功能没有 Office 部署工具的全面，但是也可以确保 Office 可以顺利安装。

### Office Tool Plus 模块中不支持的功能

- 不支持安装完成后添加任务栏快捷方式
- 不支持记录日志也不支持日志选项设置
- 不支持设置配置管理器
- 不支持设置更新截止时间
- 不支持迁移体系结构
- 不支持强制更新
- 不支持移除现有的 MSI 版本的 Office
- 不支持安装与先前 MSI 版本相同的语言

若要获得完整的安装体验，请务必使用 Office 部署工具。

[Office 部署工具官方网站](https://aka.ms/ODT)

[Office 部署工具的配置选项](https://docs.microsoft.com/zh-cn/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office 自定义工具](https://config.office.com)

**欲从 Windows 7 上安装 Office 2019 批量版，请务必使用 Office Tool Plus 模块！**

`当您使用 Office 部署工具安装时遇到无法解决的问题，不妨试一下 Office Tool Plus 安装模块哦！`

## 通道设置说明

---

`Office, Visio, Project 2019 批量版产品只支持安装在 Office 2019 企业长期版通道上，并且不可以与其他产品混装（比如 Office 365）`。
如果在安装了 Office 365 的同时也想使用 Visio 的话，请选择 Visio 2016 零售版或 2016 批量版（Project 同理）。

Office 2016/2019 (零售)/365 产品可以选择其他的通道（只要不是 Office 2019 企业长期版就完事了），推荐使用每月通道，不在乎新功能的办公人士可以选择半年通道。**如果您因为使用定向通道或者测试版通道而遇到 Office 出现问题的情况，请自行解决。**

## 全新安装说明

---

全新安装时，点击添加产品，选择一个自己想安装的产品。产品里可能会包含一个或者多个应用程序，如果您不希望安装这些应用程序，请将其取消勾选。**其中，Groove 代表 OneDrive for Business，Lync 代表 Skype for Business。**

全新安装时，如果不指定语言包，则 Office Tool Plus 会默认匹配系统语言。如果 Office 不能完全适配当前系统的语言，则会默认加装 [en-us] - English (US) 作为主要语言。
`当您添加语言时，请确保您选择了一个主要语言。`

全新安装时，**若您选择的是 Office 2019 批量版产品，请确保您的通道是 Office 2019 企业长期版通道，否则会无法正常安装！**Office 2019 零售版可以选择其他通道。

## 增删产品/语言说明

---

当您的计算机上已经安装 Office 时，您可以通过 Office Tool Plus 增删产品。

### 增加产品/语言

如果您需要增加产品或者语言，直接新增产品/语言，并按照自己的想法/要求直接选择即可。`注意：为了避免出现问题，请不要添加已安装的产品/语言。`

### 修改应用程序

如果您需要修改应用程序，请首先选中这个产品，然后将不需要的应用程序取消勾选，将需要添加的选上，然后开始部署即可。

### 卸载产品/语言

在列表中，勾选自己想卸载的产品/语言，随后通过开始部署按钮右侧的菜单，点击 *卸载选中的产品/语言* 即可。

## Office 365 产品 ID 对照表

---

```txt
Office 365 专业增强版	O365ProPlusRetail
Office 365 企业版 E3	O365ProPlusRetail
Office 365 企业版 E4	O365ProPlusRetail
Office 365 企业版 E5	O365ProPlusRetail
Office 365 中型		O365ProPlusRetail
Office 365 商业版	O365BusinessRetail
Office 365 商业高级版	O365BusinessRetail
Office 小型企业高级版	O365SmallBusPremRetail
Office 365 家庭版	O365HomePremRetail
Office 365 个人版	O365HomePremRetail
```

获取更多信息请访问 [Office 部署工具支持的产品 ID](https://docs.microsoft.com/zh-cn/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## 安装文件说明

---

安装文件，顾名思义就是 Office 的安装包。Office Tool Plus 支持从微软的 Office CDN 服务器下载 Office 安装文件并制作成 ISO 文件。下载安装文件后，可以使用离线安装，也可以分享安装文件给其他用户，以便节省带宽或者减少时间耗费。

安装文件包含 Office, Visio 以及 Project，从 Office 2019 企业长期版通道下载的安装文件仅可以用来安装 Office 2019 批量版，其他通道的安装文件可以用于安装 Office 2016, 365 以及 2019 零售版。

若要下载 Office 安装文件，请根据自己的需要配置体系架构，通道，语言默认匹配系统语言。Office Tool Plus 默认设置好，您可以直接开始下载安装文件。

![下载安装文件](https://server.coolhub.top/OfficeTool/images/zh-cn/DownloadPanel.png)

### 获取更多信息请访问以下网站

[Office 365 的更新通道概述](https://docs.microsoft.com/zh-cn/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Office 365 更新历史记录](https://docs.microsoft.com/zh-cn/officeupdates/update-history-office365-proplus-by-date)

[Office 2019 更新频道概述](https://docs.microsoft.com/zh-cn/DeployOffice/office2019/update#update-channel-for-office-2019)

## 下载安装文件

---

Office Tool Plus 除了支持使用 Office 部署工具下载安装文件外，还内置了迅雷程序，使用 HTTP 协议帮助用户快速下载 Office 安装文件。两者在功能上基本没有什么区别，`但仅有迅雷支持显示下载进度，支持设定速度限制以及支持单独设置代理。`如果迅雷下载出现了问题，请将引擎切换为 Office 部署工具。

### 迅雷下载限速设置

若要在使用迅雷下载时设置速度限制，请在下载时点击下载速度，随后即可在弹出来的提示框中设定限速。若要解除限速，请输入 0。

## Office 配置说明

---

`在部署页面的最右侧，可以呼出 Office 配置面板。`
Office Tool Plus 支持对 Office 的更新通道进行修改，也支持修改 Office 中显示的账户所有者。修改之后，点击保存以应用设置。

如果您的 Office 无法正常使用，可以在此处尝试修复 Office。

**Note：如果你点击了重新读取，左侧的产品和语言数据会重新载入，一些设置将会被重置为默认值。当右键点击时，所有信息将会被清空且不再自动读取，适用于创建 ISO 时配置信息。**
