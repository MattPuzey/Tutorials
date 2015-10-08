using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class Program
        {
            public static void Main()
            {

                CustomerAccount RobsAccount = new CustomerAccount("Rob Miles", 100);
                Account.InterestRateCharged = 10;
                if (RobsAccount.WithdrawFunds(5))
                {
                    Console.WriteLine("Cash Withdrawn");
                }
                else
                {
                    Console.WriteLine("Insufficient Funds");
                }

                CustomerAccount test = new CustomerAccount("Rob Miles", 100);
                test.PayInFunds(50);
                if (test.GetBalance() != 50)
                {
                    Console.WriteLine("Pay In test failed");
                }

                /*
                IAccount friendlyBank = new ArrayBank(50);
                IAccount account = new CustomerAccount("Rob", 0);
                if (friendlyBank.Save(account))
                {
                    Console.WriteLine( "Account stored OK");
                }*/

                CustomerAccount a = new CustomerAccount("Rob", 50);
                AccountEditTextUI edit = new AccountEditTextUI(a); 
                edit.EditName();

            }
        }
}

