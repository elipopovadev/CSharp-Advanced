using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
   public class Library : IEnumerable<Book> // IEnumerable<> NB!
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(this.Books); // this one automatically implementet constructor bellow
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); // always return this.GetEnumerator()
        }

        private class LibraryEnumerator : IEnumerator<Book> // IEnumerator<> NB!
        {
            private readonly List<Book> books;
            private int currentIndex = -1; // add currentIndex

            public LibraryEnumerator(List<Book> books) // automatically implemented constructor
            {
                this.Reset(); // add Reset()
                this.books = books;             
            }
            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current; // always return this.Current

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
               this.currentIndex++;
                if (this.currentIndex >= this.books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
