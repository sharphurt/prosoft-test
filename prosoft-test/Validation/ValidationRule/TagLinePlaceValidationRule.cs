using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation.ValidationRule;

public class TagLinePlaceValidationRule : IValidationRule
{
    public void Validate(LogLine current, LogLine previous)
    {
        if (previous.Type != LineType.SeparatorLine && current.Type == LineType.TagLine)
            throw new InvalidLogFormatException("Tag line should be after separator line");
    }
}