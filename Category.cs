using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class Category
    {
        private string _name;
        private RecordList recordList = new RecordList();

        public Category(string name)
        {
            Name = name;
            recordList = new RecordList();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 20 || !IsValidCategoryName(value))
                {
                    throw new ArgumentException("Invalid category name.");
                }
                _name = value;
            }
        }

        private bool IsValidCategoryName(string name)
        {
            // Check if the name contains only letters and spaces
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public void AddRecord(Record record)
        {
            recordList.Add(record);
        }

        public void DisplayRecords()
        {
            Console.WriteLine($"Records for category '{Name}':");
            recordList.DisplayRecords();
        }
    }
}
