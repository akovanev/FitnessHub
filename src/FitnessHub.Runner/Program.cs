using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

ILogger<Program>? logger = null;

try
{
    var configuration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

    var services = new ServiceCollection()
        .AddLogging(configure =>
        {
            configure.AddDebug();
            configure.AddConsole();
        })
        .AddSingleton<IConfiguration>(configuration);

    var serviceProvider = services.BuildServiceProvider();

    logger = serviceProvider.GetRequiredService<ILogger<Program>>();

    logger.LogInformation("FitnessHub.Runner is executing");

    return 0;
}
catch (Exception exception)
{
    if (logger is not null)
    {
        logger.LogError(exception.Message);
        logger.LogError(exception.StackTrace);
    }
    else
    {
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception.StackTrace);
    }

    return 1;
}
finally
{
    await Task.Delay(TimeSpan.FromSeconds(1));
}