using api_boberto_services;
using api_boberto_services.Models;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DockerClientManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//this is just a start point to Boberto Services API 
//https://docs.microsoft.com/pt-br/azure/architecture/patterns/cqrs

app.MapPost("/Docker/container/list", async ([FromServices] DockerClientManager dockerClientManager, [FromBody] ContainersListParameters request) =>
{
   return await dockerClientManager.GetContainerList(request);
})
.WithTags("Docker Actions");

app.MapPost("/Docker/container/create", async ([FromServices] DockerClientManager dockerClientManager, [FromBody] CreateContainerParameters request) =>
{
     await dockerClientManager.CreateContainer(request);
    return Results.Ok();
})
.WithTags("Docker Actions");

app.MapPost("/Docker/image/create", async ([FromServices] DockerClientManager dockerClientManager, [FromBody] CreateImageRequest request) =>
{
    await dockerClientManager.CreateImage(request);
    return Results.Ok();
})
.WithTags("Docker Actions");

app.Run();
