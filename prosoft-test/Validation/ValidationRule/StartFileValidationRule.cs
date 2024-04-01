using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation.ValidationRule;

public class StartFileValidationRule : IValidationRule
{
    void IValidationRule.Validate(LogLine current, LogLine previous)
    {
        if (previous is null && current.Type != LineType.TagLine)
            throw new InvalidLogFormatException("Log starts incorrectrly");
    }
}