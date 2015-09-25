using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ExampleContext())
            {
                Console.WriteLine("Enter a the Authors Surname:");
                var surname = Console.ReadLine();

                Console.WriteLine("Enter the Authors Firstname:");
                var firstname = Console.ReadLine();

                var newAuthor = new Author
                {
                    FirstName = firstname,
                    SurName = surname
                };

                db.Authors.Add(newAuthor);
                db.SaveChanges();

                var query = from a in db.Authors
                                select a;

                Console.WriteLine("Authors in database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.ToString());
                }
                
                Console.WriteLine("press a key to exit");
                Console.ReadKey();
            }
        }
    }
}
