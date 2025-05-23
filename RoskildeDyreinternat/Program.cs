using System.Threading.Channels;
using System.Xml.Serialization;
using LibDyreInternat;
using Library;

namespace RoskildeDyreinternat
{
    public class Program
    {
        static void Main(string[] args)
        {
            AnimalRepo.AddDog("bulldog", true, "everything", 123456, "Alex", 2020, 55, Sex.male, false);
            AnimalRepo.AddCat("bulldog", true, "everything", 123456, "Adam", 2020, 55, Sex.male, true);
            AnimalRepo.AddFish("bulldog", "everything", "Dorry", 2020, 55, Sex.male, true);
            AnimalRepo.AddDog("bulldog", true, "everything", 123456, "Bent", 2020, 55, Sex.male, false);
            AnimalRepo.AddCat("bulldog", true, "everything", 123456, "Anette", 2020, 55, Sex.male, false);
            AnimalRepo.AddFish("bulldog", "everything", "Nemo", 2020, 55, Sex.male, true);
            
            MedicalLogRepo.Add("Broken leg", new(2025, 05, 20, 10, 00, 00), AnimalRepo.GetById(2), "Gert");
            MedicalLogRepo.Add("Broken leg", new(2025, 05, 20, 10, 00, 00), AnimalRepo.GetById(1), "Gert");

            PersonRepo.Add(new Person("Toke", "01-01-01", "Holte", "12345678", "Toke@toke.dk", Acceslevel.admin));

            //Dog dog1 = new Dog("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            //Cat cat1 = new Cat("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            //Fish fish1 = new Fish("Golden Retriver", "nem at vedligeholde", "Bobby", 2024, 25, Sex.hermaphrodite);

            //Console.WriteLine(fish1);

            MainHandler handler = new MainHandler();

           
        }

    }
    
}
