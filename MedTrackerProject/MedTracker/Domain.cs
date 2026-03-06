using System.Runtime.InteropServices;

namespace MedTracker;

//Medication
public class Medication
{
    public string Name { get; } 
    public Medication(string name) { 
        this.Name = name; 
    } 
}
//Symptom
public class Symptom
{
    public string Name { get; }
    public string Description { get; }
    public Symptom(string name, string desc)
    {
        this.Name = name;
        this.Description = desc;
    }

}
//Appointment
public class Appointment
{
    public string Name { get; }
    public string Date { get; }
    public Appointment(string name, string date)
    {
        this.Name = name;
        this.Date = date;
    }
}