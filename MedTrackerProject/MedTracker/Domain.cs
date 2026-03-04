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
}
//Appointment
public class Appointment
{
    public string Name { get; }
}