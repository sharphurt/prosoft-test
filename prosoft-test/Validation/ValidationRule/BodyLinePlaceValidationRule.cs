using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation.ValidationRule;

public class BodyLinePlaceValidationRule : IValidationRule
{
    public void Validate(LogLine current, LogLine previous)
    {
        if (current.Type == LineType.BodyLine && previous.Type == LineType.SeparatorLine)
            throw new InvalidLogFormatException("Body line cannot be after separator line");
    }
}