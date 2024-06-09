using Domain.Todo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public abstract class AppDbContextBase<T>(DbContextOptions<T> options, ILoggerFactory loggerFactory) : DbContext(options)
    where T : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseLoggerFactory(loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly,
            t => t.Namespace is not null && t.Namespace.Contains("Common.Configurations"));

        modelBuilder.MapDbFunctions();
    }
}