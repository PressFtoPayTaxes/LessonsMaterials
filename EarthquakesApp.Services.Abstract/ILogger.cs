using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthquakesApp.Services.Abstract
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogMessage(string text);
    }
}