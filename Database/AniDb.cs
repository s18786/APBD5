using APBD5.Models;

namespace APBD5.Database;

public class AniDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; } = new List<Visit>();

    public AniDb()
    {
        Animals.Add((new Animal{id = 1, name = "Lila", category = "dog", wheight = 10, fur_color = "brown"}));
        Animals.Add((new Animal{id = 2, name = "Masha", category = "dog", wheight = 7, fur_color = "white"}));
        Animals.Add((new Animal{id = 3, name = "Adolf", category = "cat", wheight = 8, fur_color = "white"}));
        Animals.Add((new Animal{id = 4, name = "Myszek", category = "cat", wheight = 15, fur_color = "black"}));
        Animals.Add((new Animal{id = 5, name = "Igor", category = "dog", wheight = 10, fur_color = "blue"}));

        Visits.Add((new Visit{id_visit = 1, date_of_visit = DateTime.Parse("2028-08-25 13:30:00") , animal = "dog", visit_description = "visit", price = 1000}));
        Visits.Add((new Visit{id_visit = 1, date_of_visit = DateTime.Parse("2025-04-27 11:55:00"), animal = "cat", visit_description = "trip", price = 500}));

    }
}