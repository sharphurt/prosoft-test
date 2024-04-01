using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public class StartFileValidationRule : IValidationRule
{
    public IValidationRule? Successor { get; set; }

    void IValidationRule.Validate(LogLine previous, LogLine current)
    {
        if (previous is null && current.Type != LineType.TagLine)
            throw new InvalidLogFormatException("Log starts incorrectrly");
    }
}