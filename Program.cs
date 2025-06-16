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
            CategoryList categoryList = new CategoryList();

            while (true)
            {
                Console.WriteLine("=== ^v^// GoldenCeleng here for ur Money Tracker ^o^// ===\n");
                Console.WriteLine("Menu List:\n");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. View Category");
                Console.WriteLine("3. Add Record");
                Console.WriteLine("4. View Record");
                Console.WriteLine("\nPlease input menu number! :v");
                Console.WriteLine("Try inputting '1' for adding category :)");

                //var KeyInput = Console.ReadKey(true);

                switch (Console.ReadLine())
                {
                    case "1": // Nambah Kategori
                        //Console.WriteLine("Please Enter Category Name..");
                        //string categoryName = Console.ReadLine()?.Trim();
                        //Category newCategory = new Category(categoryName);
                        //categoryList.Add(newCategory);
                        //Console.WriteLine($"\nCategory '{categoryName}' added successfully!");

                        Console.WriteLine("Please Enter Category Name..");
                        string categoryName = Console.ReadLine()?.Trim();

                        try
                        {
                            if (categoryList.GetCategory(categoryName) != null)
                            {
                                Console.WriteLine("Error: Category already exists!");
                            }
                            else
                            {
                                Category newCategory = new Category(categoryName);
                                categoryList.Add(newCategory);
                                Console.WriteLine($"\nCategory '{categoryName}' added successfully!");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                        break;

                    case "2": // liat kategori
                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("No categories available.");
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nAvailable Categories:");
                        categoryList.DisplayCategories();

                        Console.WriteLine("\nPress any button to continue...");
                        Console.ReadLine();
                        break;

                    //case "3":
                    //Console.WriteLine("Input Category name..");
                    //Console.WriteLine("\nAvailable Categories:");
                    //categoryList.DisplayCategories();
                    //string selectedCategoryName = Console.ReadLine()?.Trim();

                    //Category selectedCategory = categoryList.GetCategory(selectedCategoryName);

                    //Console.WriteLine("Input Record Name..");
                    //string recordTitle = Console.ReadLine()?.Trim();

                    //Console.WriteLine("Input Record Amount.. (decimal, not negative)");
                    //string Amount = Console.ReadLine()?.Trim();
                    //decimal recordAmount = decimal.Parse(Amount);

                    //DateTime recordDate = DateTime.Now;

                    //Console.WriteLine("Input Record Description..");
                    //string Description = Console.ReadLine()?.Trim();

                    //Record newRecord = new Record(recordTitle, recordDate, recordAmount, Description, selectedCategory);
                    //selectedCategory.AddRecord(newRecord);

                    //Console.WriteLine("Press any button to continue...");
                    //Console.ReadLine();
                    //break;

                    case "3": // Add Record
                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("No categories available. Please add a category first.");
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Input Category name..");
                        Console.WriteLine("\nAvailable Categories:");
                        categoryList.DisplayCategories();

                        string selectedCategoryName = Console.ReadLine()?.Trim();
                        Category selectedCategory = categoryList.GetCategory(selectedCategoryName);

                        if (selectedCategory == null)
                        {
                            Console.WriteLine("Error: Category not found.");
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            break;
                        }

                        try
                        {
                            Console.WriteLine("Input Record Title (max 20 char, no symbol):");
                            string recordTitle = Console.ReadLine()?.Trim();

                            Console.WriteLine("Input Record Amount (decimal, not negative):");
                            string amountInput = Console.ReadLine()?.Trim();
                            if (!decimal.TryParse(amountInput, out decimal recordAmount))
                            {
                                Console.WriteLine("Error: Invalid amount format.");
                                break;
                            }

                            DateTime recordDate = DateTime.Now;

                            Console.WriteLine("Input Record Description (max 50 char):");
                            string description = Console.ReadLine()?.Trim();

                            Record newRecord = new Record(recordTitle, recordDate, recordAmount, description, selectedCategory);
                            selectedCategory.AddRecord(newRecord);

                            Console.WriteLine("Record successfully added!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                        break;


                    case "4": // View Record
                        if (categoryList.IsEmpty())
                        {
                            Console.WriteLine("No categories available. Please add a category first.");
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("1. View by Category (A-Z)");
                        Console.WriteLine("2. View by Date (A-Z)");
                        Console.WriteLine("3. View by Amount (Biggest to Lowest)");

                        switch (Console.ReadLine())
                        {
                            case "1": // By Category

                                Console.WriteLine("\nAvailable Categories:");
                                categoryList.DisplayCategories();

                                Console.WriteLine("\nPlease Select Category..");
                                string selectedCategoryView = Console.ReadLine()?.Trim();

                                if (!categoryList.IsEmpty() && categoryList.GetCategory(selectedCategoryView) == null || string.IsNullOrEmpty(selectedCategoryView))
                                {
                                    Console.WriteLine("Error: Category not found.");
                                    Console.WriteLine("Press any button to continue...");
                                    Console.ReadLine();
                                    break;
                                }

                                Category CategoryView = categoryList.GetCategory(selectedCategoryView);
                                break;

                            case "2":
                                // Display records grouped by date
                                break;

                            case "3":
                                // Display records sorted by amount
                                break;
                        }


                        Console.WriteLine("\nPress any button to continue...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("ngetik yg bener lah ngab :))..");

                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
