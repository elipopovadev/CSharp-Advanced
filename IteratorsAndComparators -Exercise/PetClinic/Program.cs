using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            var listWithPets = new List<Pet>();
            var listWithClinics = new List<Clinic>();
            int numberOfCommand = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] commandArray = Console.ReadLine().Split();
                try
                {
                    if (commandArray[0] == "Create" && commandArray[1] == "Pet" && commandArray.Length == 5)
                    {
                        string name = commandArray[2];
                        int age = int.Parse(commandArray[3]);
                        string kind = commandArray[4];
                        Pet newPet = new Pet(name, age, kind);
                        listWithPets.Add(newPet);
                    }

                    else if (commandArray[0] == "Create" && commandArray[1] == "Clinic" && commandArray.Length == 4)
                    {
                        string name = commandArray[2];
                        int numberOfRooms = int.Parse(commandArray[3]);
                        Clinic newClinic = new Clinic(name, numberOfRooms);
                        listWithClinics.Add(newClinic);
                    }

                    else if (commandArray[0] == "Add" && commandArray.Length == 3)
                    {
                        string name = commandArray[1];
                        string clinic = commandArray[2];
                        if (listWithPets.Any(p => p.Name == name) && listWithClinics.Any(c => c.Name == clinic))
                        {
                            Pet findPet = listWithPets.Where(p => p.Name == name).First();
                            Clinic findClinic = listWithClinics.Where(c => c.Name == clinic).First();
                            Console.WriteLine(findClinic.Add(findPet));
                        }
                    }

                    else if (commandArray[0] == "Release" && commandArray.Length == 2)
                    {
                        string clinic = commandArray[1];
                        if (listWithClinics.Any(c => c.Name == clinic))
                        {
                            Clinic findClinic = listWithClinics.Where(c => c.Name == clinic).First();
                            Console.WriteLine(findClinic.Release());
                        }
                    }

                    else if (commandArray[0] == "HasEmptyRooms" && commandArray.Length == 2)
                    {
                        string clinic = commandArray[1];
                        if (listWithClinics.Any(c => c.Name == clinic))
                        {
                            Clinic findClinic = listWithClinics.Where(c => c.Name == clinic).First();
                            Console.WriteLine(findClinic.HasEmptyRoom());
                        }
                    }

                    else if (commandArray[0] == "Print" && commandArray.Length == 2)
                    {
                        string clinic = commandArray[1];
                        if (listWithClinics.Any(c => c.Name == clinic))
                        {
                            Clinic findClinic = listWithClinics.Where(c => c.Name == clinic).First();
                            findClinic.Print();
                        }
                    }

                    else if (commandArray[0] == "Print" && commandArray.Length == 3)
                    {
                        string clinic = commandArray[1];
                        int index = int.Parse(commandArray[2]);
                        if (listWithClinics.Any(c => c.Name == clinic))
                        {
                            Clinic findClinic = listWithClinics.Where(c => c.Name == clinic).First();
                            findClinic.PrintRoom(index);
                        }
                    }
                }

                catch (Exception)
                {
                    if (commandArray[0] == "Create" && commandArray[1] == "Clinic" && commandArray.Length == 4)
                    {
                        Console.WriteLine("Invalid Operation!");
                    }

                    else
                    {
                        Console.WriteLine("False");
                    }
                }
            }
        }
    }
}


