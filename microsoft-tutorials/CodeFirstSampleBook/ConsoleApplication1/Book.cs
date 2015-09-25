using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Author Author {get; set; }
    }

    public class Author
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, SurName);
        }
    }
}

