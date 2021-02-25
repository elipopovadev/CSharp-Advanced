using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new HashSet<Book>(books);
        }

        public HashSet<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.Books.Reverse())
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); // always return this.GetEnumerator()
        }            
    }
}
