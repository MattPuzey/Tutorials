using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public interface IPrintHardCopy
    {
        void DoPrint();
    }


    public class BabyAccount : CustomerAccount
        // need a default constructor for accont 
    {
        protected decimal balance = 0;
        protected string parentName;

        public BabyAccount(
            string newName,
            decimal initialBalance,
            string inParentName)
            : base(newName, initialBalance)
        {
            parentName = inParentName;
        }

        public BabyAccount(System.IO.StreamReader textIn) :
            base(textIn)
        {
            parentName = textIn.ReadLine();
        }

        public string GetParentName()
        {
            return parentName;
        }

        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }
            return base.WithdrawFunds(amount);
        }

        public override string RudeLetterString()
        {
            return "You are overdrawn";
        }

        public override void Save(System.IO.TextWriter textOut)
        {
            base.Save(textOut);
            textOut.Write(parentName);
        }
    }
}
