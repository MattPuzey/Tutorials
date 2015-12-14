using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public abstract class Transaction
    {
        public int BaseAmount { get; private set; }

        //accepts base amount and stores in a property 
        protected Transaction(int baseAmount)
        {
            BaseAmount = baseAmount;
        }

        public abstract int CalculateTotalTransaction();
    }
}
