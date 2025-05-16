using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LibDyreInternat
{
    public static class AnimalRepo
    {
        public static List<Animal> animalRepo = new List<Animal>();
        public static void AddDog(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Dog(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex));
        }

        public static void AddCat(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Cat(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex));
        }

        public static void AddFish(string species, string maintainence, string name, int birthYear, int weight, Sex sex)
        {
            animalRepo.Add(new Fish(species, maintainence, name, birthYear, weight, sex));
        }

        public static Animal GetById(int Id)
        {
            string s = "";
            Animal animal1 = null;
            foreach (Animal animal in animalRepo)
            {
                if (animal.Id == Id)
                {
                    s = animal.ToString();
                    animal1 = animal;

                }
            }
            return animal1;

            //return $"{s}";
        }

        public static void Remove(Animal animal)
        {
            animalRepo.Remove(animal);
            //foreach (Animal a in animalRepo)
            //{
            //    if (a.Id == Id)
            //    {
            //        animalRepo.Remove(a);
            //    }
            //}
        }

        public static string AllToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo) { s += animal.ToString() + "\n"; }
            return s + "\n";
        }

        public static string DogsToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo)
            {
                if (animal is Dog)
                {
                    s += animal.ToString() + "\n";
                }
            }
            return s + "\n";
        }
        public static string CatsToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo)
            {
                if (animal is Cat)
                {
                    s += animal.ToString() + "\n";
                }
            }
            return s + "\n";
        }

        public static string FishToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo)
            {
                if (animal is Fish)
                {
                    s += animal.ToString() + "\n";
                }
            }
            return s + "\n";
        }
        
    }
}
