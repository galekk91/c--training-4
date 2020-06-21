using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BankAccount
    {
        private static int AccountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }
        public BankAccount(string name, decimal InitialBalance)
        {
            this.Owner = name;
            this.Balance = InitialBalance;
            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }
    }
}
