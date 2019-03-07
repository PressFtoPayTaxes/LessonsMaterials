using DotNetXmlHttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;

namespace HarryPotterAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Charachter[] charachters;

            string jsonUrl = "http://hp-api.herokuapp.com/api/characters";

            XMLHttpRequest jsonData = new XMLHttpRequest();
            jsonData.Open(XMLHttpRequest.EnumMethod.Get, jsonUrl);
            jsonData.Send();

            using (StreamReader streamReader = new StreamReader(jsonData.ResponseStream))
            {
                string jsonFile = streamReader.ReadToEnd();
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd-MM-yyyy" };
                
                charachters = JsonConvert.DeserializeObject<Charachter[]>(jsonFile, dateTimeConverter);
            }
                        
            
        }
    }
}
