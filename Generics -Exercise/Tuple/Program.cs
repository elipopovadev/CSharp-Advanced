using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namesAddress = Console.ReadLine().Split();
            string firstName = namesAddress[0];
            string lastName = namesAddress[1];
            string address = namesAddress[2];
            var tupleForNamesAndAddres= new MyTuple<string, string>($"{firstName} {lastName}", address);

            string[] namesAndAmountOfBeer = Console.ReadLine().Split();
            string name = namesAndAmountOfBeer[0];
            int amountOfBeer = int.Parse(namesAndAmountOfBeer[1]);
            var tupleForNamesAndAmountOfBeer = new MyTuple<string, int>(name, amountOfBeer);

            string[] numbers = Console.ReadLine().Split();
            int firstNumber = int.Parse(numbers[0]);
            double secondNumber = double.Parse(numbers[1]);
            var tupleForNumbers = new MyTuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(tupleForNamesAndAddres.ToString());
            Console.WriteLine(tupleForNamesAndAmountOfBeer.ToString());
            Console.WriteLine(tupleForNumbers.ToString());
        }     
    }
}
