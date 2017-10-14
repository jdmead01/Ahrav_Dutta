using Microsoft.EntityFrameworkCore;
namespace Restauranter.Models
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options) { }
        public DbSet<Reviews> Reviews {get; set;} 
    }
}