using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options, ILoggerFactory loggerFactory)
    : AppDbContextBase<AppDbContext>(options, loggerFactory);