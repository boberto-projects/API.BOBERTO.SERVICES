using API.BOBERTO.SERVICES.APPLICATION;
using API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config;
using API.BOBERTO.SERVICES.WEB.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations();
builder.AddIntegrations();
builder.AddServices();
builder.AddSwagger();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

if (app.Services.GetRequiredService<IOptions<ApiConfig>>().Value.Swagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("", () => "OK");
CQRS.Startup(app);

app.Run();
