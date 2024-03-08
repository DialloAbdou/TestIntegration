using IntegrationDemo.Data.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Data.IntegrationTests.Implementations
{
    public class EFCorePeopleRepositoryTests : IAsyncLifetime,IClassFixture<DatabaseFixture>
    
    {
     
        private readonly DatabaseFixture _dbfixture;
        public EFCorePeopleRepositoryTests( DatabaseFixture dbfixture)
        {
            _dbfixture = dbfixture;
        }
        private  EFCorePeopleRepository GetRepo()
        {
     
            return new EFCorePeopleRepository(_dbfixture.CreateDbContext());
        }
  
              

        [Fact]
        public async Task Add_Should_Write_Person_In_Database()
        {

            var repo = GetRepo();

            await repo.Add(new()
            {
                Name = "Abdou",
                LastName = "Diallo",
                Birthday = new(1984, 5, 6)
            });

            var context = _dbfixture.CreateDbContext();
            var personne = await context.People.FirstOrDefaultAsync();
            personne.Should().NotBeNull();
            personne!.Name.Should().Be("Abdou");
            personne!.LastName.Should().Be("Diallo");


        }

        public async Task InitializeAsync()
        {
            var context = _dbfixture.CreateDbContext(); 
            await context.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            var context = _dbfixture.CreateDbContext();
            await context.Database.EnsureDeletedAsync();
        }
    }
}
