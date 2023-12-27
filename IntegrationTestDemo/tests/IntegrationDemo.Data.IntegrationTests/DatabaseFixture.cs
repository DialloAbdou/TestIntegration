using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace IntegrationDemo.Data.IntegrationTests
{
    public class DatabaseFixture
    {

        public IntegrationDbContext CreateDbContext()
            => new IntegrationDbContext(
                new DbContextOptionsBuilder<IntegrationDbContext>()
                .UseSqlite("Filename=test.db").Options);
    }
}
