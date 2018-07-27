using System;
using System.Collections.Generic;
using System.IO;
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

    public interface IAccount
    {
        bool WithdrawFunds(decimal amount);
        void PayInFunds(decimal amount);
        decimal GetBalance();
    }

    public class CustomerAccount : IAccount
    {
        private decimal balance = 0;

        public virtual bool WithdrawFunds ( decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        public void PayInFunds ( decimal amount )
        {
            balance += amount;
        }

        public sealed decimal GetBalance()
        {
            return balance;
        }
    }

    public class BabyAccount : CustomerAccount, IAccount
    {
        public override bool WithdrawFunds ( decimal amount )
        {
            if (amount > 10)
            {
                return false;
            }
            return base.WithdrawFunds(amount);
        }
    }

    class Bank
    {
        const int MAX_CUST = 100;

        static void Main()
        {
            IAccount[] accounts = new IAccount[MAX_CUST];

            accounts[0] = new CustomerAccount();
            accounts[0].PayInFunds(100);
            Console.WriteLine("Balance: {0}", accounts[0].GetBalance());

            accounts[1] = new BabyAccount();
            accounts[1].PayInFunds(50);
            Console.WriteLine("Balance: {0}", accounts[1].GetBalance());

            if (accounts[0].WithdrawFunds(20))
            {
                Console.WriteLine("Withdraw OK");
            }

            if (accounts[1].WithdrawFunds(20))
            {
                Console.WriteLine("Withdraw OK");
            }
            else
            {
                Console.WriteLine("Baby can withdraw max 10");
            }

            Console.Read();
        }
    }
}
