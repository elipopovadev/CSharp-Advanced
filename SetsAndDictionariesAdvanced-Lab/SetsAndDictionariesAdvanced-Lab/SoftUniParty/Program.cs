using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    static class Program
    {
        static void Main(string[] args)
        {
            var registrationVIP = new HashSet<string>();
            var registrationRegular = new HashSet<string>();
            while (true)
            {
                string guest = Console.ReadLine();
                if (guest == "PARTY")
                {
                    break;
                }

                if (guest.Length == 8)
                {
                    if (char.IsDigit(guest[0]))
                    {
                        registrationVIP.Add(guest);
                    }

                    else
                    {
                        registrationRegular.Add(guest);
                    }
                }
            }

            while (true)
            {
                string guestComes = Console.ReadLine();
                if (guestComes == "END")
                {
                    break;
                }

                registrationVIP.Remove(guestComes);
                registrationRegular.Remove(guestComes);
            }

            Console.WriteLine(registrationRegular.Count + registrationVIP.Count);
            if (registrationVIP.Count > 0) Console.WriteLine(string.Join(Environment.NewLine, registrationVIP));
            if (registrationRegular.Count > 0) Console.WriteLine(string.Join(Environment.NewLine, registrationRegular));
        }
    }
}
