using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var author = new Author
            {
                Name = "Пушкин А.С."
            };

            var book = new Book
            {
                Name = "Сказки",
                Price = 1000,
                Author = author
            };

            using (var context = new AppContext())
            {
                context.Authors.Add(author);
                context.Books.Add(book);
                context.SaveChanges();
            }
        }
    }
}
