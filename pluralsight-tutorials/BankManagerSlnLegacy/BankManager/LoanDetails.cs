namespace BankManager
{
    public class LoanDetails
    {
        public bool IsApproved { get; private set; }
        public int LoanAmount { get; private set; }
        public int LoanLengthInMonths { get; private set; }

        public LoanDetails(bool isApproved, int loanAmount, int loanLengthInMonths)
        {
            IsApproved = isApproved;
            LoanAmount = loanAmount;
            LoanLengthInMonths = loanLengthInMonths;
        }
    }
}