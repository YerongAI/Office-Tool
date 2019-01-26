# Office Tool Plus 使用手册

Office Tool Plus 是基于微软的 Office Deployment Tool 打造的一个用于部署、管理 Office 的一个小工具，如果您需要了解如何详细部署 Office，您也可以前往微软的 [Office Deployment Tool](https://docs.microsoft.com/zh-cn/deployoffice/configuration-options-for-the-office-2016-deployment-tool) 官网查看说明，微软官网对部署 Office 有详细的解释

默认情况下，Office Tool Plus 会尝试获取当前用户的最高权限，若当前用户不是管理员账户，则会尝试获取管理员权限，如果 Office Tool Plus 以普通权限运行，则只能进行一些基本操作，例如下载 Office 或者查看部分信息。

## Office Tool 详细的介绍

### 管理 Office
Office Tool Plus 仅支持管理 Click To Run 版本的 Office，其他版本的 Office 不受支持。如果您还在使用旧版本的 Office，我们建议您卸载旧版本的 Office 并使用 OTP 安装新版 Office。

在快速启动里，点击可以启动对应的 Office 应用程序，右键单击可以在桌面上创建对应的 Office 应用程序的快捷方式。

更新通道是 Office 用于检查以及下载更新的来源。更改更新通道时，需要将 “更改更新通道” 一并勾选。
有关更新通道的解释，请前往下载页的说明中查看。

C2R 语言是 ClickToRun 界面的显示语言。也就是我们平常看到的检查更新以及卸载 Office 的程序。更改后，必须重新启动 C2R 服务（ClickToRun 服务）才能使更改生效。若您不会重启服务，您可以选择重启计算机。

更改任何配置后，请点击保存按钮以便保存更改，可能需要重新启动 Office 应用程序以使更改生效。

#### 卸载 Office

自定义卸载可以用于批量卸载套件、产品或者自定义卸载语言包。

第一栏表示当前已安装的套件/产品，卸载套件时，会将套件内包含的应用程序一并卸载。需要卸载套件/产品的话，直接勾选，然后点击卸载即可。
第二栏则表示已安装的语言包。把所有的套件/产品选中，然后选择需要卸载的语言包，点击卸载即可将语言包卸载。

点击全部卸载则会删除此计算机上所有 Office 产品，无论是否勾选。 

当正常卸载出错或者卸载后有残留时，可以尝试强制移除 Office，此类工具以及脚本均收集于微软官方网站。在工具或者脚本运行期间，请务必耐心等待。
温馨提醒：不要随便使用此类清除工具！能正常卸载的请正常操作。

有关如何手动卸载 Office，请参考[此条链接](https://support.office.com/zh-cn/article/手动卸载-Office-4e2904ea-25c8-4544-99ee-17696bb3027b)

### 下载 Office
在此处，您可以下载安装 Office 时所需的安装文件。使用安装文件可以在无网络的情况下安装 Office。亦可以将安装文件分发到您的网络中，以便使用您的网络的客户端可以使用此安装文件安装 Office，从而节省带宽或者是方便管理。

安装文件不区分 Office 授权版本，您可以在安装时指定版本，例如 Office 365，Office 2016 家庭版， Office 2019 专业增强版，Visio 专业版等版本。

体系架构中，x86 代表 32 位，x64 代表 64位。选择 All 会将 64 位和 32 位的安装文件一并下载，这会耗费更多的时间。如无特殊需求请勿选择 All。
有关更新通道以及体系架构的详细解释，请查看本段的最后部分。

点击查询版本号可以从微软服务器获取各个通道的 Office 的版本号以及发布日期。

下载前请检查安装文件是否有残留，如果有，请点击左下角的安装文件信息，然后点击删除文件即可。

下载完成后，Office Tool Plus 会发出通知并自动识别安装文件，您可以在设置中配置下载完成后是否自动启动安装程序，或者下载完成后执行关机、重启等操作。

#### 分享安装文件
若要分享安装文件，您可以选择将下载好的 Office 文件夹分享给其他人，或者是使用 OTP 创建 ISO 文件并与他人共享。
当您使用 OTP 创建 ISO 文件时，请务必确保 Office 文件夹与 OTP 同目录（默认同目录），否则创建的 ISO 文件将不会包含离线文件。
创建的 ISO 文件可以直接挂载并使用，其内置 Office Tool Plus，可以直接运行。

#### 定位安装文件
若要选择安装文件，请定位到 Office 文件夹所在的文件夹，OTP 即可自动识别安装文件。
举个例子：有一个安装文件的路径为：D:\Yerong\Office Tool\Office，在定位安装文件时，只需要定位到：D:\Yerong\Office Tool 即可。
如果是 ISO 镜像文件，请先挂载镜像文件，再使用 OTP 定位位置。

#### 下载旧版本的操作步骤
选择一个通道，然后点击查看历史版本按钮，获取对应通道的历史版本的内部版本号（通常为 xxxxx.xxxxx）。然后点击开始按钮旁的按钮菜单，选择下载旧版本，在弹出来的提示框中，输入 16.0.xxxxx.xxxxx，其中 xxxxx.xxxxx 是 Office 的内部版本号，点击确定即可开始下载历史版本。

#### 语言设置说明
在语言列表中，带有颜色的语言类型为 Full，Full 代表这个语言在 Office 内可以以所选语言显示界面、帮助以及拥有所选语言的校对工具。

黑色的语言类型为 Partial，代表这个语言包含某些 Office 应用程序的所选界面语言，同时也包含校对工具。

斜体的语言类型为 Proofing，代表这个语言在 Office 内只包含拼写检查器。

注意：Full 类型的语言是不可缺少的，比如你需要安装一个 Partial 或者 Proofing 类型的语言时，必须确保需要选择一个 Full 类型的语言，否则 Office 将无法正常安装。

#### 下载引擎说明
下载引擎是用于从 Office CDN 下载安装文件的程序。

下载引擎分别有迅雷、Aria2c 以及微软官方程序，这些程序均内置在 Office Tool Plus 中，无需额外安装。当某个引擎出现问题时，可以在下载设置中切换下载引擎。

Aria2c 支持设置 HTTP/FTP/SFTP 代理，当代理类型选择 HTTP/FTP/SFTP 时，只需要填写相关信息即可成功设置代理。

**如果在使用迅雷下载时遇到下载进度不动，卡 100% 的问题，可以尝试先暂停下载再继续下载。**

#### 下载引擎差异
引擎|说明
:---|:---
迅雷下载|显示下载进度、文件大小、下载速度以及文件名等信息，支持断点续传
Aria2c|单独在 CMD 窗口显示下载信息（请勿点击 CMD 窗口避免下载被暂停）
微软官方|仅有下载状态显示

#### 更新通道解释
通道 ID|通道名称|通道解释
:---|:---|:---
Broad|半年频道|一年仅向用户提供几次 Office 功能更新。
Targeted|半年频道（定向）|让试点用户和应用兼容性测试人员有机会测试下一个半年通道。适用于IT 测试、应用和加载项所有者、具有代表性的最终用户
Monthly|每月频道|最新 Office 功能一经推出，便立即提供给用户。
PerpetualVL2019|Office 2019 长期服务版本|是 Office Professional Plus 2019 和 Office Standard 2019 的支持更新通道。 它也是 Project 2019 和 Visio 2019 批量许可版本的默认更新通道。
Insiders|每月频道（定向）（以前称为预览体验计划 - 慢）|如果预览体验成员希望收到频率较低、稳定性较高的更新，则此级别非常适合。大约每月发布一次每月频道（定向）内部版本，这些版本完全受支持
InsiderFast|预览体验计划（以前称为预览体验计划 - 快）|如果预览体验成员要使用最早的内部版本发现问题并提供有关仍处于开发阶段的新功能的反馈，且不介意使用不受支持的版本所带来的轻微风险，则此级别非常适合
Dogfood|暂无解释|


有关更新通道的更多信息，请参考[此条链接](https://docs.microsoft.com/zh-cn/DeployOffice/overview-of-update-channels-for-office-365-proplus)

有关 Office 2019 的更新通道信息请参考[此条链接](https://docs.microsoft.com/zh-cn/DeployOffice/office2019/update#update-channel-for-office-2019)

为方便查看，下表列出了每个更新通道通常多久添加一次功能更新、安全更新程序和与安全无关的更新程序。 

更新通道|功能更新|安全更新|与安全无关的更新
:---|:---|:---|:---
每月频道|每月一次|每月一次|每月一次 
半年频道|半年一次（1 月、7 月）|每月一次|半年一次 
半年频道（定向）|半年一次（3 月、9 月）|每月一次|每月一次 

安全更新程序通常于当月的第二个星期二发布。

查看[微软官方](https://support.office.com/zh-cn/article/选择-64-位或-32-位版本的-office-2dee7807-8f95-4d0c-b5fe-6c6f49b8d261)对于选择 64 位或者 32 位的解释
#### 选择 64 位版的原因
运行 64 位版 Windows 的计算机通常比其 32 位 前身拥有更多资源，例如处理能力和内存。此外，与 32 位应用程序相比，64 位应用程序可以访问更多内存（1.84 千万拍字节）。因此，如果你的方案包含大型文件和/或处理大型数据集，且你的计算机运行 64 位版 Windows，则存在下列情况时，64 位是恰当的选择：

处理大型数据集，例如包含复杂计算、许多数据透视表、与外部数据库的数据连接、Power Pivot、三维地图、Power View 或获取和转换的企业级 Excel 工作簿。在这些情况下，64 位版 Office 可能表现更出色。请参阅 Excel 规范与限制、数据模型规范和限制以及 32 位版 Excel 中的内存使用情况。 

在 PowerPoint 中处理超大图片、视频或动画。64 位版 Office 可能更适合处理这些复杂幻灯片。

在 Project 中处理超过 2 GB 的文件，尤其是项目包含许多子项目时。

开发内部 Office 解决方案，例如加载项或文档级别的自定义。使用 64 位版 Office 将允许你提供这些解决方案的 64 位版和 32 位版。内部 Office 解决方案开发人员应有权访问 64 位 Office 2016，以便测试和更新这些解决方案。

#### 选择 32 位版的原因
注意: 如果使用的是 32 位 Windows，则只能安装 32 位 Office。如果使用的是 64 位 Windows，则可安装 32 位 Office 或 64 位 Office。

尤其是 IT 专业人士和开发人员，还应检查以下情况，在这些情况下，32 位版 Office 仍然是你自己或你的组织的最佳选择。

使用没有 64 位替代项的 32 位 COM 加载项。你可以继续在 64 位 Windows 上的 32 位 Office 中运行 32 位 COM 加载项。可尝试联系 COM 加载项供应商，并请求 64 位版本。

使用没有 64 位替代项的 32 位控件。你可以继续运行 32 位 Office 中的 32 位控件，如 Microsoft Windows 公共控件（Mscomctl.ocx、comctl.ocx）或任何现有第三方 32 位控件。

VBA 代码使用 Declare 语句大多数 VBA 代码在 64 位或 32 位中使用时不需要更改，除非你使用 Declare 语句为指针和控点调用使用长整型等 32 位数据类型的 Windows API。在大多数情况下，将 PtrSafe 添加到 Declare 并将长整型替换为 LongPtr 将使 Declare 语句兼容 32 位和 64 位，但极少数情况下没有可声明的 64 位 API，因而这种操作将不可行。有关需要对 VBA 进行哪些更改才能使其在 64 位 Office 上运行的详细信息，请参阅 64 位 Visual Basic for Applications 概述。

使用 Outlook 的 32 位 MAPI 应用程序。随着 64 位 Outlook 客户越来越多，建议为 64 位 Outlook 重建 32 位 MAPI 应用程序、加载项或宏，但可以根据需要继续通过 32 位 Outlook 运行它们。若要了解如何准备适用于 32 位和 64 位平台的 Outlook 应用程序，请参阅在 32 位和 64 位平台上构建 MAPI 应用程序和 Outlook MAPI 引用。

要激活 32 位 OLE 服务器或对象。你可以继续使用已安装的 32 位版 Office 运行 32 位 OLE 服务器应用程序。

使用 SharePoint Server 2010 且需要“在数据表中编辑”视图。你可以通过 32 位 Office 继续使用 SharePoint Server 2010 中的“在数据表中编辑”视图功能。

需要 32 位 Microsoft Access .mde、.ade 和 .accde 数据库文件。虽然可以重新编译 32 位 .mde、.ade 和 .accde 文件以使其可兼容 64 位，但也可以继续在 32 位 Access 中运行 32 位 .mde、.ade 和 .accde 文件。

需要 Word 中的旧版公式编辑器或 WLL（Word 加载项库）文件。你可以在 32 位 Word 中继续使用原有 Word 公式编辑器和运行 WLL 文件。

PowerPoint 演示文稿中存在旧的嵌入式媒体文件，而没有可用的 64 位编解码器。

### 安装 Office
套件包含应用程序，因此当你选定套件后，您可以在应用程序列表中选择需要安装的应用程序，勾选即为安装。
若要单独安装其他产品（例如 Visio）而不安装套件的，请将套件的值清空。

Click to Run 默认将 Office 安装至系统盘，此设置由微软管理，无法更改。

#### 语言设置说明
在语言列表中，带有颜色的语言类型为 Full，Full 代表这个语言在 Office 内可以以所选语言显示界面、帮助以及拥有所选语言的校对工具。

黑色的语言类型为 Partial，代表这个语言包含某些 Office 应用程序的所选界面语言，同时也包含校对工具。

斜体的语言类型为 Proofing，代表这个语言在 Office 内只包含拼写检查器。

注意：Full 类型的语言是不可缺少的，当安装 Partial 或者 Proofing 类型的语言时，必须确保需要选择一个 Full 类型的语言，否则 Office 将无法正常安装或者会默认安装英语语言包。

安装语言默认匹配系统语言

---
##### 匹配系统语言
语言列表用于指定 Fallback 属性，即当系统的语言不受 Office 支持时，ODT (Office Deployment Tool) 会使用 Fallback 属性中指定的语言来安装 Office，若未指定 Fallback 属性，则默认安装 en-us 语言。仅可以设置一个 Fallback 属性。

##### 匹配已安装的 Office
ODT 会匹配目前已安装的 Office 的语言，这在增删组件或者产品时会非常有用。

##### 匹配先前 MSI 版本的语言
ODT 会查找计算机上已安装了的 MSI 版本的 Office 的语言，并将其设置为 Office 的安装语言。此项必须与 RemoveMSI 属性一起使用，以便从 MSI 版本升级至 C2R 版本，若您的计算机上没有 MSI 版本的 Office，请勿选择此项。

##### 从列表中选择
列表中被勾选的语言将会被设置为 Office 安装语言。其中，当您选择了多个语言时，设置的第一个语言将会被用于确定 Shell UI 区域性，包括快捷方式，右键单击上下文菜单和工具提示。单击语言列表右边的空白区域并拖动可以对语言进行排序。

---
有关其他属性的详细信息，请前往[微软的网站](https://docs.microsoft.com/zh-cn/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)查看详细信息

#### Office 365 套件/产品 ID 参考
产品 ID|产品名称
:---|:---
O365ProPlusRetail|Office 365 ProPlus，适用于Office 365教育版、Office 365 专业增强版、Office 365 企业版 E3、Office 365 企业版 E4、Office 365 企业版 E5、Office 365 中型企业版
O365HomePremRetail|Office 365 家庭高级版
O365BusinessRetail|Office 365 商业版、Office 365 商业高级版
O365SmallBusPremRetail|Office 小型企业高级版

#### 2016 套件/产品 ID 参考
产品 ID|产品名称
:---|:---
ProPlusRetail|Office 专业增强版 - 零售版
ProfessionalRetail|Office 专业版 - 零售版
StandardRetail|Office 标准版 - 零售版
HomeBusinessRetail|Office 家庭高级版
HomeStudentRetail|Office 家庭学生版
ProjectProXVolume|Project 专业版 - 批量版
ProjectProRetail|Project 专业版 - 零售版 - for Office 365
ProjectStdXVolume|Project 标准版 - 批量版
ProjectStdRetail|Project 标准版 - 零售版
VisioProXVolume|Visio 专业版 - 批量版
VisioProRetail|Visio 专业版 - 零售版 - for Office 365
VisioStdXVolume|Visio 标准版 - 批量版
VisioStdRetail|Visio 标准版 - 零售版

#### 2019 套件/产品 ID 参考
产品 ID|产品名称
:---|:---
ProPlus2019Retail|Office 专业增强版 - 零售版
ProPlus2019Volume|Office 专业增强版 - 批量版
Standard2019Retail|Office 标准版 - 零售版
Standard2019Volume|Office 标准版 - 批量版
ProjectPro2019Volume|Project 专业版 批量版
ProjectPro2019Retail|Project 专业版 零售版
ProjectStd2019Volume|Project 标准版 批量版
ProjectStd2019Retail|Project 标准版 零售版
VisioPro2019Volume|Visio 专业版 批量版
VisioPro2019Retail|Visio 专业版 零售版
VisioStd2019Volume|Visio 标准版 批量版
VisioStd2019Retail|Visio 标准版 零售版

#### 其他产品 ID 参考
产品 ID|产品名称
:---|:---
LanguagePack|语言包
ProofingTools|语言校对工具
AccessRuntimeRetail|Access 运行时
AccessRetail|Access 2016 零售版
Access2019Retail|Access 2019 零售版
Access2019Volume|Access 2019 批量版
ExcelRetail|Excel 2016 零售版
Excel2019Retail|Excel 2019 零售版
Excel2019Volume|Excel 2019 批量版
OneNoteRetail|OneNote 2016 零售版
OneNoteFreeRetail|OneNote 免费版
OutlookRetail|Outlook 2016 零售版
Outlook2019Retail|Outlook 2019 零售版
Outlook2019Volume|Outlook 2019 批量版
PowerPointRetail|PowerPoint 2016 零售版
PowerPoint2019Retail|PowerPoint 2019 零售版
PowerPoint2019Volume|PowerPoint 2019 批量版
PublisherRetail|Publisher 2016 零售版
Publisher2019Retail|Publisher 2019 零售版
Publisher2019Volume|Publisher 2019 批量版
SkypeforBusinessRetail|
SkypeforBusinessEntryRetail|SkypeforBusiness (Office365)
SkypeforBusiness2019Retail|
SkypeforBusiness2019Volume|
SkypeforBusinessEntry2019Retail|
WordRetail|Word 2016 零售版
Word2019Retail|Word 2019 零售版
Word2019Volume|Word 2019 批量版

有关产品 ID 的更多信息，请前往[微软的网站](https://go.microsoft.com/fwlink/p/?LinkID=301891)查看详细信息

#### 常见问题以及解决办法
写在开头：如果您的系统不是原版系统，而是经过修改、精简的系统或者是 Ghost 来的系统，请重装原版系统。此类系统常常因为系统文件被修改/破坏严重而导致 Office Deployment Tool 和 Click to Run 无法正常运行。重装原版系统是最快速、最有效的方法，有关原版系统可以前往 MSDN 我告诉你 下载。

---
名称|信息
:---|:---
问题|卡在 We're getting things ready... 
问题原因|很大可能与 360，管家以及毒霸等各种杀毒、安全软件有关。
解决办法1|关闭这些第三方杀毒/安全软件
解决办法2|尝试使用 OTL 安装 Office，设置页面提供了下载选项。

名称|信息
:---|:---
问题|提示 You have the Windows Installer based program installed in your computer
问题原因|已经有基于 MSI 的 Office 安装在系统中
解决办法|卸载旧版本的 Office （包括 Visio 和 Project）；或者在可选设置页面勾选 移除现有的 MSI 版本的 Office 并再次尝试安装。

如已经卸载或者无法正常卸载，请使用 管理 - 卸载 页面提供的脚本/工具清除 Office。
清除完成后，重启计算机后再试。
如果依然继续此提示，请参阅 管理 页中说明里提到的手动卸载 Office。

名称|信息
:---|:---
问题|提示 you have the 32 (or 64) bit program installed in your computer
问题原因|有其他版本的 Office 已经安装在系统中，这些版本无法共存
解决办法1|卸载这些版本的 Office 并重新安装
解决办法2|安装与已存在的 Office 相同类型的版本。比如 32 位的选择 32 位的，64 位选择 64 位的。

名称|信息
:---|:---
问题|提示 We can't download a required file
问题原因|无法下载所需文件
解决办法|尝试重新下载离线文件，或者在线安装 Office。

如果离线文件有多个版本，请在可选设置中手动指定可用的版本，或者清除无法使用的版本。

名称|信息
:---|:---
问题|提示 This product can't be installed on the selected update channel
问题原因|通道与套件/产品不对应
解决办法|2019 系列的套件和产品要对应通道 PerpetualVL2019。其他的套件/产品选择此通道也会报错，请选择其他通道。

名称|信息
:---|:---
问题|提示 This product require Windows 10 to continue
问题原因|这个产品只支持在 Windows 10 中安装
解决办法1|更新您的系统至 Windows 10 之后再安装 Office。如果您并未打算安装 Office 2019，请更改套件、产品。
解决办法2|使用 Office Tool Lite 在 Windows 7 上强制安装 Office。

如果您无法使用 OTL 在 Win 7 上安装 Office 2019，请参照 B站教程 通过更改许可证的方法来使用 Office 2019。

通用解决办法：清除 Office，关闭其他软件，重启电脑再试，清理文件和注册表再试

最终解决办法：重装原版 Windows

---
### 激活 Office
若要转换 Office 授权，请直接安装对应的证书即可。
举个例子：比如要转换 Office 2016 Retail -> Office 2016 Volume，安装 Office 2016 Volume 即可完成转换。
安装完成后，可以使用对应的密钥来激活，同时也可以做到多授权版本共存。

点击旁边的省略按钮可以自定义选择并安装证书。

只有当计算机上安装了基于 C2R 版本的 Office 时，OTP 才会读取 Office 证书并在下拉框中显示。否则 OTP 仅会显示内置的 Volume (批量版) 证书。

#### Office 激活方法以及步骤
##### 密钥在线激活步骤
直接安装密钥，然后点击激活即可。若密钥有效以及版本对应，Office 将成功激活。此过程亦可以在 Office 内完成。
激活成功后，Office 将会一直保持激活状态。

##### 电话激活步骤
安装密钥，确保其可以用于电话激活，然后在安装密钥按钮的按钮菜单中，点击查看安装 ID，使用此 ID 在微软提供的方式内获取 确认 ID，然后安装 确认 ID，若 确认 ID 和 安装 ID 对应，Office 即可成功离线激活。
激活成功后，Office 将会一直保持激活状态。

##### KMS 激活步骤
安装对应的 批量（Volume）证书，比如你要激活 Office 2016 就安装 Office 2016 Volume 证书，然后设定一个 KMS 地址，当一切配置无误、网络正常、服务器正常的情况下，点击激活按钮，Office 将会顺利激活。

KMS 激活成功后，Office 会默认 7 天与服务器连接一次并自动续期，最大持续激活时间为 180 天。
当服务器正常，系统正常，网络正常的默认情况下，激活剩余时间不会低于 172 天，因此也可以达到 “永久激活” 的效果。
此步骤由 Windows 自行完成，无需人工干涉，也没有任何后台程序驻留。

OTP 保证不会对用户的计算机进行任何未经授权的修改，更不会进行任何破解。
对于 KMS 服务器，您可以在受支持的路由器上搭建一个，或者是百度搜索 KMS 服务器地址即可。

#### 检测 KMS 可用性
输入一个 KMS 地址，然后在按钮菜单中点击检测 KMS 可用性。

一般情况下会返回如下的结果：
Connecting to 192.168.123.1:1688 ... successful
Sending activation request (KMS V4) 1 of 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

其中 successful 表示可以正常连接到服务器，Sending activation request 则表示服务器可以正常响应激活请求。

如果检测没有返回结果或者返回的结果不完整，则表示此 KMS 服务器或者网络可能存在问题。

#### 查询 Office 激活状态
点击右下角的显示激活信息可以查询已安装密钥的许可证的信息。
当许可证状态为 ---已许可--- 时，表示 Office 已激活，其他所有的状态都是未激活。

#### 清除 Office 激活信息
点击右下角的显示激活信息以查询已安装密钥的许可证的信息。

将不需要的授权的最后五位数密钥复制，将其粘贴到密钥框中，然后在按钮菜单中选择卸载密钥，即可清除此激活信息。

#### 清除 Office 激活状态
在证书管理的按钮菜单中，可以清除所有许可证。
清除许可证后，第一次打开 Office 应用程序需要修复以重新安装默认的许可证。
或者您可以手动安装许可证，安装完毕后，可以重新激活 Office。

在密钥管理的按钮菜单中，可以卸载所有密钥。
卸载所有密钥后，所有激活都将会被清除，Office 会回到未激活的状态，您需要重新激活 Office。

清除激活状态会将密钥和证书一并清除。

#### 常见错误以及解决办法
名称|信息
:---|:---
错误代码1|0x8007007B
错误原因|文件名、目录名或卷标语法不正确
错误代码2|0x8007232B
错误原因|DNS 名称不存在
解决办法|在工具箱内修复 Office 的激活，然后再设定 KMS 服务器地址，再进行激活操作

名称|信息
:---|:---
错误提示|软件授权服务报告许可证未安装
错误原因|这个许可证安装的是默认的密钥
解决办法|无需解决

名称|信息
:---|:---
错误提示|软件授权服务报告未找到产品 SKU
错误原因|许可证没有安装，或者密钥和证书不对应
解决办法|安装对应的授权证书，或者更换其他密钥

名称|信息
:---|:---
错误提示1|发生未知错误
错误提示2|软件授权服务报告许可证使用失败
错误原因|Windows Insider 的 Bug，导致 Office 无法正常验证激活信息
解决办法|将 Software Protection 服务停止，然后将 C:\Windows\System32\spp\store_test\2.0 下的三个 (.dat) 文件删除（有一个隐藏的）。然后再重新进行一切激活操作

#### 重要提示
使用 GVLK 之前，请确保您的 Office 为批量版
如您不知是否为批量版，请安装对应的 Volume 证书，然后再使用 GVLK
使用 KMS 激活必须要配置一个 KMS 服务器地址，否则无法激活 Office。

#### Office 2019 GVLK（KMS 专用）
产品|密钥
:---|:---
Office Pro Plus 2019|NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019|6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019|B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019|C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019|9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019|7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019|9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019|TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019|7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019|RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019|G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business|NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019|PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

#### Office 2016 GVLK（KMS 专用）
产品|密钥
:---|:---
Office Pro Plus 2016|XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99
Office Standard 2016|JNRGM-WHDWX-FJJG3-K47QV-DRTFM
Office Mondo 2016|HFTND-W9MK4-8B7MJ-B6C4G-XQBR2
Project Pro 2016|WGT24-HCNMF-FQ7XH-6M8K7-DRTW9
Project Std 2016|D8NRQ-JTYM3-7J2DX-646CT-6836M
Visio Pro 2016|69WXN-MBYV6-22PQG-3WGHK-RM6XC
Visio Std 2016|NY48V-PPYYH-3F4PX-XJRKJ-W4423
Access 2016|GNH9Y-D2J4T-FJHGG-QRVH7-QPFDW
Excel 2016|9C2PK-NWTVB-JMPW8-BFT28-7FTBF
OneNote 2016|DR92N-9HTF2-97XKM-XW2WJ-XW3J6
Outlook 2016|R69KK-NTPKF-7M3Q4-QYBHW-6MT9B
PowerPoint 2016|J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016|F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business|869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016|WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6

#### Office 365 默认密钥（激活功能专用）
产品|密钥
:---|:---
O365ProPlusRetail|DRNV7-VGMM2-B3G9T-4BF84-VMFTK

### 转换文档
此功能依赖 Office，请确保您的计算机上已安装最新版本的 Office，否则可能会出现各种不可预知的问题！

#### Office 文档转换步骤
选择源文件的格式，然后点击选择文件，选择需要转换的文件。
选择需要输出的文件的格式，然后点击开始即可。

转换进行时，请勿对计算机进行其他的操作。若出现任何提示，请手动处理这些提示，否则转换将不会继续。
处理完提示后，请将鼠标移动到任务栏区域以避免影响到 Office 应用程序的正确响应。

#### 文档转换注意事项
建议您将某些提示设置为不再提醒，避免转换过程中因提示而被暂停。
转换成 PDF:
打开一个 Word 文档，选择另存为，在另存为对话框里面，把 发布后打开文件 取消勾选，然后点击确定，即可取消设置另存为 PDF 后打开文件。

高版本文档转换成低版本文档:
一般情况下，Office 应用程序在保存文档为旧格式的时候会执行兼容性检查，如果检查到有问题会弹出框来提醒用户，在出现此对话框时，用户只可以选择手动处理这些提示，否则转换文档不会继续执行。

#### Word 文档格式参照表
扩展名|格式名称
:---|:---
docx|Word 文档
docm|启用宏的 Word 文档
doc|Word 97-2003 文档
dotx|Word 模板
dotm|启用宏的 Word 模板
dot|Word 97-2003 模板
pdf|PDF 文件
xps|XPS 文档
mht, mhtml|单个文件网页
htm, html|网页
htm, html|筛选过的网页
rtf|RTF 格式
txt|纯文本
xml|Word XML 文档
xml|Word 2003 文档
docx|Strict Open XML 文档
odt|OpenDocument 文本

#### PowerPoint 文档格式参照表
扩展名|格式名称
:---|:---
pptx|PowerPoint 演示文稿
pptm|启用宏的 PowerPoint 演示文稿
ppt|PowerPoint 97-2003 演示文稿
pdf|PDF 文档
xps|XPS 文档
potx|PowerPoint 模板
potm|PowerPoint 启用宏的模板
pot|PowerPoint 97-2003 模板
thmx|Office 主题
ppsx|PowerPoint 放映
ppsm|启用宏的 PowerPoint 放映
pps|PowerPoint 97-2003 放映
ppam|PowerPoint 加载项
ppa|PowerPoint 97-2003 加载项
xml|PowerPoint XML 演示文稿
mp4|MPEG-4 视频
wmv|Windows Media 视频
gif|GIF 可移植网络图形格式
jpg|JPEG 文件交换格式
png|PNG 可移植网络图形格式
tif|TIFF Tag 图像文件格式
bmp|设备无关位图
wmf|Windows 图元文件
emf|增强型 Windows 元文件
rtf|大纲/RTF 文件
pptx|PowerPoint 图片演示文稿
pptx|Strict Open XML 演示文稿
odp|OpenDocument 演示文稿

#### Excel 文档格式参照表
扩展名|格式名称
:---|:---
xlsx|Excel 工作簿
xlsm|Excel 启用宏的工作簿
xlsb|Excel 二进制工作簿
xls|Excel 97-2003 工作簿
csv|CSV UTF-8 (逗号分隔)
xml|XML 数据
mht, mhtml|单个文件网页
htm, html|网页
xltx|Excel 模板
xltm|Excel 启用宏的模板
xlt|Excel 97-2003 模板
txt|文本文件 (制表符分隔)
txt|Unicode 文本
xml|XML 电子表格 2003
xls|Microsoft Excel 5.0/95 工作簿
csv|CSV (逗号分隔)
prn|带格式的文本文件 (空格分隔)
dif|DIF (数据交换格式)
slk|SYLK (符号连链接)
xlam|Excel 加载宏
xla|Excel 97-2003 加载宏
pdf|PDF 文档
xps|XPS 文档
xlsx|Strict Open XML 电子表格
ods|OpenDocument 电子表格
