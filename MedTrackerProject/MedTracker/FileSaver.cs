using System.IO;

public class FileSaver 
{ 
    string fileName; 
    public FileSaver(string fileName)
    { 
        this.fileName = fileName; 
        if (!File.Exists(this.fileName))
        {
            File.Create(this.fileName).Close(); 
        }
    } 
    /// <summary>
    /// Add single string to file as a new line.
    /// </summary>
    public void AppendLine(string line) 
    { 
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }
} 