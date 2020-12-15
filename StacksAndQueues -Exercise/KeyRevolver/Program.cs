using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForOneBullet = int.Parse(Console.ReadLine());
            int numberBulletInOneBarrel = int.Parse(Console.ReadLine());
            var stackForNumberBulletInOneBarrel = new Stack<int>();
            for (int i = 1; i < numberBulletInOneBarrel; i++) // Reloading at the begining!
            {
                stackForNumberBulletInOneBarrel.Push(1);
            }

            stackForNumberBulletInOneBarrel.Push(numberBulletInOneBarrel);
            int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stackForBullets = new Stack<int>(bulletsArray);
            int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queueForLocks = new Queue<int>(locksArray);
            int valueForThisIntelligence = int.Parse(Console.ReadLine());
            int countAllUsedBullet = 0;
            int countBulletsUnlockTheSafe = 0;

            while (stackForBullets.Count != 0 && queueForLocks.Count != 0)
            {
                int currentBullet = stackForBullets.Peek();
                int currentLock = queueForLocks.Peek();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    stackForBullets.Pop(); // remove the bullet
                    countBulletsUnlockTheSafe++;
                    countAllUsedBullet++;
                    queueForLocks.Dequeue(); // remove the lock
                }

                else if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                    stackForBullets.Pop(); // remove only the bullet and leaving the lock intact
                    countAllUsedBullet++;
                }

                if (stackForNumberBulletInOneBarrel.Count > 0) // we have bullets in current barrel
                {
                    stackForNumberBulletInOneBarrel.Pop(); // one shoot
                }

                if (stackForNumberBulletInOneBarrel.Count == 0 && stackForBullets.Count > stackForNumberBulletInOneBarrel.Count)
                {
                    Console.WriteLine("Reloading!"); // Reloading!
                    for (int i = 0; i < numberBulletInOneBarrel; i++)
                    {
                        stackForNumberBulletInOneBarrel.Push(1);
                    }
                }
            }

            if (queueForLocks.Count == 0)
            {
                int bulletsCost = countAllUsedBullet * priceForOneBullet;
                int earnedMoney = valueForThisIntelligence - bulletsCost;
                Console.WriteLine($"{stackForBullets.Count} bullets left. Earned ${earnedMoney}");
            }

            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueForLocks.Count}");
            }
        }
    }
}
