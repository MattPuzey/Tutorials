using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    public class Bank
    {
        public interface IBank
        {
            IAccount FindAccount(string name);
            bool StoreAccount(IAccount account);
        }
    }
}
