using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = string.Empty;

            Console.WriteLine("Пожалуйста выберите номер диска");
            var drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                    Console.WriteLine($"{i}. {drives[i].Name}");
            }

            var position = int.Parse(Console.ReadLine());
            path += drives[position].Name;

            foreach (var directory in drives[position].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine(directory.Name);
            }

            Console.WriteLine("Введите имя директории для хранения файлов");
            path += Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.WriteLine("Введите имя файла");
            path += @"\" + Console.ReadLine();

            if (!File.Exists(path))
            {
                //File.Create(path); //утечка памяти!!!!!!!!!!!!!!!!!!
                var stream = File.Create(path);
                stream.Close(); // из памяти удалили, утечки нет
            }

            string textData = "Какой-то текст"; //источник
                                                // потребитель - наш файл

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] data = Encoding.UTF8.GetBytes(textData);
                fileStream.Write(data, 0, data.Length);
            }

            using (var fileStream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);

                string result = Encoding.UTF8.GetString(buffer);
            }

            using (var writer = new StreamWriter(path))
            {
                string data = "Text";
                writer.WriteLine(data);
            }

            using (var reader = new StreamReader(path))
            {
                string result = reader.ReadToEnd();
            }
        }
    }
}
