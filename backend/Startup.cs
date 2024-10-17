using Microsoft.Extensions.DependencyInjection;

namespace backend;

[Amazon.Lambda.Annotations.LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICalculatorService>(new CalculatorService());
    }
}