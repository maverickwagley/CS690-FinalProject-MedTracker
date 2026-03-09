using System.IO;

namespace MedTracker;
public class DataManager
{
    public FileSaver userFile { get; set; }
    public FileSaver medicationFile { get; set; }
    public FileSaver symptomsFile { get; set; }
    public FileSaver appointmentsFile { get; set; }
    public string Username { get; set; }
    public List<Medication> Meds { get; }
    public List<Symptom> Symptoms { get; }
    public List<Appointment> Appointments { get; }
    public DataManager()
    {
        userFile = new FileSaver("user-data.txt");
        medicationFile = new FileSaver("meds-data.txt");
        Meds = new();
        Symptoms = new();
        symptomsFile = new FileSaver("symptoms-data.txt");
        Appointments = new();
        appointmentsFile = new FileSaver("appointments-data.txt");

        if (File.Exists("user-data.txt"))
        {
            var userDataContent = File.ReadAllLines("user-data.txt");
            foreach (var line in userDataContent)
            {
                RenameUser(line);
            }
        }

        if (File.Exists("meds-data.txt"))
        {
            var medsDataContent = File.ReadAllLines("meds-data.txt");
            foreach (var line in medsDataContent)
            {
                Meds.Add(new Medication(line));
            }
        }

        if (File.Exists("symptoms-data.txt"))
        {
            var symsDataContent = File.ReadAllLines("symptoms-data.txt");
            foreach (var line in symsDataContent)
            {
                var splitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                Symptoms.Add(new Symptom(splitted[0], splitted[1]));
            }
        }
        if (File.Exists("appointments-data.txt"))
        {
            var appsDataContent = File.ReadAllLines("appointments-data.txt");
            foreach (var line in appsDataContent)
            {
                var splitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                Appointments.Add(new Appointment(splitted[0], splitted[1]));
            }
        }
    }

    public void AddMedication(string medName)
    {
        Meds.Add(new Medication(medName));
        medicationFile.AppendLine(medName);
    }
    public void AddSymptom(string symName, string desc)
    {
        Symptoms.Add(new Symptom(symName, desc));
        symptomsFile.AppendLine(symName + ":" + desc);
    }
    public void AddAppointment(string appName, string appDate)
    {
        Appointments.Add(new Appointment(appName, appDate));
        appointmentsFile.AppendLine(appName+":"+appDate);
    }
    public void RenameUser(string userName)
    {
        this.Username = userName;
        File.WriteAllText("user-data.txt", this.Username);
    }
}