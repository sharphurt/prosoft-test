using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public class SeparatorLinePlaceValidationRule : IValidationRule
{
    public IValidationRule? Successor { get; set; }

    public void Validate(LogLine previous, LogLine current)
    {
        if (current.Type == LineType.SeparatorLine && previous.Type != LineType.BodyLine)
            throw new InvalidLogFormatException("Separator line should be after body line");
    }
}