using CommanderGQL.Common.Models;
using CommanderGQL.Infrastructure.Data.EF.Configs;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Infrastructure.Data.EF.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Command> Commands { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new AppDbContextConfiguration();
        
        modelBuilder.ApplyConfiguration<Platform>(configuration);
        modelBuilder.ApplyConfiguration<Command>(configuration);
    }
}