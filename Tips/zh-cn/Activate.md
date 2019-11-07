# 激活 Office 说明

若您使用本工具激活失败，首先检查自己操作是否有误，下方说明中有 Office 的激活步骤说明，若您确定您的操作无误但又无法激活 Office，建议检查系统是否有问题。激活成功后，Office 各项功能均可正常使用，可以登录微软账号。

## 目录

---

1. 安装证书（转换授权）
2. 激活证书（激活 Office）
3. 检查 KMS 可用性
4. 查询激活状态
5. 清除 Office 激活信息
6. 常见错误以及解决办法
7. GVLK 列表

## 安装证书

---

安装某个证书以后，即可使用对应该证书的密钥进行激活。
举个例子：比如要转换 Office 2016 Retail -> Office 2016 Volume，直接安装 Office 2016 Volume 许可证即可完成转换。
安装完成后，旧的证书并不会被覆盖，因此通过此操作可以做到多证书授权共存。

点击旁边的省略按钮可以自定义选择并安装证书。

`注意：只有当计算机上安装了基于 C2R 版本的 Office 时，OTP 才会读取 Office 证书并在下拉框中显示。否则 OTP 仅会显示内置的 Volume (批量版) 证书。`

## Office 激活方法以及步骤

---

`请注意：所有 Office 365 产品仅可通过登录账号激活，Office Tool Plus 仅支持管理激活，不负责激活。`

### 密钥在线激活步骤

`激活前，请确保您的密钥有效以及 Office 版本对应。`将密钥输入，并点击安装密钥，然后点击激活，Office 将成功激活。此过程亦可以在 Office 内完成。
激活成功后，Office 将会一直保持激活状态。

### 电话激活步骤

安装密钥，`确保其可以用于电话激活`。在安装密钥按钮的菜单中，点击查看安装 ID，使用此 ID 在微软提供的方式内获取 确认 ID，然后安装 确认 ID，若 确认 ID 和 安装 ID 对应，Office 即可成功离线激活。
激活成功后，Office 将会一直保持激活状态。

### KMS 激活步骤

激活前，请确保您的 Office 是批量版，如果不确定，请安装对应的 批量（Volume）证书，比如你要激活 Office 2016 就安装 Office 2016 Volume 证书，`然后设定一个 KMS 地址`，当一切配置无误、网络正常、服务器正常的情况下，点击激活按钮，Office 将会顺利激活。

`KMS 激活成功后，Office 会默认 7 天与服务器连接一次并自动续期，最大持续激活时间为 180 天。此步骤由 Windows 自行完成，无需人工干涉，也没有任何后台程序驻留。`

## 检测 KMS 可用性

---

输入一个 KMS 地址，然后在按钮菜单中点击检测 KMS 可用性。

一般情况下会返回如下的结果：
Connecting to 192.168.123.1:1688 ... successful
Sending activation request (KMS V4) 1 of 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

其中 successful 表示可以正常连接到服务器，Sending activation request 则表示服务器可以正常响应激活请求。

如果检测没有返回结果或者返回的结果不完整，则表示此 KMS 服务器或者网络可能存在问题。

## 查询 Office 激活状态

---

点击 *显示激活信息* 可以查询已安装密钥的许可证的信息。
`当许可证状态为 ---已许可--- 时，表示 Office 已激活，其他所有的状态都是未激活。`

## Office 激活信息管理

---

### 卸载 Office 产品密钥

点击 *显示激活信息* 以查询已安装密钥的许可证的信息。

将不需要的授权的最后五位数密钥复制，将其粘贴到密钥框中，然后在按钮菜单中选择卸载密钥，即可清除此激活信息。

![卸载产品密钥](https://coolhub.top/wp-content/uploads/2019/11/卸载产品密钥.png)

### 清除 Office 产品密钥

在密钥管理的按钮菜单中，可以卸载所有密钥。
卸载所有密钥后，Office 会回到未激活的状态，您需要重新激活 Office。

### 清除 Office 许可证

在证书管理的按钮菜单中，可以清除所有许可证。
清除许可证后，第一次打开 Office 应用程序需要修复以重新安装默认的许可证。
或者您可以手动安装许可证，安装完毕后，可以重新激活 Office。

**清除激活状态会将密钥和证书一并清除。**

## 常见错误以及解决办法

---

错误代码：0xC004F074
错误原因：未知
解决办法：重装`原版`系统，并且`不再使用 KMS 破解软件激活 Windows`。

错误代码1：0x8007007B
错误原因：文件名、目录名或卷标语法不正确
错误代码2：0x8007232B
错误原因：DNS 名称不存在
错误代码3：0x8007000D
错误原因：数据无效
解决办法：在工具箱内修复 Office 的激活，然后再设定 KMS 服务器地址，再进行激活操作

错误提示：没有在此计算机上发现 Office 批量许可证
错误原因：没有安装 Office 批量许可证，无法使用 MAK 或者 KMS 激活
解决办法：安装 Office 批量许可证（Volume）

错误提示：软件授权服务报告许可证未安装
错误原因：这个许可证安装的是默认的密钥
解决办法：如果您正在尝试激活试用许可（伪 Office 365），此问题无需解决。
　　　　　否则，您应更换一个有效密钥。

错误提示：软件授权服务报告未找到产品 SKU
错误原因：许可证没有安装，或者密钥和证书不对应
解决办法：安装对应的授权证书，或者更换其他密钥
　　　　　如果您在安装证书过程中出现此错误，则应该按照下面的解决方法操作👇

错误提示1：发生未知错误
错误提示2：软件授权服务报告许可证使用失败
错误原因：Windows Insider 的 Bug，导致 Office 无法正常验证激活信息
解决办法：将 Software Protection 服务停止，然后将 C:\Windows\System32\spp\store_test\2.0 下的三个 (.dat) 文件删除（有一个隐藏的）。然后再重新进行一切激活操作

错误提示：An error occurred while making the connection.
　　　　　错误代码：-2147023838
错误原因：系统关键服务被禁用
解决办法：在“服务”中将 Windows Management Instrumentation 服务启用，启用后，再次尝试操作。

## GVLK 列表

---

使用 GVLK 之前，请确保您的 Office 为批量版
如您不知是否为批量版，请安装对应的 Volume 证书，然后再使用 GVLK
使用 KMS 激活必须要配置一个 KMS 服务器地址，否则无法激活 Office。

获取更多信息请访问 [用于 Office 2019 和 Office 2016 的 KMS 和基于 Active Directory 激活的 GVLK](https://docs.microsoft.com/zh-cn/DeployOffice/vlactivation/gvlks)

```txt
Office 2019 GVLK

Office Pro Plus 2019	NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019	6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019		B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019		C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019		9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019		7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019		9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019		TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019		7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019	RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019		G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business	NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019		PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

Office 2016 GVLK

Office Pro Plus 2016	XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99
Office Standard 2016	JNRGM-WHDWX-FJJG3-K47QV-DRTFM
Office Mondo 2016	HFTND-W9MK4-8B7MJ-B6C4G-XQBR2
Project Pro 2016		WGT24-HCNMF-FQ7XH-6M8K7-DRTW9
Project Std 2016		D8NRQ-JTYM3-7J2DX-646CT-6836M
Visio Pro 2016		69WXN-MBYV6-22PQG-3WGHK-RM6XC
Visio Std 2016		NY48V-PPYYH-3F4PX-XJRKJ-W4423
Access 2016		GNH9Y-D2J4T-FJHGG-QRVH7-QPFDW
Excel 2016		9C2PK-NWTVB-JMPW8-BFT28-7FTBF
OneNote 2016		DR92N-9HTF2-97XKM-XW2WJ-XW3J6
Outlook 2016		R69KK-NTPKF-7M3Q4-QYBHW-6MT9B
PowerPoint 2016	J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016		F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business	869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016		WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
```

### Office 365 Pro Plus Normal Key

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

如果你看不懂上面的是什么意思，那就请不要随便用，反正也不能用来激活 Office。
