using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class CategoryMap
    {
        private HashMap map = new HashMap();

        public void Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Category name cannot be empty.");
            if (category.Name.Length > 20)
                throw new ArgumentException("Category name must not exceed 20 characters.");
            if (!System.Text.RegularExpressions.Regex.IsMatch(category.Name, @"^[a-zA-Z\s]+$"))
                throw new ArgumentException("Category name must contain only letters and spaces.");
            if (map.ContainsKey(category.Name))
                throw new ArgumentException("Category already exists.");
            map.Add(category.Name, category);
        }

        public void RemoveCategory(string name)
        {
            if (!map.ContainsKey(name))
                throw new ArgumentException("Category does not exist.");
            map.Remove(name);
        }

        public Category GetCategory(string name)
        {
            //if (!map.ContainsKey(name))
            //    throw new ArgumentException("Category does not exist.");
            return map.Get(name);
        }

        public void DisplayCategories()
        {
            for (int i = 0; i < map.SIZE; i++)
            {
                var entry = map.buckets[i];
                while (entry != null)
                {
                    Console.WriteLine($"- {entry.Value.Name}");
                    entry = entry.Next;
                }
            }
        }

        public bool IsEmpty()
        {
            for (int i = 0; i < map.SIZE; i++)
            {
                if (map.buckets[i] != null)
                    return false;
            }
            return true;
        }
    }
}
