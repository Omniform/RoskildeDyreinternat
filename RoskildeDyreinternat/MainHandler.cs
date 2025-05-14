using LibDyreInternat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoskildeDyreinternat
{
    public class MainHandler
    {
        public MainHandler()
        {

            Console.WriteLine("Velkommen til Roskilde Dyreinternats side");
            Console.WriteLine("For at bruge programmet bruger du tal for at vælge mulighederne.");
            while (true) 
            {
                Console.WriteLine("1: Tilføj\n2: Ændr\n3: Slet\n4: Se\n5: Book\n6: Luk");
                switch (Console.ReadLine())
                {
                    case "1":
                        ValueEvent("1");
                        break;
                    case "2":
                        ValueEvent("2");
                        break;
                    case "3":
                        ValueEvent("3");
                        break;
                    case "4":
                        ValueEvent("4");
                        break;
                    case "5":
                        ValueEvent("5");
                        break;
                    case "6":
                        ValueEvent("6");
                        break;
                }
            }
            
        }

        private void ValueEvent(string firstInputResult)
        {
            Console.WriteLine($"Hvad vil du gerne {firstInputResult}");
            Console.WriteLine("1: Dyr\n2: Person\n3: Aktivitet\n4: Blog\n5: Lægejournal\n6: Booking");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    MedicalJournalEvent(firstInputResult);
                    break;
                case "6":
                    break;
            }
        }

        private void MedicalJournalEvent(string firstInputResult)
        {
            switch (firstInputResult)
            {
                case "1":
                    Console.WriteLine("Indtast beskrivelse"); 
                    string description = Console.ReadLine();
                    Console.WriteLine("Indtast tidspunkt i dette format: dd-MM-åååå HH:mm");
                    DateTime dateTime = DateTime.ParseExact(description, "dd - MM - yyyy HH: mm", null);
                    Console.WriteLine("Intast dyrets ID");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Indtast navnet på Dyrlægen");
                    string nameDoctor = Console.ReadLine();
                    MedicalLogRepo.Add(description, dateTime, AnimalRepo.GetById(id), nameDoctor);
                    break;
                case "2":
                    ValueEvent("2");
                    break;
                case "3":
                    ValueEvent("3");
                    break;
                case "4":
                    ValueEvent("4");
                    break;
                case "5":
                    ValueEvent("5");
                    break;
                case "6":
                    ValueEvent("6");
                    break;
            }
        }
    }

}
