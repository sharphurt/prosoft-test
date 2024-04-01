using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation.ValidationRule;

public class SeparatorLinePlaceValidationRule : IValidationRule
{
    public void Validate(LogLine current, LogLine previous)
    {
        if (current.Type == LineType.SeparatorLine && previous.Type != LineType.BodyLine)
            throw new InvalidLogFormatException("Separator line should be after body line");
    }
}