# Office Tool PLus

## English (英语) Version

Office Tool Plus is a tool for managing, downloading and installing Office.

Office Tool Plus is based on Microsoft's Office Deployment Tool. You can customize configure your Office installation and download installation files to install Office without Internet.

What's more, you can manage your installed Office, add language packs or customize uninstall Office.

### Download Office Tool Plus

[Official website](https://otp.landian.vip/zh-cn/)

[Mirror download](https://delivery.yuntu.moe/office-tool/) by [云图小镇](https://www.yuntu.moe/)

### Technical Articles

[Configuration options](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

### Quick Start

We recommend that you first download the installation file.

Simply go to the Download page and click Start.

After the download is complete, go to the Installation page, select the products you want to install, and click the Install button to begin the installation.

You need to activate Office after install.

### Application Legitimacy

Office Tool Plus is based on Microsoft's [Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/overview-of-the-office-customization-tool-for-click-to-run). And we added some functions according to the needs of users.

#### About Activate Function

The activate function was based on Microsoft's ospp.vbs (Office Software Protect Platform), all activate operations are performed by ospp.vbs. And in order to let users better understand OSPP, we translated it (zh-cn, zh-tw).

You can view the description of OSPP in ````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"```` (Office installed required).

### Help With Localization

We encourage everyone to help with localization. The following is how to do.

1. Fork this repository

2. Translate ````zh-cn.xaml```` to your own language then save it like ````zh-tw.xaml````

3. Copy it to the right path, like OfficeToolPlus/Language/zh-tw.xaml

4. Make a Pull Request.

#### How To Test Your Translation

1. Save your translation file to a path, like ````D:\Date\zh-cn.xaml````.

2. Open application.

3. Go to settings page, click ````Load localization file.````

4. Select the file that you just saved.

After that, application will load your translation, if you are adding a new translation to application, it will show: failed to connect to server. It's normal.

#### What is More

For each translator, we will give them an Admin app that allows you to change the announcement and upload a background image.

````Admin app is still developing.````

### Help With Coding

If you have any ideas about coding, you can fork this repository and coding by yourself, after done, make a pull request and explain what you changed and how to use it or why you change it.

Thanks you very much.

But actually, it is only contains partial codes, (●ˇ∀ˇ●) so you can only use editor such as NotePad.

Note: You CAN'T copy this codes to use without my permisson!

## Chinese (简体中文) Version

Office Tool Plus 是一个用来管理、下载、安装 Office 的小工具。

Office Tool Plus 基于微软的 Office Deployment Tool 打造，使用 Office Tool Plus, 你可以快速地部署 Office，自定义部署 Office，想安装什么，不想安装什么，都随你设置。

更多的是，你可以使用 Office Tool Plus 管理已经安装的 Office (仅限基于 Click To Run 的)，更改配置、卸载单独产品或者添加语言包。

### 下载 Office Tool Plus

[官方网站](https://otp.landian.vip/zh-cn/)

[下载站](https://delivery.yuntu.moe/office-tool/) by [云图小镇](https://www.yuntu.moe/)

### 技术文章

[配置选项的说明](https://docs.microsoft.com/zh-cn/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

### 快速入门

我们建议您先下载 Office 安装文件再进行安装。

下载安装文件很简单，打开工具，转到下载页，点击开始即可。

当下载完成后，转到安装页面，选择你想安装的产品，然后点击开始安装即可。默认情况下已经配置了 Word, PowerPoint 和 Excel.

当安装完成后，你需要使用有效的许可证激活 Office。

### 应用程序合法性

Office Tool Plus 是基于微软的 [Office Deployment Tool](https://docs.microsoft.com/zh-cn/DeployOffice/overview-of-the-office-customization-tool-for-click-to-run) 打造的，并且我们在 Office Deployment Tool 的基础上添加了一些额外的功能以便用户更方便地部署 Office。

#### 关于激活模块

激活模块是基于微软的 ospp.vbs (Office Software Protect Platform) 制作的。所有激活操作都由 ospp.vbs 执行。同时为了用户能更好地理解 OSPP 的内容，我们还对其进行了翻译 (zh-cn, zh-tw).

您可以在 ````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"```` 中查看 OSPP 的操作说明 (需要先安装 Office).

### 帮助我们进行应用程序本地化工作

我们鼓励任何人帮助我们进行应用程序本地化（翻译）工作，以下是如何操作的说明：

1. Fork this repository

2. 翻译一个文件（比如） ````zh-cn.xaml```` 并保存，类似于 ````zh-tw.xaml````

3. 复制到对应的路径，比如 OfficeToolPlus/Language/zh-tw.xaml

4. Make a Pull Request.

#### 如何测试您的翻译文件

1. 保存您翻译的文件至一个路径，类似于 ````D:\Date\zh-cn.xaml````.

2. 打开 Office Tool Plus.

3. 转到设置页面，点击 ````Load localization file.````

4. 选择你刚才保存的翻译文件

如果一切没问题，应用程序将会加载您选择的语言资源文件，如果您在添加一个新的翻译到 Office Tool Plus，那么 OTP 可能会显示无法连接到服务器，这是正常的。当您正式提交翻译之后，我们会配置服务器。

#### 还有更多

对于每一位翻译人员来说，我们会给予一个 Admin 应用程序，通过 Admin 应用程序，您可以更改公告，添加背景图，修改说明等等。

````Admin 正在开发中````

### 与我们一起开发

If you have any ideas about coding, you can fork this repository and coding by yourself, after done, make a pull request and explain what you changed and how to use it or why you change it.

我们是很感谢您的。

不过需要注意的是，GitHub 上只有一部分代码，没有完整代码。 (●ˇ∀ˇ●) 所以你只可以用一些代码编辑器，例如 VS Code 等进行编写，cs 测试通过后可以提交给我们，我们会对其进行测试，感谢您为修复错误、提高应用程序性能、新增新功能做出贡献。

温馨提示：要使用我的代码，最好先经过我的同意。
