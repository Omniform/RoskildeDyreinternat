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
    private List<Person>? Members { get; set; } = null;
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
        }
        else
        {
            PersonNotFound();
        }
    }

    public void AddMember(Person member)
    {
        if(PersonExist(member))
        {
            Members.Add(member);
        }
        else
        {
            PersonNotFound();
        }
    }

    public void RemoveMember(Person person)
    {
        if (!Members.Remove(person))
        {
            Console.WriteLine("The person was not a part of the activity");
        }
    }

    private bool PersonExist(Person person)
    {
        if (PersonRepo.AllPerson.Contains(person))
        {
            return true;
        }
        return false;
    }

    private void PersonNotFound()
    {
        throw new TargetException("Person not found");
    }
}