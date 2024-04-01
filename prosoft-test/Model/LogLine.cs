namespace ProsoftTest.Model;

public class LogLine(string rawLine, LineType type, LogImportance? logImportance = null)
{
    public string RawLine { get; } = rawLine;
    public LineType Type { get; } = type;

    public LogImportance? Importance { get; } = logImportance;
}