using EarthquakesApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace EarthquakesApp.Services
{
    public class XmlRepository<T> : IRepository<T>
    {
        private readonly ILogger logger;
        private readonly XmlSerializer serializer;

        public XmlRepository(ILogger logger)
        {
            this.logger = logger;
            serializer = new XmlSerializer(typeof(List<T>));
        }

        public void Add(T item)
        {
            logger.LogMessage($"Добавление новой сущности {typeof(T).Name}");

            var exisitingData = GetAll();
            exisitingData.Add(item);

            using (var stream = File.Open("earthquakes.xml", FileMode.Truncate))
            {
                try
                {
                    serializer.Serialize(stream, exisitingData);
                }
                catch(InvalidOperationException exception)
                {
                    logger.LogError(exception);
                }
            }
        }

        public List<T> GetAll()
        {
            using (var stream = File.Open("earthquakes.xml", FileMode.OpenOrCreate))
            {
                if (stream.Length == 0) return new List<T>();
                return serializer.Deserialize(stream) as List<T>;
            }
        }
    }
}
