# Sistem Parkir Console App

Sistem Parkir Console App adalah aplikasi sederhana yang memungkinkan pengguna untuk mengelola tempat parkir dengan menggunakan console. Aplikasi ini dibangun menggunakan .NET 5.

## Fitur Utama

1. **Check-In:**
    - Semua kendaraan bebas menggunakan lot yang tersedia.
    - Kendaraan yang boleh masuk hanya Mobil Kecil dan Motor.
    - Setiap kendaraan yang masuk dicatat berdasarkan Nomor Polisi-nya.
    - Perhitungan biaya parkir adalah per jam, untuk yang baru masuk sudah dihitung 1 jam.

2. **Check-Out:**
    - Setiap kendaraan yang sudah checkout membuat lot tersebut menjadi tersedia dan dapat digunakan oleh orang lain.

3. **Report:**
    - Laporan jumlah lot yang terisi.
    - Laporan jumlah lot yang tersedia.
    - Laporan jumlah kendaraan berdasarkan nomor kendaraan ganjil dan genap.
    - Laporan jumlah kendaraan berdasarkan jenis kendaraan.
    - Laporan jumlah kendaraan berdasarkan warna kendaraan.

## Cara Menggunakan

1. Install .NET 5.

2. Buka terminal atau command prompt dan arahkan ke direktori tempat Anda menyimpan program ini.

3. Compile dan jalankan aplikasi dengan perintah berikut:

    ```bash
    dotnet run
    ```

4. Ikuti instruksi di console untuk melakukan operasi Check-In, Check-Out, dan melihat laporan.

## Contoh Penggunaan

### Check-In

```bash
$ park B-1234-XYZ Putih Mobil
Allocated slot number: 1

$ park B-9999-XYZ Putih Motor
Allocated slot number: 2

$ leave 1
Slot number 1 is free

$ status
Slot 	No. 		Type	Registration No Colour
1 		B-1234-XYZ	Mobil	Putih
2 		B-9999-XYZ	Motor	Putih

