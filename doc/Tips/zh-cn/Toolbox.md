# 工具箱说明

---

通过使用这些工具，你可以很方便的解决一些问题，但我们无法保证这些工具是 100% 有效的。

## 更改更新通道说明

---

Office 2019 企业长期版通道是 Office 2019 批量版的专属通道，不可更改。

Office 2021 企业长期版通道是 Office 2021 批量版的专属通道，不可更改。

## 移除 Office 说明

---

Office Tool Plus 支持移除全部版本的 Office，如果移除期间出现了一些错误，您可以通过错误信息找到问题所在，然后手动解决问题。

获取详细信息请访问[从 PC 卸载 Office](https://support.microsoft.com/zh-cn/office/%E4%BB%8E-pc-%E5%8D%B8%E8%BD%BD-office-9dd49b83-264a-477a-8fcc-2fdf5dbf61d8)

## 修复激活说明

---

修复 Office 激活会重建 Software Protection 配置、修复 KMS 软件劫持 SppExtComObj 的问题，在 Windows Insider 上还会重置 token.

由于 Windows Insider 的特殊性，修复一次并不管用，特别是 『发生未知错误』或『许可证使用失败』这两个问题。如果使用一次无法解决，可以再试一次，并且修复之后，等待两分钟再安装证书，装完证书之后，再等待两分钟，再进行剩下的激活操作。

### 手动解决『许可证使用失败』的问题

停止 Software Protection 服务，打开 `C:\Windows\System32\spp\store_test\2.0`, 将该目录以及子目录下的三个 dat 文件全部删除（有一个为隐藏文件）。然后重新启动 Software Protection 服务，等待两三分钟，让其自动重建 dat 文件，随后再进行激活操作，注意安装证书后也应该等待两三分钟。
