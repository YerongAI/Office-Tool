# 部署 Office 说明

---

在这里，您可以管理当前已安装的 Office 产品和语言包。如果没有安装 Office，则可以进行全新安装。**由于微软限制，Office 仅可以安装在系统盘上。**

应用程序中，***Lync*** 代表 ***Skype for Business***，***Groove*** 代表 ***OneDrive for Business***.

Bing 是一个用于 Chrome 和 Edge 的扩展，若要获取更多信息，请访问 [Microsoft 必应搜索和 Microsoft 365 企业应用版](https://docs.microsoft.com/zh-cn/deployoffice/microsoft-search-bing).

若要在下载模式中自定义 Office 安装文件保存路径，请修改 ***安装设置 - 源路径*** 属性。

## 目录

---

1. 产品说明
2. 语言说明
3. 通道说明
4. 部署模式说明
5. 安装模块说明
6. 应用程序首选项说明
7. 更多信息

## 产品说明

---

决定需要下载或者安装的产品。第一个产品决定了 Microsoft Office 首次运行体验上下文。

## 语言说明

---

当你没有添加语言时，Office 语言将会被设置为匹配系统语言。我们建议你设置 *高级设置 - 安装设置 - 备用语言* 以便处理特殊情况。

在下载模式，如果你没有添加语言，则不会下载语言包。

如果你添加了多个语言，第一个语言将决定 Shell UI 语言，包括快捷方式、右键菜单以及提示文本。

如果你决定在安装后更改 Shell UI 语言，你必须卸载并重新安装 Office.

## 通道说明

---

`Office 2019 企业长期版：`

Office 2019 批量版的专属通道。

**功能更新：** 无

**安全更新：** 每个月一次，在每个月的第二个星期二

`Office 2021 企业长期版：`

Office 2021 批量版的专属通道。

**功能更新：** 无

**安全更新：** 每个月一次，在每个月的第二个星期二

`当前通道（默认）：`

**功能更新：** 新功能就绪后立即推送更新（大概每个月一次），无特定计划

**安全更新：** 每个月一次，在每个月的第二个星期二

`半年通道：`

**功能更新：** 每年两次（一月和七月），每个月的第二个星期二

**安全更新：** 每个月一次，在每个月的第二个星期二

注意：我们不推荐任何人使用预览性质的通道！若要获取更详细的信息，请导航至末尾的链接查看微软官方的详细解释。

## 部署模式说明

---

### 配置

此模式仅用于配置并生成 XML 文件。不会检查当前计算机上的 Office 也不会进行任何修改。

### 下载

此模式仅下载 Office 安装文件，不会进行 Office 的部署。
`使用此模式时，至少要添加一个语言包，否则下载可能会不完整。`

### 安装

此模式可用于安装、卸载、修改 Office.

对于全新安装，我们建议你勾选“下载后安装”。

如果你的网络状况不佳，这可能耗费额外的时间。

### 创建 ISO 文件

*创建 ISO 文件要求已下载 Office 安装文件，并且 Office 安装文件与 Office Tool Plus 同目录。*

你可以创建一个带默认部署设置的 ISO，要这样做，请确保你在创建 ISO 前配置了 Office 的安装，例如添加产品和语言。然后点击 “开始部署” 以创建 ISO 文件。

当用户在 ISO 模式下启动 Office Tool Plus 时，程序将会载入默认配置并询问用户是否开始安装 Office.

如果你没有进行任何配置，则用户需要手动配置 Office 的安装，如同我们大多数人使用的那样。

## 安装模块说明

---

Office 部署工具是微软官方发布的一个用于部署 Office 的工具。

Office Tool Plus 模块是我们自行编写的安装模块，虽然功能没有 Office 部署工具的全面，但是也可以用于安装 Office

### Office Tool Plus 模块中不支持的功能

- 不支持设置配置管理器
- 不支持设置更新截止时间
- 不支持迁移体系结构
- 不支持强制更新
- 不支持移除现有的 MSI 版本的 Office
- 不支持安装与先前 MSI 版本相同的语言
- 不支持将首选项应用于 Office 应用程序

注意：**若要获得完整的安装体验，请务必使用 Office 部署工具。**

## 应用程序首选项说明

---

`应用程序首选项由微软提供数据，其文本均为机器翻译，可能存在某些语法错误，请以英文版本的为准。`

应用程序首选项使你可以在部署 Office 前进行 Office 的设置，包括 VBA 宏通知、默认文件位置和默认文件格式。

除此之外，你还可以将应用程序首选项应用到现有的 Office 中，配置完毕后，在 *查看 XML 代码* 的子菜单中选择 *将首选项应用于 Office 应用程序* 即可，Office 部署程序会自动应用设置。

您所定义的应用程序首选项将应用于设备的所有现有用户以及未来添加到该设备的任何新用户。如果在 Office 应用程序运行时应用首选项，则新的设置将在 Office 下次运行时生效。

## 获取更多信息请访问以下网站

---

[Office 部署工具官方网站](https://aka.ms/ODT)

[Office 部署工具的配置选项](https://docs.microsoft.com/zh-cn/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office 部署工具支持的产品 ID](https://docs.microsoft.com/zh-cn/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Microsoft 365 应用版的更新通道概述](https://docs.microsoft.com/zh-cn/deployoffice/overview-update-channels)

[Microsoft 365 应用版的更新历史记录](https://docs.microsoft.com/zh-cn/officeupdates/update-history-microsoft365-apps-by-date)

[Office 2019 更新频道概述](https://docs.microsoft.com/zh-cn/DeployOffice/office2019/update#update-channel-for-office-2019)
