using ProsoftTest.Model;

namespace ProsoftTest.Service;

public interface IFileSystemService
{
    public IEnumerable<string> GetFilesInPath(string path);
    public void WriteEnumerableToLog(string basePath, string filename, IEnumerable<string> lines);
}