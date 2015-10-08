using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class CustomerAccount : Account, IPrintHardCopy
    {
        
        public CustomerAccount(string inName, decimal inBalance) : base(inName, inBalance.ToString())
        {
            //why does Account not inherit properties from Account?
            name = inName;
            balance = inBalance;
        }

        public CustomerAccount(string inName, string inAddress) : base(inName, inAddress)
        {
        }

        public void DoPrint()
        {
        }

        public override string RudeLetterString()
        {
            return "You are overdrawn";
        }


    }
}
