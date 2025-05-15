using System.Threading.Channels;
using System.Xml.Serialization;
using LibDyreInternat;

namespace RoskildeDyreinternat
{
    public class Program
    {
        static void Main(string[] args)
        {
            AnimalRepo.AddDog("bulldog", true, "everything", 123456, "bent", 2020, 55, Sex.male);
            MedicalLogRepo.Add("Broken leg", new(2025, 05, 20, 10, 00, 00),AnimalRepo.GetById(1),"Gert");
            AnimalRepo.AddCat("bulldog", true, "everything", 123456, "bent", 2020, 55, Sex.male);
            AnimalRepo.AddFish("bulldog", "everything", "bent", 2020, 55, Sex.male);
            //Dog dog1 = new Dog("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            //Cat cat1 = new Cat("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            //Fish fish1 = new Fish("Golden Retriver", "nem at vedligeholde", "Bobby", 2024, 25, Sex.hermaphrodite);

            //Console.WriteLine(fish1);

            MainHandler handler = new MainHandler();

           
        }

    }
    
}
