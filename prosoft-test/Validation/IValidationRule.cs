using ProsoftTest.Model;

namespace ProsoftTest.Validation;

public interface IValidationRule
{
    public IValidationRule? Successor { get; set; }
    private protected void Validate(LogLine previous, LogLine current);

    public void Call(LogLine previous, LogLine current)
    {
        Validate(previous, current);
        Successor?.Call(previous, current);
    }
}