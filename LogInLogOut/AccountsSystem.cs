using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LogInLogOut
{
    [Serializable]
    public class AccountsAdministrator
    {
        public List<Account> Accounts { get; set; }
        public Account CurrentUser { get; set; }

        public void NewUser(string email, string phone, string fullName, int age, string password)
        {
            if (Accounts == null) Accounts = new List<Account>();
            Accounts.Add(new Account()
            {
                Email = email,
                Phone = phone,
                FullName = fullName,
                Age = age,
                Password = password
            });

            XmlSerializer formatter = new XmlSerializer(typeof(List<Account>));
            string filePath = "accounts.xml";

            using (FileStream stream = new FileStream(filePath, FileMode.Append))
            {
                formatter.Serialize(stream, Accounts);
            }
        }

        public void NewUser(Account account)
        {
            if (Accounts == null) Accounts = new List<Account>();
            Accounts.Add(account);
        }

        public bool LogIn(string email, string password)
        {
            if (Accounts == null) Accounts = new List<Account>();
            foreach (Account account in Accounts)
            {
                if (email == account.Email && password == account.Password)
                {   
                    CurrentUser = account;
                    return true;
                }
            }
            return false;
        }

        public void LogOut()
        {
                CurrentUser = null;
        }
    }
}
