﻿using System;
using System.Linq;
using System.Text;

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
                try
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
                        newListyIterator.Print();
                    }

                    else if (command == "PrintAll")
                    {
                        var sb = new StringBuilder();
                        foreach (var item in newListyIterator)
                        {
                            sb.Append(item);
                            sb.Append(" ");
                        }
                        Console.WriteLine(sb);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}