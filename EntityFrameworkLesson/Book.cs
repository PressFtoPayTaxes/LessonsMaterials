using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Author Author { get; set; }
    }
}
