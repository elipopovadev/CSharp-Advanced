﻿using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var elements = command.Split().Skip(1).ToList();
            var newListyIterator = new ListyIterator<string>(elements);

            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(newListyIterator.Move());
                }

                else if (command == "HasNext")
                {
                    Console.WriteLine(newListyIterator.HasNext());
                }

                else if (command == "Print")
                {
                    try
                    {
                        newListyIterator.Print();
                    }

                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
