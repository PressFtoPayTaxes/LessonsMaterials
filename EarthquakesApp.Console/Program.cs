using EarthquakesApp.Models;
using EarthquakesApp.Services;
using EarthquakesApp.Services.Abstract;
using Newtonsoft.Json;

namespace EarthquakesApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);
            IRepository<FeatureCollection> repository = new XmlRepository<FeatureCollection>(logger);

            var data = downloader.DownloadInfo("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=50");

            if (!string.IsNullOrEmpty(data))
            {
                //(V)oO(V)
                var deserializedData = JsonConvert.DeserializeObject<FeatureCollection>(data);
                repository.Add(deserializedData);
            }
            else
            {
                System.Console.WriteLine("Произошла ошибка, обратитесь к системному администратору.");
                System.Console.ReadLine();
            }
        }
    }
}