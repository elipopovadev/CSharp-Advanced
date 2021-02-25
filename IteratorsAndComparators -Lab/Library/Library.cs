using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library
    {
        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public List<Book> Books { get; }
    }
}
