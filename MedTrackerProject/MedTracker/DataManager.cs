namespace MedTracker;
public class DataManager
{
    
    public string Username { get; set; }
    public List<Medication> Meds { get; }
    public List<Symptom> Symptoms { get; }
    public List<Symptom> Appointments { get; }
    public DataManager()
    {
        Username = "New User";
        Meds = new();
        Meds.Add(new Medication("Zyrtek"));
        Meds.Add(new Medication("Sugarpills"));
        Meds.Add(new Medication("Antirabies"));
        Symptoms = new();
        Appointments = new();
    }

    public void AddMedication(string medName)
    {
        Meds.Add(new Medication(medName));
    }
    public void AddSymptom(string symName, string desc)
    {
        Symptoms.Add(new Symptom(symName, desc));
    }
    public void RenameUser(string userName)
    {
        this.Username = userName;
    }
}