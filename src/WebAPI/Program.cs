using FluentValidation.AspNetCore;
using InterPlayer.Application;
using System.Globalization;
using WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddApplicationCore()
    .AddPassword(x =>
    {
        x.RequireDigit = true;
        x.RequireMinimunCharacters = 9;
        x.RequireUpperCase = true;
        x.RequireLowerCase = true;
        x.RequireSpecialCharacter = true;
        x.AllowRepeatedCharacters = false;
        x.SpecialCharacterPattern = "!@#$%^&*()-+";
    });

builder.Services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x =>
                {
                    x.AutomaticValidationEnabled = false;
                    x.DisableDataAnnotationsValidation = true;
                    x.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                    x.RegisterValidatorsFromAssemblyContaining(typeof(DependencyInjection));
                });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#endregion

#region Builder
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

#endregion