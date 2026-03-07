using System.IO;

namespace MedTracker;
public class DataManager
{
    public FileSaver userFile { get; set; }
    public FileSaver medsFile { get; set; }
    public FileSaver symptomsFile { get; set; }
    public FileSaver appsFile { get; set; }
    public string Username { get; set; }
    public List<Medication> Meds { get; }
    public List<Symptom> Symptoms { get; }
    public List<Appointment> Appointments { get; }
    public DataManager()
    {
        userFile = new FileSaver("user-data.txt");
        Username = "User Name";
        Meds = new();
        Meds.Add(new Medication("Example Med"));
        Symptoms = new();
        Symptoms.Add(new Symptom("Example Experience", "An imaginary headache of unbelievable pain that lasted forever."));
        Appointments = new();
        Appointments.Add(new Appointment("Example Appointment", "5/17/26"));

        if (File.Exists("user-data.txt"))
        {
            var userDataContent = File.ReadAllLines("user-data.txt");
            foreach (var line in userDataContent)
            {
                RenameUser(line);
            }
        }
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
        File.WriteAllText("user-data.txt", this.Username);
    }
}