// 1. Nambah Kategori
// 1.1 Tulis Nama Kategori (string, max 20 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
// 1.2 Simpan Kategori ke dalam linked list (kategori tidak boleh sama, tidak boleh ada duplikat, jika sudah ada tampilkan pesan error)
// 1.3 Tampilkan pesan sukses jika berhasil menambah kategori
// 1.4 Tampilkan pesan error jika gagal menambah kategori
// 1.5 Tampilkan pesan error jika kategori sudah ada
// 1.6 Tampilkan pesan error jika nama kategori tidak valid (tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
// 1.7 Tampilkan pesan error jika nama kategori lebih dari 20 karakter

// 2. Lihat Kategori
// 2.1 Tampilkan semua kategori yang sudah ada, diurutkan berdasarkan nama kategori (A-Z)
// 2.2 Tampilkan pesan jika tidak ada kategori yang ada
// 2.3 Tampilkan pesan sukses jika berhasil menampilkan kategori
// 2.4 Tampilkan pesan error jika gagal menampilkan kategori

// 3. Nambah Record (Harus ada kategori terlebih dahulu)
// 3.1 Pilih Kategori Record (pilih dari kategori yang sudah ada, tidak boleh kosong, harus valid)
// 3.2 Tulis Judul Record (string, max 20 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas)
// 3.3 Tanggal Record Otomatis diisi dengan tanggal hari ini
// 3.4 Tulis Jumlah Record (decimal, tidak boleh kosong, harus valid, tidak boleh negatif)
// 3.5 Tulis Deskripsi Record (string, max 50 karakter, tidak boleh kosong, tidak boleh angka, tidak boleh ada simbol selain spasi, huruf besar/kecil bebas) 
// 3.6 Simpan Record ke dalam linked list
// 3.7 Tampilkan pesan sukses jika berhasil menambah record

// 4. Lihat Record - group by category (A-Z), group by date (), sort by amount (biggest to lowest).
// 4.1 Tampilkan semua record yang ada, di Group by Kategori (A-Z)
// 4.2 Tampilkan semua record yang ada, di Group by Tanggal (A-Z)
// 4.3 Tampilkan semua record yang ada, di Sort by Jumlah (terbesar ke terkecil) 

namespace MoneyTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CategoryList categoryList = new CategoryList();
            //CategoryMap categoryList = new CategoryMap();
            CategoryMapp categoryList = new CategoryMapp();
            Category KategoriPemasukan = new("Pemasukan");
            categoryList.AddCategory("Pemasukan", KategoriPemasukan);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ^v^// GoldenCeleng here for ur Money Tracker ^o^// ===\n");
                Console.WriteLine("Menu List:\n");
                Console.WriteLine("1. Tambah Kategori");
                Console.WriteLine("2. Lihat Katagori");
                Console.WriteLine("3. Tambah Record");
                Console.WriteLine("4. Lihat Record");
                Console.WriteLine("5. Hapus Kategori");
                Console.WriteLine("6. Hapus Record");
                Console.WriteLine("7. Tambah Saldo");
                Console.WriteLine("8. Cek Saldo");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nMasukkan angka :v");
                Console.WriteLine("Contoh Ketik '1' untuk Tambah Kategori :)");

                switch (Console.ReadLine())
                {
                    case "1": // Nambah Kategori

                        Console.WriteLine("Masukkan Nama Kategori! :D");
                        string categoryName = Console.ReadLine()?.Trim();

                        try
                        {
                            if (categoryList.GetCategory(categoryName) != null)
                            {
                                Console.WriteLine("Kategori sudah terdaftar :))");
                            }
                            else
                            {
                                Category newCategory = new Category(categoryName);
                                categoryList.Add(newCategory);
                                Console.WriteLine($"\nKategori '{categoryName}' berhasil ditambahkan :D");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;

                    case "2": // liat kategori

                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("Tidak ada kategori terdaftar");
                            Console.WriteLine("Tekan 'Enter' untuk lanjut");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nDaftar Kategori:");
                        categoryList.DisplayCategories();

                        Console.WriteLine("\nTekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;

                    case "3": // Add Record

                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("Tidak ada kategori terdaftar. Tolong tambahkan satu!");
                            Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nDaftar Kategori:");
                        categoryList.DisplayCategories();

                        Category selectedCategory = null;
                        while(selectedCategory == null)
                        {
                            Console.WriteLine("\nMasukkan nama kategori..");
                            string selectedCategoryName = Console.ReadLine()?.Trim();

                            selectedCategory = categoryList.GetCategory(selectedCategoryName);
                            if(selectedCategory == null)
                            {
                                Console.WriteLine("Kategori tidak ditemukan. Coba lagi..");
                            }
                        }

                        try
                        {
                            Console.WriteLine("Masukkan Judul Record:");
                            string recordTitle = Console.ReadLine()?.Trim();

                            Console.WriteLine("Masukkan Jumlah dalam Rupiah:");
                            string amountInput = Console.ReadLine()?.Trim();
                            if (!decimal.TryParse(amountInput, out decimal recordAmount))
                            {
                                Console.WriteLine("Jumlah Invalid!");
                                break;
                            }

                            DateTime recordDate = DateTime.Now;

                            Console.WriteLine("Masukkan Deskripsi:"); // max 50 karakter
                            string description = Console.ReadLine()?.Trim();

                            bool isPemasukan = false;

                            Record newRecord = new Record(recordTitle, recordDate, recordAmount, description, selectedCategory, isPemasukan);
                            selectedCategory.AddRecord(newRecord);
                            Account.Withdraw(recordAmount);

                            Console.WriteLine("Record berhasil ditambahkan :D");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;


                    case "4": // View Record

                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("Tidak ada kategori terdaftar, Tolong tambahkan satu!");
                            Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                            Console.ReadLine();
                            break;
                        }
                        
                        Console.WriteLine("\nDaftar Kategori:");
                        categoryList.DisplayCategories();

                        Category selectedCategoryView = null;
                        while (selectedCategoryView == null)
                        {
                            Console.WriteLine("\nPlease enter category name..");
                            string inputCategory_View = Console.ReadLine()?.Trim();

                            selectedCategoryView = categoryList.GetCategory(inputCategory_View);
                            if (selectedCategoryView == null)
                            {
                                Console.WriteLine("Kategori tidak ditemukan, Coba lagi!");
                            }
                        }

                        selectedCategoryView.DisplayRecords();

                        Console.WriteLine("\nTekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;

                    case "5": // Hapus Kategori

                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("Tidak ada kategori terdaftar, Tolong tambahkan satu!");
                            Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                            Console.ReadLine();
                            break;
                        }
                        Console.WriteLine("\nDaftar Kategori:");
                        categoryList.DisplayCategories();
                        Console.WriteLine("\nMasukkan nama kategori yang ingin dihapus:");
                        string deleteCategoryName = Console.ReadLine()?.Trim();
                        try
                        {
                            if (categoryList.GetCategory(deleteCategoryName) == null)
                            {
                                Console.WriteLine("Kategori tidak ditemukan :(");
                            }
                            else
                            {
                                Category selectedCategory_Delete = categoryList.GetCategory(deleteCategoryName);
                                Account.AddSaldo(selectedCategory_Delete.GetAmount());
                                categoryList.RemoveCategory(deleteCategoryName);
                                Console.WriteLine($"Kategori '{deleteCategoryName}' berhasil dihapus :D");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;

                    case "6": // Hapus Record by ID

                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("Tidak ada kategori terdaftar, Tolong tambahkan satu!");
                            Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nDaftar Kategori:");
                        categoryList.DisplayCategories();
                        Category selectedCategoryDelete = null;
                        while (selectedCategoryDelete == null)
                        {
                            Console.WriteLine("\nMasukkan nama kategori yang ingin dihapus recordnya:");
                            string inputCategory_Delete = Console.ReadLine()?.Trim();
                            selectedCategoryDelete = categoryList.GetCategory(inputCategory_Delete);
                            if (selectedCategoryDelete == null)
                            {
                                Console.WriteLine("Kategori tidak ditemukan, Coba lagi!");
                            }
                        }
                        selectedCategoryDelete.DisplayRecords();
                        Console.WriteLine("Masukkan ID Record yang ingin dihapus:");
                        string inputRecordId = Console.ReadLine()?.Trim();
                        if (int.TryParse(inputRecordId, out int recordId))
                        {
                            try
                            {
                                selectedCategoryDelete.RemoveRecord(recordId);
                                Console.WriteLine($"Record dengan ID {recordId} berhasil dihapus :D");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID Record tidak valid!");
                        }

                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;

                    case "7": // Tambah Saldo

                        Console.WriteLine("Silakan Masukkan Jumlah Saldo..");
                        string InputSaldo = Console.ReadLine()?.Trim();
                        decimal AmountSaldo = decimal.Parse(InputSaldo);

                        Console.WriteLine("Masukkan Judul..");
                        string InputJudul = Console.ReadLine()?.Trim();

                        DateTime PemasukanDate = DateTime.Now;

                        Console.WriteLine("Masukkan Deskripsi..");
                        string InputDeskripsi = Console.ReadLine()?.Trim();

                        bool IsPemasukan = true;

                        Record newPemasukan = new(InputJudul, PemasukanDate, AmountSaldo, InputDeskripsi, KategoriPemasukan, IsPemasukan);
                        KategoriPemasukan.AddRecord(newPemasukan);

                        Account.AddSaldo(AmountSaldo);

                        Console.WriteLine("Pemasukan berhasil ditambahkan :D");

                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();

                        break;

                    case "8": // Lihat Saldo

                        Console.WriteLine($"Saldo saat ini: {Account.Saldo}");
                        Console.WriteLine("Tekan 'Enter' untuk lanjut..");
                        Console.ReadLine();
                        break;


                    case "0": // Exit

                        Console.WriteLine("Bye Bye!!");
                        return;

                    default:
                        Console.WriteLine("ngetik yg bener lah ngab :))..");

                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
