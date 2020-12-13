using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var historyForAllTextConditions = new Stack<string>();
            var sb = new StringBuilder();
            historyForAllTextConditions.Push(sb.ToString());

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string[] commandArray = command.Split();
                if (commandArray[0] == "1")
                {
                    string someString = commandArray[1];
                    sb.Append(someString);
                    historyForAllTextConditions.Push(sb.ToString());
                }

                else if (commandArray[0] == "2")
                {
                    int count = int.Parse(commandArray[1]);
                    int lengthToErases = count;
                    int startIndex = sb.Length - count;
                    sb.Remove(startIndex, lengthToErases);
                    historyForAllTextConditions.Push(sb.ToString());
                }

                else if (commandArray[0] == "3")
                {
                    int index = int.Parse(commandArray[1]);
                    char symbol = sb[index - 1];
                    Console.WriteLine(symbol);
                }

                else if (commandArray[0] == "4")
                {
                    if (historyForAllTextConditions.TryPop(out string currentCondition))
                    {
                        sb = sb.Clear();
                        if (historyForAllTextConditions.TryPeek(out string previousCondition))
                        {
                            sb.Append(previousCondition);
                        }
                    }
                }
            }
        }
    }
}
