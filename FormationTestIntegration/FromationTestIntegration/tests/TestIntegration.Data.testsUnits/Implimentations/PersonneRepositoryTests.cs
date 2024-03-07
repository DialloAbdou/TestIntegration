using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Data.Implementations;
using TestIntegration.Models;

namespace TestIntegration.Data.testsUnits.Implimentations
{
    public class PersonneRepositoryTests : IAsyncLifetime
    {

        private PersonneRepository GetRepo()
        {
            var repos =GetDbContext();
            
            return new PersonneRepository(repos);
        }
        private PersonneDbContext GetDbContext()
        {
            var dbcontext = new PersonneDbContext(
               new DbContextOptionsBuilder<PersonneDbContext>().UseSqlite("Filename=test.db").Options);
            return dbcontext;
        }

        [Fact]
        public async Task Add_Should_Write_In_Personne_In_Db()
        {
            var repo = GetRepo();
            await repo.AddPersonne(new Personne
            {
                Nom = "Diallo",
                Prenom = "Abdou",
                BirthDay = new DateTime(1980, 1, 5)
            });
            var context = GetDbContext();
            var persone = await context.Personnes.FirstOrDefaultAsync();

            persone.Should().NotBeNull();
        }

        public async Task InitializeAsync()
        {
            var context = GetDbContext();
            await context.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            var context = GetDbContext();
           await context.Database.EnsureDeletedAsync();

        }
    }
}
