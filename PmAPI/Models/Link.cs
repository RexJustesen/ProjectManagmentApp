using System.ComponentModel.DataAnnotations.Schema;

namespace PmAPI.Models
{
    [Table("Links")]
    public class Link
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public long Source { get; set; }
        public long Target { get; set; }
        public int ProjectId { get; set; }


    }
}