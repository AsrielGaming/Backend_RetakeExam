public class Comment
{
    public int Id { get; set; }
    public int CampingSpotId { get; set; }
    public int UserId { get; set; }
    public required string Text { get; set; }
}