using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set;}

    public DbSet<CheckIn> Checkins {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string upperDirectory = baseDirectory.Replace("PassIn.API\\bin\\Debug\\net7.0", "");
        string dbPath = Path.Combine(upperDirectory, "PassInDb.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}