using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public interface IValidationRule
{
    private protected void Validate(LogLine current, LogLine previous);

    public void Call(LogLine current, LogLine previous)
    {
        Validate(current, previous);
    }
}