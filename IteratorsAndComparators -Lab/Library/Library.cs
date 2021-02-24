using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books { get; }
    }
}
