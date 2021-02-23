using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesAdressCity = Console.ReadLine().Split();
            string firstName = namesAdressCity[0];
            string lastName = namesAdressCity[1];
            string names = firstName + " " + lastName;
            string adress = namesAdressCity[2];
            string city = string.Join(" ", namesAdressCity.Skip(3));
            var threeupleNamesAdreessCity = new MyThreeuple<string, string, string>(names, adress, city);

            string[] nameBeerDrunkOrNot = Console.ReadLine().Split();         
            string name = nameBeerDrunkOrNot[0];
            int beer = int.Parse( nameBeerDrunkOrNot[1]);
            string condition = nameBeerDrunkOrNot[2];
            bool checkIfCanDrunk = condition == "drunk" ? true : false;
            var threeupleNameBeerChecker = new MyThreeuple<string, int, bool>(name, beer, checkIfCanDrunk);

            string[] namesBalanceBank = Console.ReadLine().Split();
            string firstNames = namesBalanceBank[0];
            double balance = double.Parse(namesBalanceBank[1]);
            string bank = namesBalanceBank[2];
            var threeupleNamesBalanceBank = new MyThreeuple<string, double, string>(firstNames, balance, bank);

            Console.WriteLine(threeupleNamesAdreessCity);
            Console.WriteLine(threeupleNameBeerChecker);
            Console.WriteLine(threeupleNamesBalanceBank);
        }
    }
}
