using flappyBirdServeur.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace flappyBirdServeur.Data
{
    public class flappyBirdServeurContext : IdentityDbContext<Users>
    {
        public flappyBirdServeurContext(DbContextOptions<flappyBirdServeurContext> options)
            : base(options)
        {
        }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}