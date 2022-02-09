using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {          
            int[] firstLines = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondLines = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bombEffects = new Queue<int>(firstLines);
            var bombCasings = new Stack<int>(secondLines);

            int countDaturaBombs = 0;
            int countCherryBombs = 0;
            int countSmokeDecoyBombs = 0;
            while(bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int firstElementInBombEffects = bombEffects.Peek();
                int lastElementInBombCasings = bombCasings.Peek();
                int sum = firstElementInBombEffects + lastElementInBombCasings;
                if(sum == 40)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    countDaturaBombs++;
                }

                else if(sum == 60)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    countCherryBombs++;
                }

                else if(sum == 120)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    countSmokeDecoyBombs++;
                }

                else
                {
                    bombCasings.Pop();
                    bombCasings.Push(lastElementInBombCasings - 5);
                }

                if(countDaturaBombs >=3 && countCherryBombs >=3 && countSmokeDecoyBombs >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    PrintResult(bombEffects, bombCasings, countDaturaBombs, countCherryBombs, countSmokeDecoyBombs);
                    return;
                }
            }

            Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            PrintResult(bombEffects, bombCasings, countDaturaBombs, countCherryBombs, countSmokeDecoyBombs);
        }


        private static void PrintResult(Queue<int> bombEffects, Stack<int> bombCasings, int countDaturaBombs, int countCherryBombs, int countSmokeDecoyBombs)
        {
            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {countCherryBombs}");
            Console.WriteLine($"Datura Bombs: {countDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {countSmokeDecoyBombs}");
        }
    }
}
