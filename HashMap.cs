using MoneyTracker;

public class HashMap
{
    private class Entry
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

    private Entry[] buckets;
    private const int Size = 101; // Prime number for better distribution

    public HashMap()
    {
        buckets = new Entry[Size];
    }

    private int GetHash(string key)
    {
        int hash = 0;
        foreach (char c in key.ToLower())
        {
            hash = (hash * 31 + c) % Size;
        }
        return hash;
    }

    public bool ContainsKey(string key)
    {
        return Get(key) != null;
    }

    public Category Get(string key)
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

    public bool Add(string key, Category value)
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
}
