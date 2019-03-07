using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterAPI
{
    [Serializable]
    public class Wand
    {
        public string Wood { get; set; }
        public string Core { get; set; }
        public double? Length { get; set; }
    }
}
