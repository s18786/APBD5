namespace APBD5.Models;

public class Visit : Animal
{
    public int IdVisit { get; set; }
    public DateTime DateOfVisit { get; set; }
    public string Animal { get; set; }
    public string VisitDescription { get; set; }
    public int Price { get; set; }

}