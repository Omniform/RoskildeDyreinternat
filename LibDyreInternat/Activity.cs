using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
namespace LibDyreInternat;

public class Activity
{
    static private int ID { get; set; }
    public int Id { get; private set; }
    public string Name { get; set; }
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public List<Person>? Members { get; private set; } = null;
    public Person Coordinator { get; private set; }

    public Activity(string name, DateOnly date, TimeOnly startTime, TimeOnly endTime, Person coordinator)
    {
        Id = ++ID;
        Name = name;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        if (PersonExist(coordinator))
        {
            Coordinator = coordinator;
        }
        else
        {
            PersonNotFound();
        }
    }

    public void ChangeDateAndTime(DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
    }

    public override string ToString()
    {
        return $"Id: {Id}\nNavn: {Name}\nDato: {Date} {StartTime} - {EndTime}\nKordinator {Coordinator}";
    }

    public void ChangeCoordinator(Person coordinator)
    {
        if (PersonExist(coordinator))
        {
            Coordinator = coordinator;
            return;
        }
        PersonNotFound();
    }

    public void AddMember(Person member)
    {
        if(PersonExist(member))
        {
            Members.Add(member);
            return;
        }
        PersonNotFound();
    }

    public void RemoveMember(Person person)
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

    private bool PersonExist(Person person)
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