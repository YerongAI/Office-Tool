# About Activation

```txt
If you activate Office failed with this tool, please check your operation first (There are steps in the instructions below). If the problem still exists, please try to check your operating system. After the successful activation, everything is ready to go.
```

## Contents

---

1. Install License / Switch License
2. Activate License (Activate Office)
3. Check KMS Server
4. Query Activation Status
5. Clear Activation
6. Generic Volume License Keys (GVLKs)

## Install License

---

Once a license is installed, it can be activated with the corresponding key.
For example: If you want your Office 2016 Retail -> Office 2016 Volume, just install the Office 2016 Volume license.
After the installation, the old license won't be overwritten. So, we can have multiple licenses for one software.

If you want to install your local license files, just click the [...] button.

`Note: If the C2R-based version of Office is installed on your computer, OTP will try to read all available licenses and display them in the drop down box. Otherwise only the built-in Volume licenses will be displayed.`

## Activate License

---

### Online Activation

`Please make sure your key is valid and the version is correct before activation.` Enter the key and click [Install key] button, then click [Activate], Office will be activated successfully. This can also be done within Office.
After the successful activation, Office will remain active.

### Phone Activation

`Make sure your key can be used for phone activation` and install the key. In the submenu of the [Install key] button, click "View Installation ID". After getting the Confirmation ID, enter your Confirmation ID without blacks and click the submenu "Install Confirmation ID".
After the successful activation, Office will remain active.

### KMS Activation

Please make sure you have Volume licensed versions of Office installed. If you don't know whether it is a volume version, please install the corresponding Volume licenses. For example, if you want to activate Office 2016, just install the Office 2016 Volume license. Then you need to input a valid KMS server address, `don't forget the [Set server address] button`. When everything is configured correctly, the network is normal, and the KMS server is normal, click the [Activate] button. Success? Enjoy it!

How to get a KMS server address? Ask Google for help.

## Check KMS Server

---

Enter a KMS server address and click the submenu "Check KMS state".

The following results will be returned in general:
Connecting to 192.168.123.1:1688 ... successful
Sending activation request (KMS V4) 1 of 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

"successful" means that you can connect to the server, "Sending activation request" means the server is working.

If you didn't see this, there may be a problem with this KMS server or network.

## Query Activation Status

---

Click the [Display activation information] button below to query the license information for the installed keys.

`Note: Office is activated only when the license status is ---LICENSED--- .`

## Clear Activation

---

Click the [Display activation information] button below to query the license information for the installed keys.

Copy the last 5 characters of installed product key of the unneeded license, paste it into the Key Management input box, then click the submenu "Uninstall key".

### Clear Activation Status (All)

In the submenu of License Management, you can clear licenses.
After all licenses are cleared, you need to repair Office at the first time you open the Office application (Office will reset the licenses to default).
Or you can install the license manually. After that, you can activate Office again.

In the submenu of Key Management, you can uninstall all keys.
After all keys are uninstalled, all activations will be cleared, you need to reactivate Office.

The submenu "Clear activation" means that all the above operations will be performed.

## Generic Volume License Keys (GVLKs)

---

Please make sure you have Volume licensed versions of Office installed before using GVLKs.
If you don't know whether it is a volume version, please install the corresponding Volume licenses before using GVLKs.
Activate Office via KMS requires a KMS server address, otherwise Office cannot be activated.

For more information, please visit [GVLKs for KMS and Active Directory-based activation of Office 2019 and Office 2016](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/gvlks)

```txt
Office 2019 GVLKs

Office Pro Plus 2019	NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019	6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019		B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019		C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019		9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019		7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019		9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019		TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019		7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019		RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019		G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business	NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019		PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

Office 2016 GVLKs

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
PowerPoint 2016		J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016		F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business	869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016		WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
```

### Office 365 Pro Plus Retail Grace Key

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

If you don't know what it is, please don't use it. And it can't be used to activate Office.
