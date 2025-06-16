using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public CategoryList()
        {
            head = null;
        }

        public void Add(Category category)
        {
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
            CNode current = head;
            while (current != null)
            {
                if (current.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
