using Microsoft.EntityFrameworkCore;
using TestIntegration.Models;

namespace TestIntegration.Data
{
    public class PersonneDbContext : DbContext
    {
        public DbSet<Personne>  Personnes { get; set; }

        public PersonneDbContext( DbContextOptions<PersonneDbContext> options)
            : base(options)
        {
            
        }
    }
}
