# โปรแกรม Office Tool Plus

[⬅ Back](https://github.com/YerongAI/Office-Tool)

Office Tool Plus คือโปรแกรมสำหรับจัดการ การดาวน์โหลด, การติดตั้งชุดโปรแกรม Office.

Office Tool Plus บนพื้นฐานระบบสำหรับ Deploy ชุดโปรแกรม Microsoft's Office. คุณสามารถปรับแต่งค่าตัวติดตั้ง Office และดาวน์โหลดไฟล์ตัวติดตั้ง Office สำหรับนำไปติดตั้งที่เครื่องอื่นโดยไม่ต้องพึ่งอินเตอร์เน็ต.

และอื่นๆ เช่น จัดการชุดโปรแกรม Office ที่มีอยู่ก่อนแล้ว, เพิ่มชุดภาษาของโปรแกรม Office หรือแม้กระทั่งการปรับแต่งไฟล์ตัวถอนการติดตั้งชุด Office.

## System Requirements

Windows 7 SP1, Windows 8 and Windows 10.

Windows Server 2008 R2 SP1, Windows Server 2012 or higher.

`Microsoft .NET Framework 4.6.1 or higher.`

### Download Microsoft .NET Framework 4.6.1

[Web Installer](http://go.microsoft.com/fwlink/?LinkId=780597)

[Offline Installer](http://go.microsoft.com/fwlink/?LinkId=780601)

[Language Packs for Microsoft .Net Framework 4.6.1](http://go.microsoft.com/fwlink/?LinkId=780604)

## ดาวน์โหลด Office Tool Plus

[ดาวน์โหลดบนเว็บไซต์หลัก](https://otp.landian.vip/)

[ตัวเลือกการดาวน์โหลดอื่นๆ](https://delivery.yuntu.dev/office-tool/) by [云图小镇](https://www.yuntu.dev/)

## บทความเกี่ยวกับเทคนิคการตั้งค่า

[ตัวเลือกการตั้งค่า](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

## การเริ่มต้นใช้งาน

Go to Deploy page, add a product (or more) that you want to install, then click Deploy to start your installation. You can configure other settings if you want.

You need to Activate Office after installation.

## สิทธิตามกฎหมายของโปรแกรม

Office Tool Plus ถูกพัฒนาบนพื้นฐานของชุด Microsoft's [Office Deployment Tool](https://docs.microsoft.com/th-th/DeployOffice/overview-of-the-office-2016-deployment-tool). และเราได้เพิ่มฟังก์ชั่นบางอย่างตามความต้องการของผู้ใช้งาน.

### เกี่ยวกับฟังก์ชั่นการเปิดใช้งานชุดโปรแกรม Office

ฟังก์ชั่นการเปิดใช้งานโปรแกรม บนพื้นฐาน Microsoft's ospp.vbs (Office Software Protect Platform) การเปิดใช้งานทั้งหมดจะดำเนินการผ่าน ospp.vbs
The activate function was based on Microsoft's ospp.vbs (Office Software Protect Platform), all activate operations are performed by ospp.vbs. และเพื่อให้ผู้ใช้เข้าใจ OSPP ได้ดีขึ้นเราจึงทำการแปลเป็นภาษต่าง ๆ (zh-cn, zh-tw).

คุณสามารถดูรายละเอียด OSPP ได้ใน ````"C:\Program Files\Microsoft Office\Office16\OSPP.HTM"```` (ต้องมีโปรแกรม Office ที่ได้ติดตั้งไว้ก่อนแล้ว).

## ขอบคุณผู้ที่มีส่วนร่วมในโครงการ

- (ar-ps) العربية (الأراضي الفلسطينية) / Ibrahim
- (de-de) Deutsch (Deutschland) / [Berny23](https://steamcommunity.com/id/Berny23)
- (en-us) English (United States) / [Moedog](https://prprpr.love)
- (es-es) Español (España, alfabetización internacional) / Xoseba
- (fr-fr) Français (France) / Drake4478
- (id-id) Bahasa Indonesia (Indonesian) / [Ida Bagus Anom Sanjaya](https://fb.me/Anom.Sanjaya17)
- (it-it) Italiano (Italia) / [garf02](https://github.com/garf02)
- (ja-jp) 日本語 (日本) / [秋山ヘイワ](https://github.com/akio1321)
- (ko-kr) 한국어(대한민국) / [Jay Jang](http://www.yaeyaya.com)
- (pl-pl) Polski (Polska) / JakubDriver
- (pt-br) Português (Brasil) / [Hélio de Souza](https://tinyurl.com/hdstec)
- (tr-tr) Türkçe (Türkiye) / Turan Furkan Topak
- (vi-vn) Tiêng Việt (Việt Nam) / [phuocding](https://github.com/phuocding)
- (zh-cn) 简体中文 (中国) / **官方语言 (Official language)**
- (zh-tw) 繁體中文 (台灣) / [Yi Chi](https://www.cotpear.com)

## ช่วยเราแปลภาษา

We encourage everyone to help with localization. The following is how to do.

1. Fork แยกโครงการออกไป

2. ทำการแปลโดยอิงไฟล์ภาษา ````zh-cn.xaml```` แล้วแปลเป็นภาษาที่เราต้องการ จากนั้นตั้งชื่อไฟล์ภาษาให้สอดคล้องกับภาษาที่แปลเสร็จ เช่น ````zh-tw.xaml````

3. คัดลอกไฟ์ภาษาที่ได้ทำการแปลใหม่ ไปไว้ในโฟลเดอร์ให้ถูกต้อง, ตัวอย่างเช่น OfficeToolPlus/Language/zh-tw.xaml

4. สร้าง Pull Request.

### การทดสอบภาษาที่แปลใหม่

1. บันทึกไฟล์ภาษาลงในโฟลเดอร์ Office Tool Plus, เช่น ````D:\Date\zh-cn.xaml````.

2. เปิดโปรแกรม.

3. ไปที่หน้า การตั้งค่า, คลิดเลือก ````โหลดไฟล์ภาษา.````

4. เลือกไฟล์ภาษาที่ต้องการทดสอบ.

หลังจากนั้น โปรแกรมจะทำการโหลดไฟล์ภาษา ถ้าคุณกำลังเพิ่มภาษาใหม่ลงไปยังโปรแกรม คุณจะพบข้อผิดพลาด : พบข้อผิดพลาดการเชื่อมต่อกับเซิร์ฟเวอร์. ซึ่งถือว่ามันปกติ

### เพิ่มเติม

````สำหรับผู้แปลภาษาเราจะมอบ ชุดโปรแกรมสำหรับผู้ดูแล ให้ ซึ่งโปรแกรมรุ่นพิเศษนี้ จะอนุญาตให้คุณเปลี่ยนแปลงประกาศ และสามารถอัพโหลดไฟล์ภาพพื้นหลังของโปรแกรมได้.```` [Send a e-mail](mailto:yerong@coolhub.top) ````ไปหาเรา.````
