using InterPlayer.Application.Common.Behaviours;
using InterPlayer.Application.Common.DependencyInjection;
using InterPlayer.Core.Password;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InterPlayer.Application;

public static class DependencyInjection
{
    public static IApplicationPipeline AddApplicationCore(this IServiceCollection services)
    {
        services.AddScoped<IPasswordChecker, PasswordChecker>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        return new ApplicationPipeline(services);
    }

    public static void AddPassword(this IApplicationPipeline pipeline, Action<Options> options)
    {
        var _options = new Options();
        options.Invoke(_options);

        pipeline.Services.AddSingleton(_options);
    }
}