namespace MedTracker;
public class DataManager
{
    
    public string Username { get; set; }
    public List<Medication> Meds { get; }
    public List<Symptom> Symptoms { get; }
    public List<Appointment> Appointments { get; }
    public DataManager()
    {
        Username = "New User";
        Meds = new();
        Meds.Add(new Medication("Example Med"));
        Symptoms = new();
        Symptoms.Add(new Symptom("Example Experience", "An imaginary headache of unbelievable pain that lasted forever."));
        Appointments = new();
        Appointments.Add(new Appointment("Example Appointment", "5/17/26"));
    }

    public void AddMedication(string medName)
    {
        Meds.Add(new Medication(medName));
    }
    public void AddSymptom(string symName, string desc)
    {
        Symptoms.Add(new Symptom(symName, desc));
    }
    public void AddAppointment(string appName, string appDate)
    {
        Appointments.Add(new Appointment(appName, appDate));
    }
    public void RenameUser(string userName)
    {
        this.Username = userName;
    }
}