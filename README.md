# MoneyTracker

## Kelompok :
1. Ahmad Habibie Dewa Pratama (5053241019)
2. Muhammad Zaki Alfikri (5053241034)

## Class yang digunakan
- 'Category' : Kelas ini memiliki atribut nama kategori dan listrecord yang berisi daftar pengeluaran atau pemasukan.
- 'Record' : Kelas ini memiliki atribut tanggal, jumlah, dan deskripsi dari pengeluaran atau pemasukan.
- 'CategoryList' : Kelas ini memiliki atribut listcategory yang berisi daftar kategori.
- 'RecordList' : Kelas ini memiliki atribut listrecord yang berisi daftar record.
- 'Hashmap' : Kelas ini digunakan untuk menyimpan kategori dan record dalam bentuk dictionary.

## Penjelasan Cara Pengoperasian dan Fungsi yang digunakan
### 1. Tambah Kategori 
#### 1.1 Tulis Nama Kategori (string, max 20 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
Untuk pertama kali, program akan membuat CategoryList kosong, kemudian user akan diminta untuk memasukkan nama kategori. Nama kategori harus berupa string dengan panjang maksimal 20 karakter, tidak boleh kosong, tidak boleh angka, dan tidak boleh ada simbol selain spasi. 
Huruf besar/kecil bebas. 

#### 1.2 Simpan Kategori ke dalam linked list (kategori tidak boleh sama, tidak boleh ada duplikat, jika sudah ada tampilkan pesan error)
Jika nama kategori sudah ada, maka program akan menampilkan pesan bahwa kategori sudah ada. Jika nama kategori valid, maka program akan membuat objek Category dengan nama kategori yang dimasukkan dan menambahkannya ke dalam CategoryList.
Caategory list menggunakan linked list, dalam menyimpan data kategori, sehingga data kategori dapat ditambahkan, dihapus, dan ditampilkan dengan mudah.

#### 1.3 Tampilkan pesan sukses jika berhasil menambah kategori
Jika kategori berhasil ditambahkan, maka program akan menampilkan pesan sukses.

#### 1.4 Tampilkan pesan error jika gagal menambah kategori
Jika terjadi kesalahan seperti lebih dari 20 karakter, kosong, ada spasi, atau berupa angka saat menambah kategori, maka program akan menampilkan pesan error sesuai kesalahan input yang ada. 

#### 1.5 Tampilkan pesan error jika kategori sudah ada
Jika kategori sudah ada, maka program akan menampilkan pesan error "Category already exists.".

#### 1.6 Tampilkan pesan error jika nama kategori tidak valid (tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
Jika nama kategori tidak valid, maka program akan menampilkan pesan error "Invalid category name.".


### 2. Lihat Kategori
#### 2.1 Tampilkan semua kategori yang sudah ada, diurutkan berdasarkan nama kategori (A-Z)
Program akan menampilkan semua kategori yang sudah ada, diurutkan berdasarkan nama kategori (A-Z). Kategori yang ditampilkan adalah kategori yang sudah ditambahkan sebelumnya.

#### 2.2 Tampilkan pesan jika tidak ada kategori yang ada
Jika tidak ada kategori yang ada, maka program akan menampilkan pesan "No categories available.".

#### 2.3 Tampilkan pesan sukses jika berhasil menampilkan kategori
Jika berhasil menampilkan kategori, maka program akan menampilkan pesan sukses "Categories displayed successfully.".

#### 2.4 Tampilkan pesan error jika gagal menampilkan kategori
Jika terjadi kesalahan saat menampilkan kategori, maka program akan menampilkan pesan error "Failed to display categories.".


### 3. Tambah Record (Harus ada kategori terlebih dahulu)
#### 3.1 Pilih Kategori Record (pilih dari kategori yang sudah ada, tidak boleh kosong, harus valid)
Program akan meminta user untuk memilih kategori yang sudah ada. Kategori yang dipilih harus valid, tidak boleh kosong, dan harus ada dalam daftar kategori yang sudah ditambahkan sebelumnya

#### 3.2 Tulis Judul Record (string, max 20 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
Program akan meminta user untuk memasukkan judul record. Judul record harus berupa string dengan panjang maksimal 20 karakter, tidak boleh kosong, tidak boleh angka, dan tidak boleh ada simbol selain spasi. Huruf besar/kecil bebas.

#### 3.3 Tanggal Record Otomatis diisi dengan tanggal hari ini
Program akan mengisi tanggal record secara otomatis dengan tanggal hari ini. Tanggal ini akan digunakan untuk mencatat kapan record tersebut dibuat.

#### 3.4 Tulis Jumlah Record (decimal, tidak boleh kosong, harus valid, tidak boleh negatif)
Program akan meminta user untuk memasukkan jumlah record. Jumlah record harus berupa angka desimal, tidak boleh kosong, harus valid, dan tidak boleh negatif. Jika jumlah record tidak valid,

#### 3.5 Tulis Deskripsi Record (string, max 50 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas) 
Program akan meminta user untuk memasukkan deskripsi record. Deskripsi record harus berupa string dengan panjang maksimal 50 karakter, tidak boleh kosong, tidak boleh angka, dan tidak boleh ada simbol selain spasi. Huruf besar/kecil bebas.

#### 3.6 Simpan Record ke dalam linked list
Jika semua input valid, program akan membuat objek Record dengan kategori yang dipilih, judul, tanggal, jumlah, dan deskripsi yang dimasukkan. Record ini kemudian akan disimpan ke dalam RecordList yang merupakan linked list untuk menyimpan daftar record.

#### 3.7 Tampilkan pesan sukses jika berhasil menambah record
Jika record berhasil ditambahkan, maka program akan menampilkan pesan sukses "Record added successfully.".


### 4. Lihat Record - group by category (A-Z).
#### 4.1 Tampilkan semua record yang ada, di Group by Kategori (A-Z)
Program akan menampilkan semua record yang ada, dikelompokkan berdasarkan kategori. Kategori akan diurutkan dari A-Z. Setiap kategori akan menampilkan daftar record yang terkait dengan kategori tersebut.


### 5. Hapus Category atau Record (Harus ada category atau record terlebih dahulu)
#### 5.1 Hapus Record (pilih dari record yang sudah ada, tidak boleh kosong, harus valid)
Program akan meminta user untuk memilih record yang ingin dihapus. Record yang dipilih harus valid, tidak boleh kosong, dan harus ada dalam daftar record yang sudah ditambahkan sebelumnya.Maka saldo akan ditambah sesuai dengan jumlah record yang dihapus. Record yang dipilih akan dihapus dari RecordList.

#### 5.2 Hapus Category (pilih dari category yang sudah ada, tidak boleh kosong, harus valid)
Program akan meminta user untuk memilih kategori yang ingin dihapus. Kategori yang dipilih harus valid, tidak boleh kosong, dan harus ada dalam daftar kategori yang sudah ditambahkan sebelumnya.Category yang dipilih akan dihapus beserta semua record yang terkait dengan kategori tersebut.
maka saldo akan ditambah sesuai dengan jumlah record yang dihapus. Kategori yang dipilih akan dihapus dari CategoryList.

### 6. Tambah Saldo
program akan meminta user untuk memasukkan jumlah saldo yang ingin ditambahkan. Jumlah saldo harus berupa angka desimal, tidak boleh kosong, harus valid, dan tidak boleh negatif. Jika jumlah saldo tidak valid, program akan menampilkan pesan error.

