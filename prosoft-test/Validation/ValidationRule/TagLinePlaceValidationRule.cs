using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public class TagLinePlaceValidationRule : IValidationRule
{
    public IValidationRule? Successor { get; set; }

    public void Validate(LogLine previous, LogLine current)
    {
        if (previous.Type != LineType.SeparatorLine && current.Type == LineType.TagLine)
            throw new InvalidLogFormatException("Tag line should be after separator line");
    }
}