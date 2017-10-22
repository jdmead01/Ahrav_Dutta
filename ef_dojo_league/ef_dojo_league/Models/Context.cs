using Microsoft.EntityFrameworkCore;
 
namespace ef_dojo_league.Models
{
    public class DojoLeagueContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DojoLeagueContext(DbContextOptions<DojoLeagueContext> options) : base(options) { }
        public DbSet<Ninja> Ninjas {get; set;}
        public DbSet<Dojo> Dojos {get; set;}
    }
}