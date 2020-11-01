## 部署 Office 说明
---

在这里，您可以管理当前已安装的 Office 产品和语言包。如果没有安装 Office，则可以进行全新安装。**由于微软限制，Office 仅可以安装在系统盘上。**

应用程序中，***Lync*** 代表 ***Skype for Business***，***Groove*** 代表 ***OneDrive for Business***

若要在下载模式中自定义 Office 安装文件保存路径，请修改 ***安装设置*** 中的 ***源路径*** 属性。

### 目录

---

1. 部署模式说明
2. 通道说明
3. 安装模块说明
4. 更多信息

### 部署模式说明

---

全新安装指的是在一台没有安装 Office 的计算机上部署 Office，而修改安装指的是在已有 Office 的计算机上部署 Office。

修改安装可以是新增/卸载产品或语言包，也可以是添加/删除应用程序，点击开始部署后，你所做的更改将会应用于现有的 Office 安装中。

#### 下载时安装

此模式可用于全新安装，也可以修改当前的安装。下载时安装仅会下载所需文件，但如果网络状况不够良好，可能会导致安装耗费异常多的时间甚至安装失败。`建议修改安装时选择此项。`

#### 下载后安装

此模式可用于全新安装，也可以修改当前的安装。下载后安装会将 Office 安装文件完整地保存到下载位置，如果安装时定义的组件较少，则完整下载会消耗额外的带宽。`建议全新安装时选择此项。`

#### 使用现有安装源

此模式可用于全新安装，也可以修改当前的安装。使用现有安装源时，你必须指定 Office 安装文件中的一个 CAB 文件（任意一个），Office ISO 文件要先挂载或者解压后才能看到 CAB 文件。如果用户未选择安装文件，则会在安装时默认回退到下载时安装。

#### 创建 ISO 文件

创建 ISO 文件要求已下载 Office 安装文件，并且 Office 安装文件与 Office Tool Plus 同目录。

`如果在创建 ISO 文件之前配置了 Office 安装（例如添加产品与语言），则会在创建 ISO 的同时生成一个 Configuration.xml，在 ISO 模式下启动 Office Tool Plus 时，将会询问用户是否直接开始安装 Office。`

#### 仅下载

此模式仅下载 Office 安装文件，不会进行 Office 的部署。
`使用此模式时，至少要添加一个语言包，否则下载可能会不完整。`

#### 仅配置

此模式仅用于配置并生成 XML 文件。不会检查当前计算机上的 Office 也不会进行任何修改。

### 通道说明

---

`Office 2019 企业长期版：`

Office 2019 批量版的专属通道。

**功能更新：** 无

**安全更新：** 每个月一次，在每个月的第二个星期二

`当前通道（默认）：`

**功能更新：** 新功能就绪后立即推送更新（大概每个月一次），无特定计划

**安全更新：** 每个月一次，在每个月的第二个星期二

`半年通道：`

**功能更新：** 每年两次（一月和七月），每个月的第二个星期二

**安全更新：** 每个月一次，在每个月的第二个星期二

注意：我们不推荐任何人使用预览性质的通道！若要获取更详细的信息，请导航至末尾的链接查看微软官方的详细解释。

### 安装模块说明

---

Office 部署工具是微软官方发布的一个用于部署 Office 的工具。

Office Tool Plus 模块是我们自行编写的安装模块，虽然功能没有 Office 部署工具的全面，但是也可以用于安装 Office

#### Office Tool Plus 模块中不支持的功能

- 不支持日志选项设置
- 不支持设置配置管理器
- 不支持设置更新截止时间
- 不支持迁移体系结构
- 不支持强制更新
- 不支持移除现有的 MSI 版本的 Office
- 不支持安装与先前 MSI 版本相同的语言

注意：**若要获得完整的安装体验，请务必使用 Office 部署工具。**

### 获取更多信息请访问以下网站

---

[Office 部署工具官方网站](https://aka.ms/ODT)

[Office 部署工具的配置选项](https://docs.microsoft.com/zh-cn/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Office 部署工具支持的产品 ID](https://docs.microsoft.com/zh-cn/office365/troubleshoot/installation/product-ids-supported-office-deployment-click-to-run)

[Microsoft 365 应用版的更新通道概述](https://docs.microsoft.com/zh-cn/deployoffice/overview-update-channels)

[Microsoft 365 应用版的更新历史记录](https://docs.microsoft.com/zh-cn/officeupdates/update-history-microsoft365-apps-by-date)

[Office 2019 更新频道概述](https://docs.microsoft.com/zh-cn/DeployOffice/office2019/update#update-channel-for-office-2019)
