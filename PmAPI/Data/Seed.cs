using Microsoft.EntityFrameworkCore;
using PmAPI.Models;

namespace PmAPI.Data
{
    public class Seed
    {
        public static async Task SeedTickets(DataContext context)
        {

            Random rnd = new Random();
            if (await context.Projects.AnyAsync()) 
                return;

            // Parent Ticket (ParentId=null)
            var epic = new Project
            {
                Name = "Project 1",
                Id = rnd.Next()
            };
            context.Projects.Add(epic); 
            /*
            await context.SaveChangesAsync(); 
            var story1 = new Ticket
            {
                Text = "I want to develop tokenizer service",
                StartDate = DateTime.Today.AddDays(1),
                Duration = 4,
                Progress = 0.5m,
                ParentId = (int)epic.Id, 
                Type = "User Story"
            };
            context.Tickets.Add(story1);
            await context.SaveChangesAsync();

            var story2 = new Ticket
            {
                Text = "I have to implement tokinizer service",
                StartDate = DateTime.Today.AddDays(3),
                Duration = 5,
                Progress = 0.8m,
                ParentId = (int)epic.Id,
                Type = "User Story"
            };
            context.Tickets.Add(story2);
            await context.SaveChangesAsync();

            var epic2 = new Ticket
            {
                Text = "Create ELK stack",
                StartDate = DateTime.Today.AddDays(3),
                Duration = 3,
                Progress = 0.2m,
                ParentId = null,
                Type = "Epic"
            };
            context.Tickets.Add(epic2);
            await context.SaveChangesAsync();

            var story3 = new Ticket
            {
                Text = "We have to setup Elasticsearch",
                StartDate = DateTime.Today.AddDays(6),
                Duration = 6,
                Progress = 0.0m,
                ParentId = (int)epic2.Id,
                Type = "User Story"
            };
            context.Tickets.Add(story3);
            await context.SaveChangesAsync();

            var story4 = new Ticket
            {
                Text = "We have to implement Logstash to Microservices",
                StartDate = DateTime.Today.AddDays(6),
                Duration = 2,
                Progress = 0.3m,
                ParentId = (int)epic2.Id,
                Type = "User Story"
            };
            context.Tickets.Add(story4);
            await context.SaveChangesAsync();

            var story5 = new Ticket
            {
                Text = "We have to setup Kibana for Elasticsearch",
                StartDate = DateTime.Today.AddDays(6),
                Duration = 2,
                Progress = 0.0m,
                ParentId = (int)epic2.Id,
                Type = "User Story"
            };
            context.Tickets.Add(story5);
            await context.SaveChangesAsync();

            List<Link> TicketLinks = new List<Link>{
                new Link{SourceTicketId=epic.Id,TargetTicketId=story1.Id,Type="1"},
                new Link{SourceTicketId=epic.Id,TargetTicketId=story2.Id,Type="1"},
                new Link{SourceTicketId=epic2.Id,TargetTicketId=story3.Id,Type="1"},
                new Link{SourceTicketId=story3.Id,TargetTicketId=story4.Id,Type="1"},
                new Link{SourceTicketId=story4.Id,TargetTicketId=story5.Id,Type="1"},
                new Link{SourceTicketId=epic.Id,TargetTicketId=epic2.Id,Type="2"}
            };
            TicketLinks.ForEach(l => context.Links.Add(l)); */
            await context.SaveChangesAsync();
        }
    }
} 