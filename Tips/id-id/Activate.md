# Tentang Aktivasi

```txt
Apabila anda gagal mengaktivasi Office dengan alat ini, silakan cek operasian anda terlebih dulu (Terdapat tahapan pada instruksi di bawah ini). Apabila masih bermasalah juga, silakan cek sistem operasi anda. Setelah berhasil diaktivasi, segalanya sudah siap bersedia.
```

## konten

---

1. Pasang atau Beralih Lisensi
2. Aktivasi Lisensi (Aktivasi Office)
3. Cek Server KMS
4. Kueri Status Aktivasi
5. Mengatur Aktivasi Office
6. Kunci Generik Volume License (GVLK)

## Pasang Lisensi

---

Ketika dipasangnya lisensi, itu bisa diaktifkan dengan kunci yang sesuai.
Misalnya: Apabila anda ingin Office 2016 Retail -> Office 2016 Volume, hanya perlu memasang Office 2016 Volume license.
Setelah pemasangannya, kunci yang lama tidak akan tertimpa. Jadi, kita mempunyai banyak lisensi dalam satu program perangkat lunak.

Apabila anda ingin memasang lisensi di berkas lisensi lokal, tinggal klik tombol click the [...].

`Catatan: Apabila Office anda yang terpasang merupakan basis dari versi C2R, Office Tool Plus akan coba membaca semua lisensi dan menampilkan nya di drop down box. Selain itu hanya Volume licenses bawaan yang akan ditampilkan.`

## Aktivasi Lisensi

---

`Catatan: Satu-satunya cara untuk mengaktivasikan Office 365 adalah masukkan akun Office 365 anda.`

### Aktivasi Secara Online

`Pastikan bahwa kunci anda valid dan versinya tepat sebelum melakukan aktivasi.` Masukan kunci dan klik tombol [Pasang kunci], lalu klik [Aktifkan], Aktivasi Office akan berhasil. Ini juga bisa dilakukan melalui Office.
Setelah aktivasinya berhasil, Office akan tetap aktif.

### Aktivasi Melalui Telepon

`Pastikan bahwa kunci anda bisa dipakai untuk aktivasi melalui telepon` dan pasang kuncinya. Dalam submenu tombol [Pasang kunci], klik "Tampilkan ID Instalasi (IID)". Setelah mendapatkan ID Konfirmasi, masukkan ID Konfirmasi anda tanpa blok dan klik submenu "Pasang ID Konfirmasi (CID)". Setelah aktivasinya berhasil, Office akan tetap aktif.

### Aktivasi Melalui KMS

Pastikan Office anda terpasang dengan versi Volume License. Apabila anda tidak mengetahui ini adalah versi Volume License, silakan pasang lisensi Volume license yang cocok. Misalnya, Apabila anda ingin mengaktivasi Office 2016, Tinggal perlu pasang Office 2016 Volume license. Lalu anda perlu memasukkan alamat server KMS yang valid, `jangan lupa klik tombol [Atur alamat server]`. Ketika semua konfigurasinya sudah tepat, jaringannya normal, dan server KMS-nya normal, Klik tombol [Aktifkan]. Berhasil? Silakan menikmati!

## Cek Server KMS

---

Masukkan server KMS dan klik submenu "Cek status KMS".

Secara umum hasilnya akan mengikuti seperti :
Connecting to 192.168.123.1:1688 ... successful
Sending activation request (KMS V4) 1 of 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

"successful" berarti anda bisa terhubung ke server, "Sending activation request" berarti server-nya bekerja.

Apabila anda tidak melihat seperti ini, kemungkinan ada masalah dengan server KMS ini atau jaringan.

## Kueri Status Aktivasi
---

Klik tombol [Tampilkan informasi aktivasi] di bawah untuk melihat informasi lisensi dari kunci yang terpasang.

`Catatan: Status lisensi Office yang diaktifkan hanya ---BERLISENSI--- .`

## Mengatur Aktivasi Office

---

### Copot Kunci Produk Office

Klik tombol [Tampilkan informasi aktivasi] di bawah untuk melihat informasi lisensi dari kunci yang terpasang.

Salin 5 karakter terakhir dari kunci produk yang terpasang, tempelkan ke kotak masukkan Manajemen Kunci, lalu klik submenu "Copot kunci".

![Copot Kunci Produk Office](https://server.coolhub.top/OfficeTool/images/en-us/UninstallKey.png)

### Copot Semua Kunci Produk Office

Dalam submenu Manajemen Kunci, anda bisa mencopot semua kunci.
Setelah kuncinya dicopot, semua aktivasi akan dibersihkan, anda perlu mengaktivasi ulang Office.

### Bersihkan Semua Lisensi Office

Dalam submenu Manajemen Lisensi, anda bisa membersihkan lisensi.
Setelah lisensinya dibersihkan, anda perlu memperbaiki Office pada anda membuka aplikasi Office pertama kali (Office akan mengatur ulang lisensi ke bawaan).
Atau anda bisa memasang lisensi secara manual. Terakhir, anda bisa mengaktivasikan Office lagi.

**Submenu "Bersihkan aktivasi" berarti semua operasi diatas akan berjalan.**

## Kunci Generik Volume License (GVLK)

---

Pastikan Office anda terpasang dengan versi Volume License sebelum menggunakan GVLK.
Apabila anda tidak mengetahui ini adalah versi Volume License, silakan pasang lisensi Volume license yang cocok sebelum menggunakan GVLK.
Aktivasi Office melalui KMS membutuhkan alamat server KMS, selain itu tidak bisa diaktivasikan.

Untuk informasi lebih lanjut, silakan kunjungi [GVLKs for KMS and Active Directory-based activation of Office 2019 and Office 2016](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/gvlks)

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
PowerPoint 2019		RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
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
PowerPoint 2016		J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016		F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business	869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016		WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
```

### Kunci Masa Tegang Office 365 Pro Plus Retail

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

Apa bila anda tidak mengetahui apa ini, mohon jangan digunakan. Dan ini tidak bisa digunakan untuk mengaktivasi Office.
