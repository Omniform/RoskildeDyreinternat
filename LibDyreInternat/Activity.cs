using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace LibDyreInternat
{
    public class Activity
    {
        static private int ID { get; set; }
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateOnly Date { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public List<Person>? Members { get; private set; } = null;
        private Person m_coordinator;
        public Person Coordinator { get { return m_coordinator; }
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

        public Activity(in string name, in DateOnly date, in TimeOnly startTime, in TimeOnly endTime, in Person coordinator)
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
            return $"Id: {Id}\nNavn: {Name}\nDato: {Date} {StartTime} - {EndTime}\nKordinator {Coordinator}";
        }

        public void AddMember(in Person member)
        {
            if (PersonExist(member))
            {
                Members.Add(member);
                return;
            }
            PersonNotFound();
        }

        public void RemoveMember(in Person person)
        {
            if (Members == null)
            {
                throw new NullReferenceException("Der er ikke nogle medlemmer i aktiviteten");
            }

            if (!Members.Remove(person))
            {
                Console.WriteLine("Personen er ikke en del af aktiviteten");
            }
        }

        private bool PersonExist(in Person person)
        {
            if (PersonRepo.AllPersons.Contains(person))
            {
                return true;
            }
            return false;
        }

        private void PersonNotFound()
        {
            throw new TargetException("Person ikke fundet");
        }
    }
}