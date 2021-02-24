using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Book firstBook = new Book("Animal Farm", 2003, "George Orwell");
            Book secondBook = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book thirdBook= new Book("The Documents in the Case", 1930);

            Library firstLibrary = new Library();
            Library secondLibrary = new Library(firstBook, secondBook, thirdBook);
        }
    }
}
