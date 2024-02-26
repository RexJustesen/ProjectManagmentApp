using PmAPI.Models;

namespace PmAPI.DTO
{
    public class LinkDto
    {
         public int id { get; set; }
        public string? type { get; set; }
        public long source { get; set; }
        public long target { get; set; }
        public int projectId { get; set; }


        public static explicit operator LinkDto(Link link)
        {
            return new LinkDto
            {
                id = link.Id,
                type = link.Type,
                source = link.SourceTicketId,
                target = link.TargetTicketId,
                projectId = link.ProjectId
            };
        }

        public static explicit operator Link(LinkDto link)
        {
            return new Link
            {
                Id = link.id,
                Type = link.type,
                SourceTicketId = link.source,
                TargetTicketId = link.target,
                ProjectId = link.projectId

            };
        }
    }
}