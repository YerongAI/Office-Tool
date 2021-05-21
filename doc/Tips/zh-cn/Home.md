# 欢迎使用 Office Tool Plus

---

Office Tool Plus 是一个强大且实用的 Office 部署工具。

Office Tool Plus 基于 [Office 部署工具](https://aka.ms/ODT)和 [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office) 制作，可以很方便的部署 Office，其内置迅雷引擎可帮助您更快地下载 Office，当然，你也可以使用 Office Tool Plus 内置的各种小工具或者功能快捷、方便地激活和管理 Office 哦！

[官方博客](https://www.coolhub.top/)

[视频教程](https://space.bilibili.com/23627347)

[QQ 群](https://otp.landian.vip/zh-cn/#about)

[微信公众号（可加微信群）](https://otp.landian.vip/grouplink/wechat.html)

## Office Tool Plus 快捷键

---

- <kbd>Esc</kbd>: 返回到主页
- <kbd>F1</kbd>: 显示帮助
- <kbd>F5</kbd>: 刷新信息/重置配置（仅部署页面）
- <kbd>Ctrl + 1</kbd>: 切换到部署页面
- <kbd>Ctrl + 2</kbd>: 切换到激活页面
- <kbd>Ctrl + 3</kbd>: 切换到工具箱页面
- <kbd>Ctrl + 3</kbd>: 切换到文档转换页面

## Office Tool Plus 命令 (使用 Ctrl + P)

---

通过命令可以直达自己想要的功能，也可以做到批量设置哦！`命令不区分大小写，按照输入顺序执行。`如果路径中含有空格，请使用 "" (英文双引号) 将路径包括起来。

**/setImage [Path]** 手动指定背景图，Path: 背景图路径（支持 JPG，PNG，支持本地路径以及 HTTP 路径）

**/clImage** 清除当前背景图

**/getKey [ProductID]** 获取产品密钥，若是批量产品，返回 GVLK，其他产品则返回默认密钥。ProductID: 产品 ID，例如：ProPlus2019Volume

**/osppILByID [ProductID]** 安装指定产品的 Office 许可证， ProductID: 产品 ID。例如：MondoVolume

**/osppinpkey:[value]** 安装指定的 Office 密钥，例如：/osppinpkey:XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** 卸载指定的 Office 密钥，例如：/osppunpkey:XXXXX

**/osppsethst:[value]** 设置 KMS 主机地址，例如：/osppsethst:kms.example.com

**/osppsetprt:[value]** 设置 KMS 主机端口，默认 1688，例如：/osppsetprt:1688

**/osppact** 激活 Office 客户端产品

其它 OSPP 参数使用方法类似，在每个命令前添加 ospp 字眼即可，OSPP 帮助文档可从[微软官方文档](https://docs.microsoft.com/zh-cn/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)取得。
