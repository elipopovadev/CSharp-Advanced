using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class BookComparators : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
           if(firstBook.Title.CompareTo(secondBook.Title) > 0)
            {
                return 1;
            }

           else if(firstBook.Title.CompareTo(secondBook.Title) < 0)
            {
                return -1;
            }

            else // the titles are equal
            {
                return firstBook.Year.CompareTo(secondBook.Year);
            }
        }
    }
}
