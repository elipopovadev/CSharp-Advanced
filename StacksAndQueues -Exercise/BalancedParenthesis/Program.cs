using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackOpenParentheses = new Stack<char>();
            string expression = Console.ReadLine();
            foreach (char currentSymbol in expression)
            {
                if (currentSymbol == '{' || currentSymbol == '(' || currentSymbol == '[')
                {
                    stackOpenParentheses.Push(currentSymbol);
                }

                else if (currentSymbol == '}' || currentSymbol == ')' || currentSymbol == ']')
                {
                    if(stackOpenParentheses.TryPeek(out char lastSymbolInTheStack))
                    {
                        lastSymbolInTheStack = stackOpenParentheses.Peek();
                    }

                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (lastSymbolInTheStack == '{' && currentSymbol =='}')
                    {
                        stackOpenParentheses.Pop();                                            
                    }

                    else if (lastSymbolInTheStack == '(' && currentSymbol == ')')
                    {
                        stackOpenParentheses.Pop();                       
                    }

                    else if (lastSymbolInTheStack == '[' && currentSymbol == ']')
                    {
                        stackOpenParentheses.Pop();                       
                    }

                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");            
        }
    }
}
