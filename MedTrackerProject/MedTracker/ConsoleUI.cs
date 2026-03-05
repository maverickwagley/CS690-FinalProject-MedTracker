namespace MedTracker;

using System.Reflection.Metadata;
using Spectre.Console;
public class ConsoleUI
{
    
    DataManager dataManager;
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
                    .AddChoices(new[] {"View Daily Meds","Add a Daily Med","Back" }));
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
                    .AddChoices(new[] {"Log a Symptom","View a Previous Symptom","Back" }));

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
           Console.WriteLine("View an Upcoming Appointment");
            var appointmentMode = AnsiConsole.Prompt( 
                new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {"Appointment A", "Back" }));
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
    }
}