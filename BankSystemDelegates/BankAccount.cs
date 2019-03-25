using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegates
{
    public delegate void ReporterDelegate(string text);
    public class BankAccount
    {
        private ReporterDelegate reporterDelegate;

        public string FullName { get; set; }
        public int Sum { get; private set; } = 0;

        public void RegisterReporter(ReporterDelegate reporter)
        {
            reporterDelegate += reporter;
        }

        public void UnregisterReporter(ReporterDelegate reporter)
        {
            reporterDelegate -= reporter;
        }

        public void Add(int sum)
        {
            Sum += sum;
            reporterDelegate?.Invoke($"На Ваш счёт перечислено {sum} тенге\nВаш текущий баланс: {Sum} тенге");
        }

        public void Withdraw(int sum)
        {
            if (sum <= Sum)
            {
                Sum -= sum;
                reporterDelegate?.Invoke($"С Вашего счёта снято {sum} тенге\nВаш текущий баланс: {Sum} тенге");
                return;
            }
            reporterDelegate?.Invoke("На Вашем счёте недостаточно средств для снятия данной суммы");
        }
    }
}
