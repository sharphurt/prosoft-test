using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProsoftTest.Constants;
using ProsoftTest.Exception;
using ProsoftTest.Model;
using ProsoftTest.Validation;

namespace ProsoftTest.Service.Impl;

public partial class LogProcessingService(IConfiguration configuration, ILogger<LogProcessingService> logger)
    : ILogProcessingService
{
    [GeneratedRegex(@"(\[.+\]) (\d{2}:\d{2}:\d{2}.\d{3}\+\d{2}:\d{2}$)", RegexOptions.Compiled)]
    private static partial Regex TagLineRegex();

    public int ProcessedLinesCount { get; private set; }

    public IEnumerable<string> ClearLog(IEnumerable<string> log)
    {
        var previousLine = new LogLine("file-start", LineType.SeparatorLine);
        var skippingProcess = false;
        ProcessedLinesCount = 0;

        foreach (var line in log)
        {
            var parsedLine = ParseLine(line);
            LogLineValidator.Validate(previousLine, parsedLine);

            previousLine = parsedLine;

            if (parsedLine.Type == LineType.TagLine)
                skippingProcess = ShouldSkipImportance(parsedLine.Importance!.Value);

            if (skippingProcess)
                continue;

            ProcessedLinesCount++;
            yield return parsedLine.RawLine;
        }
    }

    private bool ShouldSkipImportance(LogImportance importance)
    {
        var availableImportanceTags = configuration.GetSection("AvailableImportanceTags").AsEnumerable();
        return availableImportanceTags.All(e => e.Value != importance.ToString());
    }

    private LogLine ParseLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return new LogLine(line, LineType.SeparatorLine);

        if (!TagLineRegex().Match(line).Success)
            return new LogLine(line, LineType.BodyLine);

        var importance = ParseImportance(line);
        return new LogLine(line, LineType.TagLine, importance);
    }

    private LogImportance ParseImportance(string line)
    {
        var importanceString = TagLineRegex().Match(line).Groups[1].ToString();
        if (!ApplicationConstants.ImportanceAliases.TryGetValue(importanceString, out var importance))
            throw new InvalidLogFormatException("Unknown importance tag");

        return importance;
    }
}