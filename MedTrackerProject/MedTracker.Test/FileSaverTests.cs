namespace MedTracker.Test;

public class FileSaverTests
{
    FileSaver testFS;

    public FileSaverTests()
    {
        testFS = new("test-file.txt");
    }
    [Fact]
    public void Test_FS_Init()
    {
        testFS.AppendLine("my new test line appended");
        string _line = "";
        if (File.Exists("test-file.txt")) 
        { 
            var testFSContent = File.ReadAllLines("test-file.txt");
            _line = testFSContent[0];
        }
        Assert.Equal("my new test line appended",_line);
    }
}
