using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace LogInLogOut
{
    class Program
    {
        static void Registration(AccountsAdministrator admin)
        {
            string email, phone, fullName, password;
            int age;

            while (true)
            {
                Console.Write("Введите ваш e-mail: ");
                email = Console.ReadLine();
                if (email.Contains('@') == true && email.Contains('.') && email.IndexOf('@') < email.IndexOf('.'))
                    break;
                else { Console.WriteLine("Email введен некорректно"); }
            }

            bool rightPhone = false;
            while (true)
            {
                Console.Write("Ввведите ваш номер телефона: ");
                phone = Console.ReadLine();
                int minimalSymbolsCount = 8;
                if (phone.Length < minimalSymbolsCount) { Console.WriteLine("Телефон введен некорректно"); continue; }
                foreach (char symbol in phone)
                {
                    rightPhone = true;
                    if ((symbol < '0' || symbol > '9') && symbol != '+' && symbol != '-' && symbol != '(' && symbol != ')')
                    {
                        rightPhone = false;
                        break;
                    }
                }
                if (rightPhone == true) break;
            }

            while (true)
            {
                Console.Write("Введите ваше полное имя: ");
                fullName = Console.ReadLine();
                if (fullName.Length != 0) break;
                else Console.WriteLine("Имя введено некорректно");
            }

            while (true)
            {
                Console.Write("Введите ваш возраст:");
                age = int.Parse(Console.ReadLine());

                if (age <= 0) Console.WriteLine("Возраст введен некорректно");
                else break;
            }
                                                  
            while (true)
            {
                Console.Write("Введите пароль: ");
                password = Console.ReadLine();
                if (password.Length < 6) Console.WriteLine("Пароль слишком короткий");
                else break;
            }

            while (true)
            {
                Console.Write("Повторите введенный пароль:");
                string repeatedPassword = Console.ReadLine();
                if (repeatedPassword != password) Console.WriteLine("Пароли не совпадают");
                else break;
            }
            admin.NewUser(email, phone, fullName, age, password);
        }

        static void LogIn(AccountsAdministrator admin)
        {
            while (true)
            {
                Console.WriteLine("Введите email и пароль:");
                string email = Console.ReadLine();
                string password = Console.ReadLine();
                if (admin.LogIn(email, password) == true) { Console.WriteLine("Вы успешно авторизовались"); break; }
                else Console.WriteLine("Такого аккаунта не существует. Попробуйте снова");
            }
        }

        static void Main(string[] args)
        {
            AccountsAdministrator admin = new AccountsAdministrator();


            while (true)
            {
                Console.WriteLine("Добро пожаловать!! Выберите, что хотите сделать:\n1 - зарегестрироваться\n2 - войти в существующий аккаунт\n3 - выйти");
                int variant = 0;
                try
                {
                    variant = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректно введен вариант");
                    continue;
                }
                switch (variant)
                {
                    case 1: Registration(admin); break;
                    case 2: LogIn(admin); break;
                    case 3: Environment.Exit(1); break;
                    default: Console.WriteLine("Некорректно введён вариант"); break;
                }
            }
        }
    }
}
