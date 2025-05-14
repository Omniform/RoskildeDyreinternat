using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibDyreInternat
{

    public enum Sex
    {
        male = 1,
        female,
        hermaphrodite
    }

    public abstract class Animal
    {
        private static int idnext = 1;
        public int Id { get; private set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Weight { get; set; }
        public Sex Sex { get; set; }


        

        public Animal(string name, int birthYear, int weight, Sex sex)
        {
            Id = idnext++;
            Name = name;
            BirthYear = birthYear;
            Weight = weight;
            Sex = sex;
        }

        //public override string ToString()
        //{
        //    string sex = "";
        //    switch (Sex)
        //    {
        //        case Sex.male:
        //            sex = "Han";
        //            break;
        //        case Sex.female:
        //            sex = "Hun";
        //            break;
        //        case Sex.hermaphrodite:
        //            sex = "Tvekønnet";
        //            break;
        //    }

        //    return $"Dyrets navn er: {Name}\nFødselsår: {BirthYear}\nWeight: {Weight}\nKøn: {sex}";

        //}


    }

}
