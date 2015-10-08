using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendlyBank;

namespace FriendlyBankTestSuite
{
    class AccountTest
    {
        static void Main(string[] args)
        {
            CustomerAccount test = new CustomerAccount();
            test.PayInFunds(50);
            Console.WriteLine("Balance:" + test.GetBalance());

            int errorCount = 0;
          
            if (test.GetBalance() != 50)
            {
                Console.WriteLine("Pay In test failed");
            }

            
            string reply;
            reply = CustomerAccount.ValidateName(null);
            if (reply != "Name parameter null")
            {
                Console.WriteLine("Null name test failed");
                errorCount++;
            }
            reply = CustomerAccount.ValidateName("");
            if (reply != "No text in the name")
            {
                Console.WriteLine("Empty name test failed");
                errorCount++;
            }
            reply = CustomerAccount.ValidateName(" ");
            if (reply != "No text in the name")
            {
                Console.WriteLine("Blank string name test failed");
                errorCount++;
            }
            CustomerAccount a = new CustomerAccount("Rob", 50);
            if (!a.SetName("Jim"))
            {
                Console.WriteLine("Jim SetName failed");
                errorCount++;
            }
            if (a.GetName() != "Jim")
            {
                Console.WriteLine("Jim GetName failed");
                errorCount++;
            }
            if (!a.SetName(" Pete "))
            {
                Console.WriteLine("Pete trim SetName failed");
                errorCount++;
            }
            if (a.GetName() != "Pete")
            {
                Console.WriteLine("Pete GetName failed");
                errorCount++;
            }
            if (errorCount > 0)
            {
                SoundSiren(errorCount);
            }
        }

        public static void SoundSiren(int errorCount)
        {
            Console.WriteLine("{0} errors detected ", errorCount);
        }
        }
    }
}
