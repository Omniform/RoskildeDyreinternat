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

            BookingRepo.Add(new DateOnly(2025, 05, 20), new TimeOnly(10, 00), AnimalRepo.GetById(2), PersonRepo.GetById(1));
            BookingRepo.Add(new DateOnly(2025, 06, 30), new TimeOnly(13, 00), AnimalRepo.GetById(5), PersonRepo.GetById(3));

            PersonRepo.Add(new Person("Toke", "01-01-01", "Holte", "12345678", "Toke@toke.dk", Acceslevel.admin));

            EventRepo.Add("Åbent hus", new DateOnly(2025, 11, 24), new TimeOnly(13, 00), new TimeOnly(15, 30), PersonRepo.GetById(1));

            MainHandler handler = new MainHandler();

           
        }

    }
    
}
