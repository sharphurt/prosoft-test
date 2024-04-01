namespace ProsoftTest.Model;

public class LogFile
{
    public string FileName { get; }
    public string FilePath { get; }

    public LogFile(string path)
    {
        if (!Path.Exists(path))
            throw new FileNotFoundException(path);
        
        FilePath = Path.GetFullPath(path);
        FileName = Path.GetFileName(path);
    }
}