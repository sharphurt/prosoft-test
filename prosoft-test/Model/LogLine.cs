namespace ProsoftTest.Model;

public class LogLineModel
{
    public string RawLine { get; }

    public LineType Type { get; }

    public LogImportance Importance { get; }
}