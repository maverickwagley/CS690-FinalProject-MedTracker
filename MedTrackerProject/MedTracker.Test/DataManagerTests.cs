namespace MedTracker.Test;

public class DataManagerTests
{
    DataManager testDM;

    public DataManagerTests()
    {
        testDM = new();
    }
    [Fact]
    public void Test_Init()
    {
        var _name = testDM.Username;
        Assert.Equal("New User",_name);
    }
}
