namespace MedTracker.Test;

public class DataManagerTests
{
    DataManager testDM;

    public DataManagerTests()
    {
        testDM = new();
    }
    [Fact]
    public void Test_DM_Init()
    {
        var _name = testDM.Username;
        Assert.Equal("New User",_name);
    }
    [Fact]
    public void Test_AddMed()
    {
        testDM.AddMedication("med2");
        var mName = testDM.Meds[0].Name;
        Assert.Equal("med2", mName);
    }
    [Fact]
    public void Test_RemoveMed()
    {
        testDM.RemoveMedication("med2");
        int mCount = testDM.Meds.Count;
        Assert.Equal(0, mCount);
    }
}
