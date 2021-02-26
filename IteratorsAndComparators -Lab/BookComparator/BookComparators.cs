using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class BookComparators : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
           if(firstBook.Title.CompareTo(secondBook.Title) != 0)
            {
                return firstBook.Title.CompareTo(secondBook.Title);
            }


            else // the titles are equal
            {
                return secondBook.Year.CompareTo(firstBook.Year);
            }
        }
    }
}
