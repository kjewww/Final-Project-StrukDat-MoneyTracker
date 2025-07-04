﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class Category
    {
        private decimal TotalAmount { get; set; }
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
            set { _name = value; }
        }

        public void AddRecord(Record record)
        {
            recordList.Add(record);
            TotalAmount += record.Amount;
        }

        public void DisplayRecords()
        {
            Console.WriteLine($"Records for category '{Name}':");
            recordList.DisplayRecords();
        }

        public void RemoveRecord(int id)
        {
            if (recordList.head == null)
            {
                Console.WriteLine("No records available to remove.");
                return;
            }

            RNode current = recordList.head;
            RNode previous = null;
            while (current != null)
            {
                if (current.Data.id == id)
                {
                    if (previous == null)
                    {
                        recordList.head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    Account.AddSaldo(current.Data.Amount);
                    TotalAmount -= current.Data.Amount;
                    return;
                }

                previous = current;
                current = current.Next;
            }

        }

        public decimal GetAmount()
        {
            return TotalAmount;
        }
    }
}
