namespace MedTracker.Test;

public class ConsoleUITests
{
    ConsoleUI testUI;

    public ConsoleUITests()
    {
        testUI = new();
    }
    [Fact]
    public void Test_Console_Init()
    {
        //Test that the console is created with a data manager
        string _n = "New User";
        if (File.Exists("user-data.txt")) 
        { 
            var userDataContent = File.ReadAllLines("user-data.txt");
            foreach (var line in userDataContent)
            {
                _n = line;
            }
        }
        Assert.Equal(testUI.dataManager.Username,_n);

    }
}
