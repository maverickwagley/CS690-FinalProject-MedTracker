using Spectre.Console;
public class ConsoleUI
{
    
    public ConsoleUI() 
    { 
        
    } 
    /// <summary>
    /// Show the Main Console UI.
    /// </summary>
    public void Show() 
    { 
        //Select Driver or Manager
        Console.WriteLine("Welcome");
        var mode = AnsiConsole.Prompt( 
            new SelectionPrompt<string>()
            .Title("Please select mode")
            .AddChoices(new[] {"Medication","Symptoms","Appointments","User","Exit" }));

        //
        if (mode == "Medication")
        { 
           Console.WriteLine("Track Your Medicataion");
            var medMode = AnsiConsole.Prompt( 
                new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {"View a Day of Meds","Remove a Daily Med","Add a Daily Med","Back" }));
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