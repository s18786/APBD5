using APBD5.Database;
using APBD5.Models;

namespace APBD5.Endpoint;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoint(this WebApplication app)
    {
        var _AniDb = new AniDb().Animals;
        var _AniDbVisits = new AniDb().Visits;

        app.MapGet("/api/animals", () => Results.Ok(_AniDb))
            .WithName("GetAnimals")
            .WithOpenApi();

        app.MapGet("/animals-minimal/{id:int}", (int id) =>
            {
                var animal = _AniDb.FirstOrDefault(s => s.id == id);
                return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
            })
            .WithName("GetAnimal")
            .WithOpenApi();
        
        app.MapPost("/api/animals", (Animal animal) =>
            {
                _AniDb.Add(animal);
                return Results.StatusCode(StatusCodes.Status201Created);
            })
            .WithName("CreateAnimal")
            .WithOpenApi();
        

        app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
            {
                var animalToEdit = _AniDb.FirstOrDefault(s => s.id == id);
                if (animalToEdit == null)
                {
                    return Results.NotFound($"Student with id {id} was not found");
                }
                _AniDb.Remove(animalToEdit);
                _AniDb.Add(animal);
                return Results.NoContent();
            })
            .WithName("UpdateAnimal")
            .WithOpenApi();
        
        app.MapDelete("/api/animals/{id:int}", (int id) =>
            {
                var animalToDelete = _AniDb.FirstOrDefault(s => s.id == id);
                if (animalToDelete == null)
                {
                    return Results.NoContent();
                }
                _AniDb.Remove(animalToDelete);
                return Results.NoContent();
            })
            .WithName("DeleteAnimal")
            .WithOpenApi();
        
        app.MapGet("{id:int}/visits", (int id)=>
        {
            var visitToAnimal = _AniDbVisits.FirstOrDefault(a => a.id_visit == id);
            return Results.Ok(visitToAnimal);
        })
        .WithName("GetVisits")
        .WithOpenApi();
        
        app.MapPost("{id:int}/visits", (Visit visit) =>
        {
            _AniDbVisits.Add(visit);
            return Results.StatusCode(StatusCodes.Status201Created);
        })
        .WithName("GetVisit")
        .WithOpenApi();
        
        app.Run();
    }
}