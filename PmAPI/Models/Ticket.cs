using System.ComponentModel.DataAnnotations.Schema;

namespace PmAPI.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public string StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Progress { get; set; }
        public int? ParentId { get; set; }
        public string? Type { get; set; }

        public int ProjectId { get; set; }
    }
}