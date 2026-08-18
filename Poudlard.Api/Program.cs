using Scalar.AspNetCore;
using Poudlard.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<MaisonRepository>();
builder.Services.AddScoped<SorcierRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Pour ajouter Scalar
    //1. Ajouter le package Nuget
    //2. Ajouter using Scalar.AspNetCore au Program.cs
    //3. Ajouter app.MapScalarApiReference();
    //4. Changer l'url dans le fichier launchsettings.json
    app.MapScalarApiReference();

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
