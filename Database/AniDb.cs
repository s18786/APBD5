using APBD5.Models;

namespace APBD5.Database;

public class AniDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; } = new List<Visit>();

    public AniDb()
    {
        Animals.Add((new Animal{Id = 1, Name = "Lila", Category = "dog", Wheight = 10, FurColor = "brown"}));
        Animals.Add((new Animal{Id = 2, Name = "Masha", Category = "dog", Wheight = 7, FurColor = "white"}));
        Animals.Add((new Animal{Id = 3, Name = "Adolf", Category = "cat", Wheight = 8, FurColor = "white"}));
        Animals.Add((new Animal{Id = 4, Name = "Myszek", Category = "cat", Wheight = 15, FurColor = "black"}));
        Animals.Add((new Animal{Id = 5, Name = "Igor", Category = "dog", Wheight = 10, FurColor = "blue"}));

        Visits.Add((new Visit{IdVisit = 1, DateOfVisit = DateTime.Parse("2028-08-25 13:30:00") , Animal = "dog", VisitDescription = "visit", Price = 1000}));
        Visits.Add((new Visit{IdVisit = 1, DateOfVisit = DateTime.Parse("2025-04-27 11:55:00"), Animal = "cat", VisitDescription = "trip", Price = 500}));

    }
}