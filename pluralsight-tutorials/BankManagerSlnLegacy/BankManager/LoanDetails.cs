using System.Collections.Generic;

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


        public override string ToString()
        {
            return string.Format("Is approved: {0} for loan amount: {1}: with a term length of {2} months.",
                IsApproved, LoanAmount, LoanLengthInMonths);
        }

        private sealed class LoanDetailsEqualityComparer : IEqualityComparer<LoanDetails>
        {
            public bool Equals(LoanDetails x, LoanDetails y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.IsApproved == y.IsApproved && x.LoanAmount == y.LoanAmount && x.LoanLengthInMonths == y.LoanLengthInMonths;
            }

            public int GetHashCode(LoanDetails obj)
            {
                unchecked
                {
                    var hashCode = obj.IsApproved.GetHashCode();
                    hashCode = (hashCode*397) ^ obj.LoanAmount;
                    hashCode = (hashCode*397) ^ obj.LoanLengthInMonths;
                    return hashCode;
                }
            }
        }

        private static readonly IEqualityComparer<LoanDetails> LoanDetailsComparerInstance = new LoanDetailsEqualityComparer();

        public static IEqualityComparer<LoanDetails> LoanDetailsComparer
        {
            get { return LoanDetailsComparerInstance; }
        }
    }
}