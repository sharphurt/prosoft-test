using ProsoftTest.Exception;
using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public class BodyLinePlaceValidationRule : IValidationRule
{
    public IValidationRule? Successor { get; set; }

    public void Validate(LogLine previous, LogLine current)
    {
        if (current.Type == LineType.BodyLine && previous.Type == LineType.SeparatorLine)
            throw new InvalidLogFormatException("Body line cannot be after separator line");
    }
}