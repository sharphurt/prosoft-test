using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProsoftTest.Service;
using ProsoftTest.Service.Impl;

namespace ProsoftTest;

public class Program
{
    public static void Main(string[] args)
    {
        new Program()
            .MainAsync(args)
            .GetAwaiter()
            .GetResult();
    }

    private static List<string> log =
    [
        "[INFO] 02:02:03.444+00:00",
        "string 1",
        "string 2",
        "string 4",
        "",
        "[ERROR] 02:02:03.444+00:00",
        "syfsd",
        "",
        "[DEBUG] 02:02:03.444+00:00",
        "DPSKDFPS",
        "DPSKDFPS",
        "",
        "[WARNING] 02:02:03.444+00:00",
        "fsolfjsd",
        "fsolfjsd"
    ];

    private async Task MainAsync(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, serviceCollection) => serviceCollection.AddSingleton<ILogProcessingService, LogProcessingService>())
            .ConfigureServices((_, serviceCollection) => serviceCollection.AddSingleton<IFileSystemService, FileSystemService>())
            .ConfigureServices((_, serviceCollection) => serviceCollection.AddSingleton<ILogCleanerService, LogCleanerService>())
            .ConfigureAppConfiguration(builder =>
            {
                builder.Sources.Clear();
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddCommandLine(args);
            })
            .Build();

        await host.StartAsync();

        var myService = host.Services.GetRequiredService<ILogCleanerService>();
        myService.CleanInDirectory("/test");

        await host.WaitForShutdownAsync();
    }
}