using APBD5.Database;
using APBD5.Models;

namespace APBD5.Endpoint;

public static class AnimalEndpoints
{
    public static void MapAnimalsEndpoint(this WebApplication app)
    {
        var aniDb = new AniDb().Animals;
        var aniDbVisits = new AniDb().Visits;

        app.MapGet("/api/animals", () => Results.Ok(aniDb))
            .WithName("GetAnimals")
            .WithOpenApi();

        app.MapGet("/animals-minimal/{id:int}", (int id) =>
            {
                var animal = aniDb.FirstOrDefault(s => s.Id == id);
                return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
            })
            .WithName("GetAnimal")
            .WithOpenApi();
        
        app.MapPost("/api/animals", (Animal animal) =>
            {
                aniDb.Add(animal);
                return Results.StatusCode(StatusCodes.Status201Created);
            })
            .WithName("CreateAnimal")
            .WithOpenApi();
        

        app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
            {
                var animalToEdit = aniDb.FirstOrDefault(s => s.Id == id);
                if (animalToEdit == null)
                {
                    return Results.NotFound($"Student with id {id} was not found");
                }
                aniDb.Remove(animalToEdit);
                aniDb.Add(animal);
                return Results.NoContent();
            })
            .WithName("UpdateAnimal")
            .WithOpenApi();
        
        app.MapDelete("/api/animals/{id:int}", (int id) =>
            {
                var animalToDelete = aniDb.FirstOrDefault(s => s.Id == id);
                if (animalToDelete == null)
                {
                    return Results.NoContent();
                }
                aniDb.Remove(animalToDelete);
                return Results.NoContent();
            })
            .WithName("DeleteAnimal")
            .WithOpenApi();
        
        app.MapGet("{id:int}/visits", (int id)=>
        {
            var visitToAnimal = aniDbVisits.FirstOrDefault(a => a.IdVisit == id);
            return Results.Ok(visitToAnimal);
        })
        .WithName("GetVisits")
        .WithOpenApi();
        
        app.MapPost("{id:int}/visits", (Visit visit) =>
        {
            aniDbVisits.Add(visit);
            return Results.StatusCode(StatusCodes.Status201Created);
        })
        .WithName("GetVisit")
        .WithOpenApi();
        
        app.Run();
    }
}