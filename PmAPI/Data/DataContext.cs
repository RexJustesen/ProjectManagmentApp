using Microsoft.EntityFrameworkCore;
using PmAPI.Models;

namespace PmAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships between entities
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tickets) // One project has many tickets
                .WithOne()               // Each ticket belongs to one project
                .HasForeignKey(t => t.ProjectId) // Foreign key to ProjectId in Ticket table
                .IsRequired();

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Links)   // One project has many links
                .WithOne()               // Each link belongs to one project
                .HasForeignKey(l => l.ProjectId) // Foreign key to ProjectId in Link table
                .IsRequired();
        }
    }
}
