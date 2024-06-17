using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace PmAPI.Models
{
    [Table("Comments")]
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public long TicketId { get; set; }
        public DateTime CreatedAt { get; set;}

        public Comments()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }

    
}