using MoneyTracker;

public class CategoryMapp
{
    public class Node
    {
        public string Key;
        public Category Value;
        public Node Next;

        public Node(string key, Category value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public Node[] buckets;
    private const int Size = 101;
    public int SIZE => buckets.Length; // Property to get the size of the HashMap

    public CategoryMapp()
    {
        buckets = new Node[Size];
    }

    private int GetHash(string key) // Hash Function
    {
        int hash = 0;
        foreach (char c in key.ToLower())
        {
            hash = (hash * 31 + c) % Size;
        }
        return hash;
    }

    public bool ContainsKey(string key) // Mengecek apakah key ada di HashMap
    {
        return GetCategory(key) != null;
    }

    public Category GetCategory(string key) // Mengambil value berdasarkan key
    {
        int index = GetHash(key);
        Node current = buckets[index];
        while (current != null)
        {
            if (current.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                return current.Value;
            current = current.Next;
        }
        return null;
    }

    public bool AddCategory(string key, Category value) // Menambahkan key-value pair ke HashMap
    {   
        int index = GetHash(key);
        Node current = buckets[index];
        while (current != null)
        {
            if (current.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                return false; // Duplicate
            current = current.Next;
        }

        Node newNode = new Node(key, value);
        newNode.Next = buckets[index];
        buckets[index] = newNode;
        return true;
    }

    public void Add(Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name))
            throw new ArgumentException("Category name cannot be empty.");
        if (category.Name.Length > 20)
            throw new ArgumentException("Category name must not exceed 20 characters.");
        if (!System.Text.RegularExpressions.Regex.IsMatch(category.Name, @"^[a-zA-Z\s]+$"))
            throw new ArgumentException("Category name must contain only letters and spaces.");
        if (ContainsKey(category.Name))
            throw new ArgumentException("Category already exists.");

        AddCategory(category.Name, category);
    }

    public bool Remove(string key) // Menghapus key-value pair dari HashMap
    {
        if (!ContainsKey(key)) return false;

        int index = GetHash(key);
        Node current = buckets[index];
        Node previous = null;

        while (current != null)
        {
            if (current.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
            {
                if (previous == null)
                {
                    buckets[index] = current.Next; // Remove head
                }
                else
                {
                    previous.Next = current.Next; // Bypass current
                }
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false; // Not found
    }

    public void RemoveCategory(string category)
    {
        int index = GetHash(category);
        Node current = buckets[index];
        Node previous = null;
        while (current != null)
        {
            if(current.Key.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                if (previous == null)
                {
                    buckets[index] = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                previous = current;
                current = current.Next;
            }
        }
    }

    public void DisplayCategories()
    {
        for (int i = 0; i < Size; i++)
        {
            var Node = buckets[i];
            while (Node != null)
            {
                Console.WriteLine($"- {Node.Value.Name}");
                Node = Node.Next;
            }
        }
    }

    public bool IsEmpty()
    {
        for (int i = 0; i < Size; i++)
        {
            if (buckets[i] != null)
                return false;
        }
        return true;
    }
}

