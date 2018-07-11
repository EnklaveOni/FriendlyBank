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

    struct Account
    {
        public AccountState State;
        public string Name;
        public string Address;
        public int AccountNumber;
        public int Balance;
        public int Overdraft;
    };

    class BankProgram
    {
        public static void PrintAccout(Account a)
        {
            Console.WriteLine("Name: " + a.Name);
            Console.WriteLine("State: " + a.State);
            Console.WriteLine("Balance: " + a.Balance);
        }

        static void Main()
        {
            const int MAX_CUST = 100;
            Account[] Bank = new Account[MAX_CUST];
            Bank[0].Name = "John";
            Bank[0].Address = "Prague";
            Bank[0].State = AccountState.Active;
            Bank[0].Balance = 1000000;
            PrintAccout(Bank[0]);
            Bank[1].Name = "Jane";
            Bank[1].State = AccountState.Frozen;
            Bank[1].Balance = 0;
            PrintAccout(Bank[1]);

            Console.Read();
        }

    }
}
