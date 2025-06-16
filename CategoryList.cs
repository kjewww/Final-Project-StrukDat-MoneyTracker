using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class CNode
    {
        public Category Data;
        public CNode Next;

        public CNode(Category data)
        {
            Data = data;
            Next = null;
        }
    }
    public class CategoryList
    {
        public CNode head;
        private HashMap map = new HashMap();

        public CategoryList()
        {
            head = null;
        }

        public void Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("Category name cannot be empty.");
            if (category.Name.Length > 20)
                throw new ArgumentException("Category name must not exceed 20 characters.");
            if (!Regex.IsMatch(category.Name, @"^[a-zA-Z\s]+$"))
                throw new ArgumentException("Category name must contain only letters and spaces.");

            if (map.ContainsKey(category.Name))
                throw new ArgumentException("Category already exists.");

            // nambah ke linkedlist
            CNode newNode = new CNode(category);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                CNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }

            // nambah ke Hash
            map.Add(category.Name, category);
        }

        public void DisplayCategories()
        {
            if (head == null)
            {
                Console.WriteLine("No categories available.");
                return;
            }
            CNode current = head;
            while (current != null)
            {
                Console.WriteLine($"- {current.Data.Name}");
                current = current.Next;
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public Category GetCategory(string name)
        {
            return map.Get(name);
        }
    }
}
