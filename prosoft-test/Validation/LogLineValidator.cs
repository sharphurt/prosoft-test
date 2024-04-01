using ProsoftTest.Model;
using ProsoftTest.Validation.ValidationRule;

namespace ProsoftTest.Validation;

public static class LogLineValidator
{
    private static readonly List<IValidationRule> ValidationRules =
    [
        new StartFileValidationRule(),
        new BodyLinePlaceValidationRule(),
        new SeparatorLinePlaceValidationRule(),
        new TagLinePlaceValidationRule()
    ];

    public static void Validate(LogLine previous, LogLine current)
    {
        ValidationRules.ForEach(rule => rule.Call(current, previous));
    }
}