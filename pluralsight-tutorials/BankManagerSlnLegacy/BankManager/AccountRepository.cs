using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManager
{
    public class AccountRepository
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
        public virtual void ProcessTransaction(Transaction transaction)
        {
		    if (transaction.CalculateTotalTransaction() == 0) return;
            _transactions.Add(transaction);
        }

        public virtual int GetBalance()
        {
            return _transactions.Sum(x => x.CalculateTotalTransaction());
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions.Select(x => x).ToList();
        }
    }
}