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

        public Record(string title, DateTime date, decimal amount, string description, Category category)
        {
            _title = title;
            _date = date;
            _amount = amount;
            _description = description;
            _category = category;
        }
    }
}
