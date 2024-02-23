namespace PmAPI.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public long SourceTicketId { get; set; }
        public long TargetTicketId { get; set; }
    }
}