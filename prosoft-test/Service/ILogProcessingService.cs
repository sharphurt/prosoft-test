namespace ProsoftTest.Service;

public interface ILogProcessingService
{
    public int ProcessedLinesCount { get; }
    public IEnumerable<string> ClearLog(IEnumerable<string> log);
}