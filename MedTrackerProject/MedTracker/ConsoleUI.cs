namespace MedTracker;

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
        //Select Driver or Manager
        Console.WriteLine("Welcome " + dataManager.Username);
        var mode = AnsiConsole.Prompt( 
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
                    Console.WriteLine("Add a new Daily Medication. Type back to return.");
                    var newStopName = AnsiConsole.Prompt(new TextPrompt<string>("Add a Daily Med:"));
                    dataManager.AddMedication(newStopName);
                }
            }
            while (medMode != "Back");
        } 
        else if(mode == "Symptoms")
        {
           Console.WriteLine("Track Your Symptoms");
            var symptomMode = AnsiConsole.Prompt( 
                new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {"Log a Symptom","View a Previous Symptom","Back" }));
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
           Console.WriteLine("Hello UserName.");
           var userMode = AnsiConsole.Prompt( 
                new SelectionPrompt<string>()
                .Title("Update Username?")
                .AddChoices(new[] {"Yes", "No" }));
        }
        else if(mode == "Exit")
        {
           
        }
    }
}