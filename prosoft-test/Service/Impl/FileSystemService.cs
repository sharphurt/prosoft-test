using ProsoftTest.Model;

namespace ProsoftTest.Service.Impl;

public class FileSystemService : IFileSystemService
{
    public IEnumerable<string> GetFilesInPath(string path)
    {
        return Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
    }

    public void WriteEnumerableToLog(string basePath, string filename, IEnumerable<string> lines)
    {
        var outputPath = Path.Combine(basePath + "\\output");
        Directory.CreateDirectory(outputPath);

        var filepath = File.Create(Path.Combine(outputPath, filename));
        using var outputFile = new StreamWriter(filepath);
        foreach (var line in lines)
            outputFile.WriteLine(line);
    }
}