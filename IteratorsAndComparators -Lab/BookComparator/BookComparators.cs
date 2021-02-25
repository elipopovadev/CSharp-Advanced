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
                if (firstBook.Year.CompareTo(secondBook.Year) > 0)
                {
                    return -1;
                }

                else if(firstBook.Year.CompareTo(secondBook.Year) < 0)
                {
                    return 1;
                }

                else
                {
                    return 0;
                }
            }
        }
    }
}
