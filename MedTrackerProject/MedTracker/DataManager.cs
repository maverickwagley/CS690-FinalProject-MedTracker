using System.IO;

namespace MedTracker;
public class DataManager
{
    public FileSaver userFile { get; set; }
    public FileSaver medicationFile { get; set; }
    public FileSaver symptomsFile { get; set; }
    public FileSaver appointmentsFile { get; set; }
    public string Username { get; set; } = "New User";
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
                if (splitted.Count() >= 2)
                {
                    Appointments.Add(new Appointment(splitted[0], splitted[1]));
                }
                else
                {
                    Appointments.Add(new Appointment(splitted[0], "No Date Set"));
                }
            }
        }
    }

    public void AddMedication(string medName)
    {
        Meds.Add(new Medication(medName));
        medicationFile.AppendLine(medName);
    }
    public void RemoveAppointment(string appName)
    {
        Appointment _remove = null; 
        foreach (var app in Appointments)
        {
            if (app.Name == appName)
            {
                _remove = app;
                break;
            }
        }
        if (_remove != null)
        {
            Appointments.Remove(_remove);
            SynchronizeAppointment(); 
        }
        
    }
    public void RemoveMedication(string medName)
    {
        Medication _remove = null; 
        foreach (var med in Meds)
        {
            if (med.Name == medName)
            {
                _remove = med;
                break;
            }
        }
        if (_remove != null)
        {
            Meds.Remove(_remove);
            SynchronizeMedication(); 
        }
        
    }
    public void SynchronizeAppointment()
    {
        File.Delete("appointments-data.txt");
        foreach (var apps in Appointments)
        {
            File.AppendAllText("appointments-data.txt", apps.Name + ":" + apps.Date + Environment.NewLine);
        }
    }
    public void SynchronizeMedication()
    {
        File.Delete("meds-data.txt");
        foreach (var meds in Meds)
        {
            File.AppendAllText("meds-data.txt", meds.Name + Environment.NewLine);
        }
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