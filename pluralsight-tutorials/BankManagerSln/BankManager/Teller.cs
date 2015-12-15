using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankManager
{
    
    public class Teller
    {

        private readonly AccountRepository _accountRepository;

        public Teller(AccountRepository accountRepository)
        {
            if (accountRepository == null)
                throw new ArgumentNullException("accountRepository");
            _accountRepository = accountRepository;
        }

        public int CheckBalance()
        {
            Logging.WriteLine("Checking the user's balance,");
            return _accountRepository.GetBalance();
        }

        public void ProcessTransaction(Transaction transaction)
        {
            Task.Factory.StartNew(() =>
            {

                Thread.Sleep(100);
                Logging.WriteLine("Processing a transaction of £"
                                  + transaction.CalculateTotalTransaction());
                _accountRepository.ProcessTransaction(transaction);
            });

        }
    }
}
