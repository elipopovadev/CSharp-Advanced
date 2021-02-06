using System;

namespace DateModifier
{
    public static class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();
            var dateModifier = new DateModifier();          
            var listWithDays= dateModifier.ReturnDaysBetwenTwoDates(startDate, endDate);
            Console.WriteLine(string.Join(" ", listWithDays.Count));
        }
    }
}
