using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public class SimpleTransaction : Transaction
    {
        public SimpleTransaction(int baseAmount) : base(baseAmount) { }
        public override int CalculateTotalTransaction() { return BaseAmount; }
    }
}
