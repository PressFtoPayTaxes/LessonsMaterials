using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegates
{
    public class ConsoleReporter : IReporter
    {
        public void SendReport(string message)
        {
            Console.WriteLine(message);
        }
    }
}
