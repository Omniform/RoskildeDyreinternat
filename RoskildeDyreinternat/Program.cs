using System.Threading.Channels;
using System.Xml.Serialization;
using LibDyreInternat;

namespace RoskildeDyreinternat
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            Cat cat1 = new Cat("Golden Retriver", true, "Korn fri", 25, "Bobby", 2024, 25, Sex.male);

            Fish fish1 = new Fish("Golden Retriver", "nem at vedligeholde", "Bobby", 2024, 25, Sex.hermaphrodite);

            Console.WriteLine(fish1);

           
        }

    }
    
}
