using Microsoft.Extensions.Logging;

namespace ProsoftTest.Service;

public class LogCleanerService(
    IFileSystemService fileSystemService,
    ILogProcessingService logProcessingService,
    ILogger<LogCleanerService> logger)
{
    public void CleanInDirectory(string path)
    {
        var files = fileSystemService.GetFilesInPath(path).ToList();
        logger.LogInformation("Found {count} files in {path}", files.Count, path);
        foreach (var file in files)
        {
            var lines = File.ReadLines(file);
            logger.LogInformation("Process file [{file}]", Path.GetFileName(file));

            var processedLines = logProcessingService.ClearLog(lines);
            logger.LogInformation("File [{file}] finished, output lines count: {count}", Path.GetFileName(file), logProcessingService.ProcessedLinesCount);
            
            fileSystemService.WriteEnumerableToLog(file, processedLines);
        }
    }
}