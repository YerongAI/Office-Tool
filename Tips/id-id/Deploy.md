# Tentang Pemasangan

Di sini anda bisa mengatur produk Office yang dipasang sekarang dan paket bahasa. Apabila anda belum punya Office yang terpasang, anda bisa melakukan pemasangan baru.

Anda bisa menentukan nomor versi dan tanggal rilis pada setiap saluran dalam Informasi Versi. Terakhir, anda bisa menentukan versi pada waktu diunduh atau pemasangan. Apabila tidak ditentukan, umumnya akan dipasangkan versi terakhir.

**Catatan: Office hanya bisa dipasang pada partisi sistem. Ini sudah diatur oleh Microsoft.**

## Konten

---

1. Modul Pemasangan
2. Pengaturan Saluran
3. Pemasangan Baru
4. Tambah Atau Buang Produk/Paket Bahasa
5. ID Produk Office 365
6. Berkas Pemasangan
7. Unduhan Berkas Pemasangan
8. Konfigurasi Office

## Modul Pemasangan

---

Office Deployment Tool merupakan alat resmi dari Microsoft untuk memasang Office, dan Office Tool Plus mendukung hampir semua pengaturan parameter. Office Tool Plus adalah modul kecil yang dikembangkan untuk memasang Office. Fungsionalitasnya tidak sekuat Office Deployment Tool, namun itu juga bisa memasang Office dengan lancar.

[Situs Resmi Office Deployment Tool](https://aka.ms/ODT)

[Pilihan Konfigurasi Office Deployment Tool](https://docs.microsoft.com/en-us/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Alat Kustomisasi Office](https://config.office.com/deploymentsettings)

**Apabila anda ingin memasang Office 2019 Volume di Windows 7, silakan ganti modul ke Office Tool Plus!**

`Catatan: Ketika anda memiliki masalah dengan Office Deployment Tool, cobalah modul Office Tool Plus!`

## Pengaturan Saluran

---

`Office, Visio, Project 2019 [Volume] Hanya bisa mendukung di Office 2019 Perpetual Enterprise Channel, dan tidak bisa digabungkan dengan produk lain (Seperti Office 365).`
Apabila anda ingin memasangan Visio walau anda mempunyai Office 365 yang terpasang, Pilih Visio 2016 Retail/Volume atau Visio 2019 Retail (Project pun sama).

Office 2016/2019 [Retail]/365 bisa memilih saluran lain (kecuali Office 2019 Perpetual Enterprise Channel). Saran kami gunakan Monthly Channel, dan pekerja kantoran siapapun tidak peduli tentang fitur baru bisa memilih saluran Semi-Annual. **Apabila anda mengalami masalah dengan saluran Targeted/Insider/Dogfood, pecahkan masalah itu sendirimu.**

## Pemasangan Baru

---

Sebelum memulai, kami menyarankan untuk membaca pilihan pengaturan saluran terlebih dulu.

Klik tombol [+ Tambah produk] dan pilih yang anda inginkan. Untuk Office/Visio, anda bisa membuang aplikasi yang tidak diinginkan **(Groove berarti OneDrive for Business, Lync berarti Skype for Business)**.

Klik tombol [+ Tambah paket bahasa] dan pilih bahasa anda. Apabila anda tidak menentukan paket bahasa, Office Tool Plus akan mencocokkan dengan bahasa bawaan sistem (Apabila tidak bisa beradaptasi, [en-us] - English (US) akan dipasang sebagai bahasa utama).

Lalu klik tombol [Pasangkan Office] untuk memulai.

`Catatan: Apabila anda menambahkan paket bahasa secara manual, silakan tambahkan setidaknya satu paket bahasa yang bertipe [Penuh].`

## Tambah Atau Buang Produk/Paket Bahasa

---

Apabila komputer anda sudah dipasang Office sebelumnya, anda bisa menambahkan atau membuang produk/paket bahasa melalui Office Tool Plus.

### Tambah Produk/Paket Bahasa

Tinggal klik tombol [+ Tambah produk]/[+ Tambah paket bahasa] dan pilih apa yang anda inginkan.

`Catatan: Untuk mencegah terjadi masalah, JANGAN menambahkan produk/paket bahasa yang sudah dipasang.`

### Mengganti Applikasi

Apabila anda ingin mengganti salah satu aplikasi pada produk, silakan pilih produknya lebih dulu, lalu pilih aplikasi yang diinginkan, buang aplikasi yang tidak diinginkan, terakhir klik tombol [Pasangkan Office].

### Buang Produk/Paket Bahasa

Cek daftar produk/paket bahasa yang akan dibuang, lalu klik submenu "Membuang produk/paket bahasa terpilih" dari tombol [Pasangkan Office] untuk memulai.

## ID Produk Office 365

---

```txt
Office 365 ProPlus		O365ProPlusRetail
Office 365 Enterprise E3		O365ProPlusRetail
Office 365 Enterprise E4		O365ProPlusRetail
Office 365 Enterprise E5		O365ProPlusRetail
Office 365 Midsize		O365ProPlusRetail
Office 365 Business		O365BusinessRetail
Office 365 Business Premium	O365BusinessRetail
Office Small Business Premium	O365SmallBusPremRetail
Office 365 Home			O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

Untuk informasi lebih lanjut, silakan kunjungi [Product IDs that are supported by the Office Deployment Tool for Click-to-Run](https://docs.microsoft.com/en-us/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## Berkas Pemasangan

---

Berkas pemasangan merupakan paket pemasangan untuk Office. Office Tool Plus bisa mengunduh berkas pemasangan Office dari server Microsoft servers dan membuat paket ISO. Setelah mengunduh berkas pemasangannya, anda bisa memasang secara offline atau membaginya dengan orang lain untuk menghemat bandwidth ataupun waktu.

Saluran akan menentukan versi Office apa yang akan ada pasang, jadi kami menyarankan untuk membaca pada baris Pengaturan Saluran terlebih dulu.

Klik submenu "Unduh berkas pemasangan" dari Mengelola Berkas Pemasangan untuk memulainya. Anda bisa mengaturnya sendiri atau menggunakan pengaturan bawaan Office Tool Plus, lalu klik tombol [Mulai] untuk mengunduh.

![Unduh Berkas Pemasangan](https://server.coolhub.top/OfficeTool/images/en-us/DownloadPanel.png)

### Informasi Lebih

[Ikhtisar pembaruan saluran Office 365 ProPlus](https://docs.microsoft.com/en-us/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Histori Pembaruan Office 365 ProPlus](https://docs.microsoft.com/en-us/officeupdates/update-history-office365-proplus-by-date)

[Pembaruan saluran Office 2019](https://docs.microsoft.com/en-us/DeployOffice/office2019/update#update-channel-for-office-2019)

## Unduh Berkas Pemasangan 

---

Sebagai tambahan untuk mengunduh berkas pemasangan menggunakan Office Deployment Tool, Office Tool Plus juga memasukkan Thunder, memperbolehkan pengguna untuk menguduh berkas pemasangan Office secara cepat. Mereka tidak memiliki perbedaan fungsi umumnya, `tetapi hanya Thunder yang mendukung tampilan progress unduhan, pengaturan batas kecepatan dan proxy.` Apabila terdapat masalah dengan unduhan Thunder, silakan untuk beralih ke Office Deployment Tool.

### Pengaturan Batas Kecepatan Thunder

Untuk mengatur batas kecepatan unduh ketika menggunakan Thunder, silakan klik angka kecepatan unduh ketika proses unduhan berjalan, dan aturkan batas kecepatannya pada kotak dialog pop-up. Untuk membatalkannya, atur batas kecepatan ke 0.

## Office Configuration

---

`Pada sisi kanan halaman pemasangan, anda bisa memanggil panel Konfigurasi Office.`
Office Tool Plus mendukungn modifikasi saluran pembaruan Office dan juga mendukung memodifikasi tampilan pemilik di Office. Sekali diedit, klik [Simpan] untuk memberlakukan pengaturan.

Apabia anda memiliki masalah dengan Office, anda bisa memperbaiki Office di sini.

**Catatan: Apabila anda mengklik [Muat ulang], daftar produk dan paket bahasa di sisi kiri akan dimuat ulang dan sejumlah pengaturan kembali ke bawaan.**
