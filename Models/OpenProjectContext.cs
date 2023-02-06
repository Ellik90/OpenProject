using Microsoft.EntityFrameworkCore;
namespace OpenProject.Models;

public class OpenProjectContext : DbContext
{
     public OpenProjectContext(DbContextOptions<OpenProjectContext> options)
        : base(options)
    {
    }

    public DbSet<OpenProjectItem> OpenProjectItems { get; set; } = null!;
}