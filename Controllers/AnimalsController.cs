using Microsoft.AspNetCore.Mvc;
using APBD5.Database;
using APBD5.Models;


namespace APBD5.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController: ControllerBase
{
    private readonly AniDb _aniDb;

    public AnimalsController(AniDb aniDb)
    {
        _aniDb = aniDb;
    }
    [HttpGet("/api/animals")]
    public IActionResult GetAnimals()
    {
        var animals = _aniDb.Animals;
        return Ok(animals);
    }

    [HttpGet("/api/animals/{id:int}")]
    public IActionResult GetAnomalsById(int id)
    {
        var animals= _aniDb.Animals.FirstOrDefault(a => a.id == id);
        return animals == null ? NotFound($"No animal with {id} found") : Ok();
    }
    
    //add an animal
    [HttpPost("/api/animals")]
    public IActionResult AddAnimal(Animal animal)
    {
        _aniDb.Animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("/api/animals/{id:int}")]
    public IActionResult editAnimal(int id, Animal animal)
    {
        var animalToEdit = _aniDb.Animals.FirstOrDefault(a => a.id == id);
        if (animalToEdit == null)
        {
            return (IActionResult)Results.NotFound($"No animal with id {id}");
        }
        _aniDb.Animals.Remove(animalToEdit);
        _aniDb.Animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("/api/animals/{id:int}")]
    public IActionResult deleteAnimal(int id)
    {
        var animalToDelete = _aniDb.Animals.FirstOrDefault(a => a.id == id);
        if (animalToDelete == null)
        {
            return (IActionResult)Results.NoContent();
        }
        _aniDb.Animals.Remove(animalToDelete);
        return NoContent();
    }
    
    [HttpGet("{id:int}/visits")]
    public IActionResult getVisits(int id)
    {
        var visitToAnimal = _aniDb.Visits.FirstOrDefault(a => a.id == id);
        return Ok(visitToAnimal);
    }
    
    [HttpPost("{id:int}/visits")]
    public IActionResult addVisit(Visit visit)
    {
        _aniDb.Visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);    
    }
}