using Microsoft.Extensions.Logging;

namespace ProsoftTest.Service.Impl;

public class LogCleanerService(
    IFileSystemService fileSystemService,
    ILogProcessingService logProcessingService,
    ILogger<LogCleanerService> logger) : ILogCleanerService
{
    public void CleanInDirectory(string basePath)
    {
        var baseFolder = AppDomain.CurrentDomain.BaseDirectory + basePath;
        var inputFolder = Path.Combine(baseFolder, "input");
        var outputFolder = Path.Combine(baseFolder, "output");


        if (!Directory.Exists(inputFolder))
            throw new ArgumentException($"Not found 'input' directory in path {basePath}");

        if (Directory.Exists(outputFolder))
            Directory.Delete(outputFolder, true);

        var files = fileSystemService.GetFilesInPath(baseFolder).ToList();
        logger.LogInformation("Found {count} files in {path}", files.Count, basePath);
        foreach (var file in files)
        {
            var filename = Path.GetRelativePath(Path.Combine(baseFolder, "input"), file);
            var lines = File.ReadLines(file);
            logger.LogInformation("Process file [{file}]", Path.GetFileName(file));

            var processedLines = logProcessingService.ClearLog(lines);
            logger.LogInformation("File [{file}] finished, output lines count: {count}", Path.GetFileName(file),
                logProcessingService.ProcessedLinesCount);

            fileSystemService.WriteEnumerableToLog(baseFolder, filename, processedLines);
        }
    }
}