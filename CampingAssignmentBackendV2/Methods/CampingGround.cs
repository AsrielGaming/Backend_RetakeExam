public class CampingGround
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int AmountOfCampingSpots { get; set; }
    public required string Location { get; set; }
    public bool IsPetFriendly { get; set; }
}