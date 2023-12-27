using IntegrationDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Data
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; } = default!;

        public IntegrationDbContext(
            DbContextOptions<IntegrationDbContext> options)
            : base(options)
        {

        }
    }
}
