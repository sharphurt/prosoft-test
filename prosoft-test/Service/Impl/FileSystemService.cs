namespace ProsoftTest.Service.Impl;

public class FileSystemService : IFileSystemService
{
    public void Call(string path)
    {
        foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
        {
            var fileStream = File.ReadLines(file);
        }
    }
}