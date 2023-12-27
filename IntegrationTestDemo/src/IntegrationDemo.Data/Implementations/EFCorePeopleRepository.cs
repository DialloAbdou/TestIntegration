using IntegrationDemo.Data.Abstractions;
using IntegrationDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Data.Implementations
{
    public class EFCorePeopleRepository : IPeopleRepository
    {
        private readonly IntegrationDbContext context;

        public EFCorePeopleRepository(
            IntegrationDbContext context)
        {
            this.context = context;
        }
        public async Task Add(Person person)
        {
            context.People.Add(person);
            await context.SaveChangesAsync();
        }

        public IAsyncEnumerable<Person> GetAll()
        {
            return context.People.AsAsyncEnumerable();
        }
    }
}
