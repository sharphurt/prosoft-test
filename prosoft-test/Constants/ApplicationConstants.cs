using ProsoftTest.Model;

namespace ProsoftTest.Constants;

public static class ApplicationConstants
{
    public static readonly Dictionary<string, LogImportance> ImportanceAliases = new()
    {
        {"[ERROR]", LogImportance.Error},
        {"[WARNING]", LogImportance.Warning},
        {"[INFO]", LogImportance.Info},
        {"[DEBUG]", LogImportance.Debug},
    };
}