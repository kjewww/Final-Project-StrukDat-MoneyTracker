using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class Record
    {
        private string _title;
        private DateTime _date;
        private decimal _amount;
        private string _description;
        private Category _category;

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 20 || !IsValidTitle(value))
                {
                    throw new ArgumentException("Invalid title.");
                }
                _title = value;
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Date cannot be in the future.");
                }
                _date = value;
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative.");
                }
                _amount = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Description cannot exceed 50 characters.");
                }
                _description = value;
            }
        }

        public Category Category
        {
            get { return _category; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Category cannot be null.");
                }
                _category = value;
            }
        }

        public bool IsValidTitle(string title)
        {
            // Check if the title contains only letters, digits, and spaces
            return title.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }

        public Record(string title, DateTime date, decimal amount, string description, Category category)
        {
            Title = title;
            Date = date;
            Amount = amount;
            Description = description;
            Category = category;
        }
    }
}
