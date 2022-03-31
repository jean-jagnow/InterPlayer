using Microsoft.Extensions.DependencyInjection;

namespace InterPlayer.Application.Common.DependencyInjection;

public class ApplicationPipeline : IApplicationPipeline
{
    public ApplicationPipeline(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; set; }
}