using IntegrationDemo.Data.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Data.IntegrationTests.Implementations
{
    public class EFCorePeopleRepositoryTests : 
        IAsyncLifetime,
        IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture db;
        private readonly IntegrationDbContext context;

        public EFCorePeopleRepositoryTests(
            DatabaseFixture db)
        {
            this.db = db;
            context = db.CreateDbContext();
        }

        private EFCorePeopleRepository GetRepo()
            => new EFCorePeopleRepository(context);        

        [Fact]
        public async Task Add_Should_Write_Person_In_Database()
        {
            var repo = GetRepo();

            await repo.Add(new()
            {
                Name = "Christophe",
                LastName = "MOMMER",
                Birthday = new(1988, 12, 18)
            });

            using var ctx = db.CreateDbContext();
            var person = await ctx.People.FirstOrDefaultAsync();
            person.Should().NotBeNull();
            person.Name.Should().Be("Christophe");
        }

        public async Task InitializeAsync()
        {
            await context.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await context.Database.EnsureDeletedAsync();
        }
    }
}
