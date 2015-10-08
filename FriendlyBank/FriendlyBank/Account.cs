using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyBank
{
    internal enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    }

    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
        string GetName();
        
        bool Save(string filename);
        void Save(System.IO.TextWriter textOut);
        bool SetName(string inName);
    }

    public abstract class Account : IAccount
    {
        private AccountState state;
        protected string name;
        //should these be private? child calsses cannot reasch if so.
        protected decimal balance = 0;
        private string address;
        private int accountNumber;
        private int overdraft;
        private static decimal minIncome = 1000;
        private static int minAge = 18;

        public abstract string RudeLetterString();

        public static decimal InterestRateCharged;


        public Account(string inName, string inAddress, decimal inBalance)
        {


            string errorMessage = "";
            if (SetName(inName) == false)
            {
                errorMessage = errorMessage + "Bad name " + inName;
            }
            if (SetAddress(inAddress) == false)
            {
                errorMessage = errorMessage + " Bad addr " + inAddress;

            }
            if (errorMessage != "")
            {
                throw new Exception("Bad account" + errorMessage);
            }
        }

        public Account(string inName, string inAddress)
            : this(inName, inAddress, 0)
        {
        }

        public Account(string inName)
            : this(inName, "Not Supplied", 0)
        {
        }

        public Account(System.IO.TextReader textIn)
        {
            name = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            balance = decimal.Parse(balanceText);
        }

        private bool SetAddress(string inAddress)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return this.name;
        }

        public bool SetName(string inName)
        {
            string reply;
            reply = ValidateName(inName);
            if (reply.Length > 0)
            {
                return false;
            }

            this.name = inName.Trim();
            return true;
        }

        public static string ValidateName(string name)
        {
            if (name == null)
            {
                return "Name parameter null";
            }
            string trimmedName = name.Trim();
            if (trimmedName.Length == 0)
            {
                return "No text in the name";
            }
            return "";
        }

        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            balance = balance - amount;
            return true;
        }

        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public static bool AccountAllowed(decimal income, int age)
        {
            if ((income >= minIncome) && (age >= minAge))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save(string filename)
        {
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (textOut != null)
                {
                    textOut.Close();
                }
            }
            return true;
        }

        public void Save(System.IO.TextWriter textOut)
        /*This is the Save method which would be added to our Hashtable based bank.
        It gets each account out of the hash table and saves it in the given stream.
        Should An account class be saving multiple accoun*/
        {
            HashBank hashBank = new HashBank();
            textOut.WriteLine(HashBank.bankHashtable.Count);
            foreach (CustomerAccount account in HashBank.bankHashtable.Values)
            {
                account.Save(textOut);
            }
        }

        public static CustomerAccount Load(System.IO.TextReader textIn)
            /*This method is supplied with a text stream. It reads the name and the balance from
        this stream and creates a new CustomerAccount based on this data.*/
        {
            CustomerAccount result = null;

            try
            {
                string name = textIn.ReadLine();
                string balanceText = textIn.ReadLine();
                decimal balance = decimal.Parse(balanceText);
                result = new CustomerAccount(name, balance);
            }
            catch
            {
                return null;
            }
            return result;
        }

        public override string ToString()
        {
            return "Name: " + name + " balance: " + balance;
        }
    }
}
