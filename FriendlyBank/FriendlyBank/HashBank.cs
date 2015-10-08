using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class HashBank : Bank.IBank
    {
        public Hashtable bankHashtable = new Hashtable();

        public IAccount FindAccount(string name)
        {
            return bankHashtable[name] as IAccount;
        }

        public bool StoreAccount(IAccount account)
        {
            bankHashtable.Add(account.GetName(), account);
            return true;
        }


        public static HashBank Load(System.IO.TextReader textIn)
        /*This reads the size of the bank and then reads each of the accounts in turn 
        and adds it to the hash table.*/
        {
            HashBank result = new HashBank();
            string countString = textIn.ReadLine();
            int count = int.Parse(countString);

            for (int i = 0; i < count; i++)
            {
                string className = textIn.ReadLine();
                IAccount account =
                    AccountFactory.MakeAccount(className, textIn);
                result.bankHashtable.Add(account.GetName(), account);
            }
            return result;
        }
    }
}
