using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class RNode
    {
        public Record Data;
        public RNode Next;

        public RNode(Record data)
        {
            Data = data;
            Next = null;
        }
    }
    public class RecordList
    {
        public RNode head;

        public RecordList()
        {
            head = null;
        }

        public void Add(Record record)
        {
            RNode newNode = new RNode(record);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                RNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void DisplayRecords()
        {
            if (head == null)
            {
                Console.WriteLine("No records available.");
                return;
            }
            RNode current = head;
            while (current != null)
            {
                Console.WriteLine($"- {current.Data.id} | {current.Data.Title} | {current.Data.Date.ToShortDateString()} | {current.Data.Amount:C} | {current.Data.Description}");
                current = current.Next;
            }
        }

        
    }
}
