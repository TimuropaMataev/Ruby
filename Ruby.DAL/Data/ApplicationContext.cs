using Microsoft.EntityFrameworkCore;
using Ruby.DAL.Objects;

namespace Ruby.DAL.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=rubyusers.db");
    }
}