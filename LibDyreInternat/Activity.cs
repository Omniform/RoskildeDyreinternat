using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace LibDyreInternat
{
    public class Event
    {
        static private int ID { get; set; }
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateOnly Date { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public List<Person> Members { get; private set; } = new List<Person>();
        private Person m_coordinator;
        public Person Coordinator
        {
            get { return m_coordinator; }
            set
            {
                if (PersonExist(value))
                {
                    m_coordinator = value;
                }
                else
                {
                    PersonNotFound();
                }
            }
        }

        public Event(in string name, in DateOnly date, in TimeOnly startTime, in TimeOnly endTime, in Person coordinator)
        {
            Id = ++ID;
            Name = name;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Coordinator = coordinator;
        }

        public void ChangeDateAndTime(in DateOnly date, in TimeOnly startTime, in TimeOnly endTime)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nNavn: {Name}\nDato: {Date} {StartTime} - {EndTime}\nKordinatorId: {Coordinator.Id}\nKordinatorNavn: {Coordinator.Name}";
        }

        public bool AddMember(in Person member)
        {
            if (member == null)
            {
                Console.WriteLine("Denne person findes ikke");
                return false;
            }

            foreach (Person person in Members)
            {
                if (person.Id == member.Id)
                {
                    Console.WriteLine("\nDenne person er allerede en del af aktiviteten");
                    return false;
                }
            }

            if (!PersonExist(member))
            {
                Console.WriteLine("\nDer er ingen med dette id");
                return false;
            }

            Members.Add(member);
            return true;
        }

        public bool RemoveMember(in Person? person)
        {
            if (person == null)
            {
                return false;
            }

            for (int i = 0; i < Members.Count; i++)
            {
                if (person.Id == Members.ElementAt(i).Id)
                {
                    Members.RemoveAt(i);
                    return true;
                }
            }
            Console.WriteLine("Personen er ikke en del af aktiviteten");
            return false;
        }

        public Person? GetMemberById(in int id)
        {
            foreach (Person person in Members)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public string AllMembersToString()
        {
            string s = "";
            foreach (Person members in Members)
            {
                s += $"Id: {members.Id}\nNavn: {members.Name}\nEmail: {members.Email}\n";
            }
            return s;
        }

        private bool PersonExist(Person person)
        {
            foreach (Person p in PersonRepo.AllPersons)
            {
                if (p.Id == person.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void PersonNotFound()
        {
            throw new TargetException("Person ikke fundet");
        }
    }
}