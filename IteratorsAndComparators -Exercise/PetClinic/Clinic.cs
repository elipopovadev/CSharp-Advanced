using System;
using System.Linq;

namespace PetClinic
{
    public class Clinic 
    {
        public Clinic(string name, int numberOfRooms)
        {
            if (numberOfRooms % 2 != 0)
            {
                this.Name = name;
                this.NumberOfRooms = numberOfRooms;
                this.RoomsInTheClinic = new Pet[numberOfRooms];
            }

            else
            {
                throw new InvalidOperationException();
            }
        }

        public string Name { get; set; }
        public int NumberOfRooms { get; set; }
        public Pet[] RoomsInTheClinic;

        public bool Add(Pet pet)
        {
            int middleRoomIndex = this.NumberOfRooms / 2;
            int elementsForSearch = 1;
            while(elementsForSearch != this.NumberOfRooms-1)
            {
                if (this.RoomsInTheClinic[middleRoomIndex] == null)
                {
                    this.RoomsInTheClinic[middleRoomIndex] = pet;
                    return true;
                }
                if (this.RoomsInTheClinic[middleRoomIndex - elementsForSearch] == null)
                {
                    this.RoomsInTheClinic[middleRoomIndex - elementsForSearch] = pet;
                    return true;
                }
                if (this.RoomsInTheClinic[middleRoomIndex + elementsForSearch] == null)
                {
                    this.RoomsInTheClinic[middleRoomIndex + elementsForSearch] = pet;
                    return true;
                }

                elementsForSearch++;
            }

            return false;
        }

        public bool Release()
        {
            int middleRoomIndex = this.NumberOfRooms / 2;
            if (this.RoomsInTheClinic[middleRoomIndex] != null)
            {
                this.RoomsInTheClinic[middleRoomIndex] = null;
                return true;
            }

            else if(this.RoomsInTheClinic[middleRoomIndex] == null)
            {
                for (int i = middleRoomIndex + 1; i < this.RoomsInTheClinic.Length; i++)
                {
                    if(this.RoomsInTheClinic[i] != null)
                    {
                        this.RoomsInTheClinic[i] = null;
                        return true;
                    }
                }

                for (int k = 0; k < middleRoomIndex-1; k++)
                {
                    if (this.RoomsInTheClinic[k] != null)
                    {
                        this.RoomsInTheClinic[k] = null;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasEmptyRoom()
        {
            return this.RoomsInTheClinic.Any(r => r == null);
        }

        public void Print()
        {
            foreach (var pet in this.RoomsInTheClinic)
            {
                if (pet == null)
                {
                    Console.WriteLine("Room empty");
                }

                else
                {
                    Console.WriteLine(pet.ToString());
                }
            }
        }

        public void PrintRoom(int index)
        {
            if (this.RoomsInTheClinic[index - 1] == null)
            {
                Console.WriteLine("Room empty");
            }

            else
            {
                Console.WriteLine(this.RoomsInTheClinic[index - 1].ToString());
            }            
        }
    }
}
