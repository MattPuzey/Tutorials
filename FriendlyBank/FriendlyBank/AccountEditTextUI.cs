using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    class AccountEditTextUI
    {
        private IAccount account;

        public AccountEditTextUI(Account inAccount)
        {
            this.account = inAccount;
        }

        public void EditName()
        {
            string newName;
            Console.WriteLine( "Name Edit");
            while (true)
            {
                Console.WriteLine( "Enter new name : ");
                newName = Console.ReadLine();
                string reply;
                reply = this.account.ValidateName(newName);

                if (reply.Length == 0)
                {
                    break;
                }
                Console.WriteLine( "Invalid name : " + reply );
            }
            this.account.SetName(newName);
        }
    }
}
