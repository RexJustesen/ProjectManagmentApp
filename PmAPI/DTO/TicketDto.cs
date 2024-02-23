using System.Text.Encodings.Web;
using PmAPI.Models;

namespace PmAPI.DTO
{
    public class TicketDto
    {
        public long id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public int duration { get; set; }
        public decimal progress { get; set; }
        public int? parent { get; set; }
        public string? type { get; set; }
        public string? target { get; set; }
        public bool open
        {
            get { return true; }
            set { }
        }

        public static explicit operator TicketDto(Ticket ticket)
        {
            return new TicketDto
            {
                id = ticket.Id,
                text = HtmlEncoder.Default.Encode(ticket.Text),
                start_date = ticket.StartDate.ToString("yyyy-MM-dd HH:mm"),
                duration = ticket.Duration,
                parent = ticket.ParentId,
                type = ticket.Type,
                progress = ticket.Progress
            };
        }

        public static explicit operator Ticket(TicketDto ticket)
        {

            return new Ticket
            {
                Id = ticket.id,
                Text = ticket.text,
                StartDate = DateTime.Parse(ticket.start_date, System.Globalization.CultureInfo.InvariantCulture),
                Duration = ticket.duration,
                ParentId = ticket.parent,
                Type = ticket.type,
                Progress = ticket.progress
            };
        }
    }
}