using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount
            {
                FullName = "Сапарбек Иванович Дзюба"
            };

            var reporter = new ConsoleReporter();
            var reporterDelegate = new ReporterDelegate(reporter.SendReport);
            account.RegisterReporter(reporterDelegate);

            account.Add(1000);
            account.Withdraw(20000);
            account.Withdraw(200);
        }
    }
}
