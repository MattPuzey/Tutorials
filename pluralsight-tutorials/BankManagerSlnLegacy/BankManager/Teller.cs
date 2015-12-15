using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        internal int? CachedBalance;
        public int CheckBalance()
        {
            Logging.WriteLine("Checking the user's balance.");
            if (CachedBalance.HasValue && !CachedBalanceIsExpired())
                return CachedBalance.Value;
            CachedBalance = _accountRepository.GetBalance();
            return CachedBalance.Value;
        }

        private bool CachedBalanceIsExpired()
        {
            return false;
        }

        public void ProcessTransaction(Transaction transaction)
        {
            Task.Factory.StartNew(() =>
            {
                Logging.WriteLine("Processing a transaction of $" 
                    + transaction.CalculateTotalTransaction());
                _accountRepository.ProcessTransaction(transaction);
            });
        }

        // Layer of abstraction around Advisor instantiation so we are able to control the dependency of the RequetsLoan method
        protected virtual LoanAdvisorWrapper GetLoanAdvisor()
        {
            return new LoanAdvisorWrapper();
        }

        public LoanDetails RequestLoan(int loanAmount, int yearlyIncome, int currentDebt)
        {
            return GetLoanAdvisor().RequestLoan(loanAmount, yearlyIncome, currentDebt);
        }
        
    }

    public class LoanAdvisorWrapper
    {
        public virtual LoanDetails RequestLoan(int loanAmount, int yearlyIncome, int currentDebt)
        {
            return LoanAdvisor.RequestApprovalFor(loanAmount, yearlyIncome, currentDebt);
        }
    }
}