using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker
{
    public class Account
    {
        public static decimal Saldo { get; set; }

        public static void AddSaldo(decimal amount)
        {
            Saldo += amount;
        }

        public static void Withdraw(decimal amount)
        {
            Saldo -= amount;
        }
    }
}
