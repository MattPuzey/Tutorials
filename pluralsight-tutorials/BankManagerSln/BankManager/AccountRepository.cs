using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public class AccountRepository
    {
        private readonly List<int> _transactions = new List<int>();

        public virtual void ProcessTransaction(int amount)
        {
            _transactions.Add(amount);
        }

        public virtual int GetBalance()
        {
            return _transactions.Sum();
        }

        public virtual List<int> GetTransactions()
        {
            return _transactions.Select(x => x).ToList();
        }
    }
}
