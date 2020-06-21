using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BankAccount
    {
        private List<Transaction> allTransactions = new List<Transaction>();
        private static int AccountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }
                return balance;
            }
        }
        public BankAccount(string name, decimal InitialBalance)
        {
            this.Owner = name;
            MakeDeposit(InitialBalance, DateTime.Now, "Initial balance");
            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance-amount <0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(amount, date, note);
            allTransactions.Add(withdrawal);
        }
    }
}
