using EarthquakesApp.Services.Abstract;
using System;
using System.IO;
using System.Text;

namespace EarthquakesApp.Services
{
    public class FileLogger : ILogger
    {
        public void LogError(Exception exception)
        {
            using (var stream = File.Open("error.log", FileMode.Append))
            {
                var text = $"{DateTime.Now} - {exception.Message}";
                var data = Encoding.UTF8.GetBytes(text);
                stream.Write(data, 0, data.Length);
            }
        }

        public void LogMessage(string message)
        {
            using (var stream = File.Open("info.log", FileMode.Append))
            {
                var text = $"{DateTime.Now} - {message}";
                var data = Encoding.UTF8.GetBytes(text);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
