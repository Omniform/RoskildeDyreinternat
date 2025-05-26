using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LibDyreInternat
{
    public static class AnimalRepo
    {
        public static List<Animal> animalRepo = new List<Animal>();
        public static void AddDog(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex, bool isUpForAdoption)
        {
            animalRepo.Add(new Dog(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex, isUpForAdoption));
        }

        public static void AddCat(string race, bool isChildFriendly, string foodPrefrences, int chipNumber, string name, int birthYear, int weight, Sex sex, bool isUpForAdoption)
        {
            animalRepo.Add(new Cat(race, isChildFriendly, foodPrefrences, chipNumber, name, birthYear, weight, sex, isUpForAdoption));
        }

        public static void AddFish(string species, string maintainence, string name, int birthYear, int weight, Sex sex, bool isUpForAdoption)
        {
            animalRepo.Add(new Fish(species, maintainence, name, birthYear, weight, sex, isUpForAdoption));
        }

        public static Animal GetById(int id)
        {
            foreach (Animal animal in animalRepo)
            {
                if (animal.Id == id)
                {
                    return animal;
                }
            }

            return null;

        }


        public static void Remove(Animal animal)
        {
            animalRepo.Remove(animal);
        }

        public static string AllToString()
        {
            string s = "";
            foreach (Animal animal in animalRepo) { s += animal.ToString() + "\n"; }
            return s;
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
            return s;
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
            return s;
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
            return s;
        }

        public static void AnimalsSortedByType()
        {
            List<Animal> animals = animalRepo;

            Dictionary<string, List<Animal>> typeDictionaries = new Dictionary<string, List<Animal>>();
            
            foreach (Animal a in animals)
            {
                string typeName = a.GetType().Name;

                if (!typeDictionaries.ContainsKey(typeName))
                {
                    typeDictionaries[typeName] = new List<Animal>();
                }
                typeDictionaries[typeName].Add(a);
            }
        

            List<string> sortedTypes = new List<string>(typeDictionaries.Keys);

            for (int i = 1; i < sortedTypes.Count; i++)
            {
                string current = sortedTypes[i];
                int j = i - 1;

                while (j >= 0 && typeDictionaries[sortedTypes[j]].Count < typeDictionaries[current].Count)
                {
                    sortedTypes[j + 1] = sortedTypes[j];
                    j--;
                }
                sortedTypes[j + 1] = current;
            }

            foreach (string type in sortedTypes)
            {
                Console.WriteLine($"\nType: {type}({typeDictionaries[type].Count})");
                foreach (Animal a in typeDictionaries[type])
                {
                    Console.WriteLine(a);
                }   
            }

            }
        }
    }

