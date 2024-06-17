using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PmAPI.DTO;

namespace PmAPI.Models
{
    [Table("Projects")]
    public class Project
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public List<Ticket> Tickets { get; set; } = new();
        public List<Link> Links { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public Project()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
    
}