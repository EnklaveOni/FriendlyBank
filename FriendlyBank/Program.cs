using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    };

    class Account
    {
        private decimal balance;
        public static decimal InterestRateCharged = 10;

        public bool WithdrawFunds( decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        public void PayInFunds( decimal amount )
        {
            balance += amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    class BankProgram
    {

        static void Main()
        {
            Account JohnsAcc = new Account();
            JohnsAcc.PayInFunds(100);
            Console.WriteLine(JohnsAcc.GetBalance());
            Console.WriteLine(Account.InterestRateCharged);
            Console.Read();
        }

    }
}
