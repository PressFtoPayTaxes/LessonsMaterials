using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\СкоропадИг.CORP\source\repos\ClassLibrary1\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
            foreach(var type in assembly.GetTypes())
            {
                Console.WriteLine($"{type.Name} " +
                    $"{type.IsPublic}");
                foreach(var memberInfo in type.GetMembers())
                {
                    if (memberInfo is MethodInfo)
                    {
                        Console.WriteLine($"{memberInfo.Name} {(memberInfo as MethodInfo).ReturnType}");

                        if (type.Name == "Service" && memberInfo.Name == "CountToTen")
                        {
                            var service = Activator.CreateInstance(type, "сообщение");
                            var method = memberInfo as MethodInfo;
                            Console.WriteLine("-------------");
                            method.Invoke(service, new object[0]);
                            Console.WriteLine("-------------");
                        }
                    }
                }
            }
        }
    }
}
