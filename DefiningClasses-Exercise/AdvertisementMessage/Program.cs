using System;
using System.Text;

namespace AdvertisementMessage
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phrases = new string[] {
                "Excellent product",
                "Such a great product.",
                "I always use that product.",
                "Best product of itscategory.",
                "Exceptional product.",
                "I can’t live without this product."};

            var events = new string[] {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great"};

            var authors = new string[]
            {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
 
            var cities = new string[]
            {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
 
            int numberOfMessages = int.Parse(Console.ReadLine());
            Random generator = new Random(); // Random is out the loop NB!
            for (int i = 0; i < numberOfMessages; i++)
            {
                var sb = new StringBuilder();
                int indexOfPhrase = generator.Next(phrases.Length);
                sb.Append(phrases[indexOfPhrase]);
                sb.Append(" ");
                int indexOfEvent = generator.Next(events.Length);
                sb.Append(events[indexOfEvent]);
                sb.Append(" ");
                int indexOfAuthor = generator.Next(authors.Length);
                sb.Append(authors[indexOfAuthor]);
                sb.Append(" - ");
                int indexOfCity = generator.Next(cities.Length);
                sb.Append(cities[indexOfCity]);
                Console.WriteLine(sb);
            }
        }
    }
}
