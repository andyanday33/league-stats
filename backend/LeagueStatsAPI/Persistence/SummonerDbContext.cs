using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SummonerDbContext: DbContext
{
    public SummonerDbContext(DbContextOptions<SummonerDbContext> options) : base(options)
    {
    }
    
    public DbSet<Summoner> Summoners { get; set; } = null!;
}