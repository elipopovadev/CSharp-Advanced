﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if (this.Year.CompareTo(other.Year) > 0)
            {
                return 1;
            }

            else if(this.Year.CompareTo(other.Year) < 0)
            {
                return -1;
            }

            else // the years are equal
            {
                return this.Title.CompareTo(other.Title);
            }
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
