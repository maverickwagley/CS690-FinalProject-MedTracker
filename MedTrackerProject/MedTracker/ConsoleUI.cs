namespace MedTracker;

using System.Reflection.Metadata;
using Spectre.Console;
public class ConsoleUI
{
    
    public DataManager dataManager;
    public ConsoleUI() 
    { 
        dataManager = new DataManager();
    }  
    /// <summary>
    /// Show the Main Console UI.
    /// </summary>
    public void Show() 
    { 
        string mode;

        do 
        {
        //Select Driver or Manager
        Console.WriteLine("Welcome " + dataManager.Username);
        if (dataManager.Appointments.Count() >= 1)
        {
            Console.WriteLine($"Your next appointment is {dataManager.Appointments[0].Name} on {dataManager.Appointments[0].Date}");
        }
        else
        {
            Console.WriteLine("You have no upcoming appointments.");
        }
        mode = AnsiConsole.Prompt( 
            new SelectionPrompt<string>()
            .Title("Please select mode")
            .AddChoices(new[] {"Medication","Symptoms","Appointments","User","Exit" }));

        //
        
        if (mode == "Medication")
        { 
            string medMode;
            do 
            { 
                Console.WriteLine("Track Your Medicataion");
                medMode = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(new[] {"View Daily Meds","Add a Daily Med","Remove a Daily Med","Back" }));
                if (medMode == "View Daily Meds")
                {
                    var table = new Table(); 
                    table.AddColumn("Medications");
                    foreach(var med in dataManager.Meds) 
                    { 
                        table.AddRow(med.Name);
                    }
                    AnsiConsole.Write(table); 
                }
                else if (medMode == "Add a Daily Med")
                {
                    Console.WriteLine("Add a new Daily Medication. Type \'back\' to return.");
                    var newMedName = AnsiConsole.Prompt(new TextPrompt<string>("Add a Daily Med:"));
                    if (newMedName != "back")
                    {
                        dataManager.AddMedication(newMedName);
                    }
                }
                else if (medMode == "Remove a Daily Med")
                {
                    //Make a list of the names of the meds 
                    List<string> _medNames = new();
                    foreach (Medication meds in dataManager.Meds)
                    {
                        _medNames.Add(meds.Name);
                    }
                    _medNames.Add("Back");
                    Console.WriteLine("Remove a Daily Medication.");
                    var removeMed = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(_medNames));
                    if (removeMed != "Back") { dataManager.RemoveMedication(removeMed);}
                }
            }
            while (medMode != "Back");
        } 
        else if(mode == "Symptoms")
        {
            string symptomMode;
            do
            {
                Console.WriteLine("Track Your Symptoms");
                symptomMode = AnsiConsole.Prompt( 
                    new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(new[] {"View a Previous Symptom","Log a Symptom","Back" }));

                if (symptomMode == "View a Previous Symptom")
                {
                    Console.WriteLine("View previous entries in your symptom log.");
                    var table = new Table(); 
                    table.AddColumn("Entry Names");
                    table.AddColumn("Description");
                    foreach(var sym in dataManager.Symptoms) 
                    { 
                        table.AddRow(sym.Name, sym.Description);
                    }
                    AnsiConsole.Write(table); 
                }
                if (symptomMode == "Log a Symptom")
                {
                    Console.WriteLine("Log a new symptom experience");
                    Console.WriteLine("Give the entry a name. Type \'back\' to return.");
                    var newSymName = AnsiConsole.Prompt(new TextPrompt<string>("name the entry:"));
                    if (newSymName != "back")
                    {
                        Console.WriteLine("Describe the experience. Type \'back\' to return.");
                        var newSymDesc = AnsiConsole.Prompt(new TextPrompt<string>("describe the experience:"));
                        if (newSymDesc != "back")
                        {
                            dataManager.AddSymptom(newSymName,newSymDesc);
                        }
                    }
                }
            } while(symptomMode != "Back");
        }
        else if(mode == "Appointments")
        {
            string appointmentMode;
            do
            {
                Console.WriteLine("Track Your Appointments");
                appointmentMode = AnsiConsole.Prompt( 
                    new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(new[] {"View an Upcoming Appointment", "Add an Upcoming Appointment","Remove an Appointment", "Back" }));
                if (appointmentMode == "View an Upcoming Appointment")
                {
                    Console.WriteLine("View Upcoming Appointments.");
                    var table = new Table(); 
                    table.AddColumn("Appointment Name");
                    table.AddColumn("Date");
                    foreach(var app in dataManager.Appointments) 
                    { 
                        table.AddRow(app.Name,app.Date);
                    }
                    AnsiConsole.Write(table); 
                }
                if (appointmentMode == "Add an Upcoming Appointment")
                {
                    Console.WriteLine("Add an Upcoming Appointment");
                    Console.WriteLine("Give the appointment a name. Type \'back\' to return.");
                    var newAppName = AnsiConsole.Prompt(new TextPrompt<string>("name the appt.:"));
                    if (newAppName != "back")
                    {
                        Console.WriteLine("Give the date of the appointment. Type \'back\' to return.");
                        var newAppDesc = AnsiConsole.Prompt(new TextPrompt<string>("date:"));
                        if (newAppDesc != "back")
                        {
                            dataManager.AddAppointment(newAppName,newAppDesc);
                        }
                    }
                }
                if (appointmentMode == "Remove an Appointment")
                {
                    //
                    List<string> _appNames = new();
                    foreach (Appointment apps in dataManager.Appointments)
                    {
                        _appNames.Add(apps.Name);
                    }
                    _appNames.Add("Back");
                    Console.WriteLine("Remove an Appointment");
                    var removeApp = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please select mode")
                    .AddChoices(_appNames));
                    if (removeApp != "Back") { dataManager.RemoveAppointment(removeApp);}
                }
            } while(appointmentMode != "Back");
        }
        else if(mode == "User")
        {
            string userMode;
            
            do
            {
                Console.WriteLine("Hello " + dataManager.Username);
                userMode = AnsiConsole.Prompt( 
                    new SelectionPrompt<string>()
                    .Title("Update Username?")
                    .AddChoices(new[] {"Yes, rename user", "No, return" }));
                if (userMode == "Yes, rename user")
                {
                    Console.WriteLine("Enter a new user name. Type \'back\' to return.");
                    var newUserName = AnsiConsole.Prompt(new TextPrompt<string>("user name:"));
                    if (newUserName != "back")
                    {
                        dataManager.RenameUser(newUserName);
                    }
                }
            }while(userMode != "No, return");
        }
    }while(mode != "Exit");

    //Exit Text
    Console.WriteLine($"Don't forget your next appointment is {dataManager.Appointments[0].Name} on {dataManager.Appointments[0].Date}");
    Console.WriteLine("Have a great day!");
    }
}