using MoneyTracker;

public class HashMap
{
    public class Entry
    {
        public string Key;
        public Category Value;
        public Entry Next;

        public Entry(string key, Category value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    public Entry[] buckets;
    private const int Size = 101;
    public int SIZE => buckets.Length; // Property to get the size of the HashMap

    public HashMap()
    {
        buckets = new Entry[Size];
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
        return Get(key) != null;
    }

    public Category Get(string key) // Mengambil value berdasarkan key
    {
        int index = GetHash(key);
        Entry current = buckets[index];
        while (current != null)
        {
            if (current.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                return current.Value;
            current = current.Next;
        }
        return null;
    }

    public bool Add(string key, Category value) // Menambahkan key-value pair ke HashMap
    {
        int index = GetHash(key);
        Entry current = buckets[index];
        while (current != null)
        {
            if (current.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                return false; // Duplicate
            current = current.Next;
        }

        Entry newEntry = new Entry(key, value);
        newEntry.Next = buckets[index];
        buckets[index] = newEntry;
        return true;
    }

    public bool Remove(string key) // Menghapus key-value pair dari HashMap
    {
        int index = GetHash(key);
        Entry current = buckets[index];
        Entry previous = null;

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
}
