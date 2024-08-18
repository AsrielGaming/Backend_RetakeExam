public class CampingSpot
{
    public int Id { get; set; }
    public required string SpotName { get; set; }
    public int Size { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int UserId { get; set; }
    public int CampingGroundId { get; set; }
    public List<int> Amenities { get; set; } = new List<int>();
    public List<int> CampTypes { get; set; } = new List<int>();
}
