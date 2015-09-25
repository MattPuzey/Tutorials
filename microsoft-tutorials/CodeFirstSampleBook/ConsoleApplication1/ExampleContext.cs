namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExampleContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
       
        public ExampleContext()
            : base("name=ExampleContext")
        {
           
        }
    }

}