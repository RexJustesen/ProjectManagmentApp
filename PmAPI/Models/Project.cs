using PmAPI.DTO;

namespace PmAPI.Models
{
    public class Project
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
        public List<Link> Links { get; set; } = new();
        
    }
}