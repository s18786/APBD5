using APBD5.Models;
using APBD5.Endpoint;
using APBD5.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<AniDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", () =>
{
    return Results.Ok();
});

app.MapPost("/animals-minimal/{id}", (Animal animal) =>
{
    Console.WriteLine(animal.Id);
    Console.WriteLine(animal.Name);

    return Results.Created();
});

app.MapAnimalsEndpoint();
app.MapControllers();
app.Run();
