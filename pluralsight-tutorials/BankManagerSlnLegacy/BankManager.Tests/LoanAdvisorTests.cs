using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BankManager.Tests
{
    class LoanAdvisorTests
        //A test should assert on one logical object
    {
        [Test]
        public void RequestApprovalFor_LoanAmountEqualToYearlyIncomeMinusTotalDebt_IsNotApproved()
        {
            const int loanAmountRequested = 100;
            const int yearlyIncome = 200;
            const int totalDebt = 100;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            Assert.That(loanDetails, Is.EqualTo(LoanDetailsDefaults.UnapprovedDetails));
        }

        [Test]
        public void RequestApprovalFor_LoanAmountEqualToMoreThanYearlyIncomeMinusTotalDebt_IsNotApproved()
        {
            const int loanAmountRequested = 101;
            const int yearlyIncome = 200;
            const int totalDebt = 100;

            var loanDetails = LoanAdvisor.RequestApprovalFor(loanAmountRequested, yearlyIncome, totalDebt);

            Assert.That(loanDetails.IsApproved, Is.False);
            Assert.That(loanDetails.LoanAmount, Is.EqualTo(0));
            Assert.That(loanDetails.LoanLengthInMonths, Is.EqualTo(0));
        }
    }

    public class LoanDetailsDefaults
    {
        public static LoanDetails UnapprovedDetails = new LoanDetails(false, 0 , 0);
    }
}
