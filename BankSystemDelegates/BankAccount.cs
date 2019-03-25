using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDelegates
{
    public class BankAccount
    {
        public string FullName { get; set; }
        public int Sum { get; private set; } = 0;
        public IReporter Reporter { get; set; }
         
        public void Add(int sum)
        {
            Sum += sum;
            if (Reporter != null)
                Reporter.SendReport($"На Ваш счёт перечислено {sum} тенге\nВаш текущий баланс: {Sum} тенге");
        }

        public void Withdraw(int sum)
        {
            if (sum <= Sum)
            { 
                Sum -= sum;
                if (Reporter != null)
                    Reporter.SendReport($"С Вашего счёта снято {sum} тенге\nВаш текущий баланс: {Sum} тенге");
                return;
            }
            if (Reporter != null)
                Reporter.SendReport("На Вашем счёте недостаточно средств для снятия данной суммы");
        }
    }
}
