# Office Tool Plus Localization

ไฟล์ XAML เป็นไฟล์ที่แปลเป็นภาษาท้องถิ่นซึ่งใช้โดย Office Tool Plus เราขอแนะนำให้คุณใช้ VScode หรือตัวแก้ไขอื่นสำหรับการแปล

## Precautions

อย่าเปลี่ยนสตริงหรือคำเช่นนี้:

```xml
<!-- Channels Name -->
{0}
{1}
&#x000A;
```

## Verify Error Code

รหัสข้อผิดพลาดเช่น **0xC004E015** หรือ **0x2** คุณสามารถตรวจสอบเนื้อหาได้โดยเรียกใช้คำสั่ง ```slui 0x2a 0xC004E015```

## How To Test Your Translation (For V8)

1. บันทึกไฟล์การแปลของคุณไปยังเส้นทาง เช่น ```D:\Test\de-de.xaml```

2. เปิด Office Tool Plus

3. กด <kbd>Ctrl+P</kbd>, พิมพ์คำสั่ง  ```/LoadDict D:\Test\de-de.xaml```

4. กด <kbd>Enter</kbd> และ Office Tool Plus จะโหลดพจนานุกรม

5. หากต้องการลบพจนานุกรมของคุณ ให้พิมพ์คำสั่ง และ ```/ClDict``` เรียกใช้
