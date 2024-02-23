using Microsoft.EntityFrameworkCore;
using PmAPI.Models;

namespace PmAPI.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Link> Links { get; set; }
}