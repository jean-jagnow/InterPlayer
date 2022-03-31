using Microsoft.Extensions.DependencyInjection;

namespace InterPlayer.Application.Common.DependencyInjection;

public interface IApplicationPipeline
{
    public IServiceCollection Services { get; set; }
}