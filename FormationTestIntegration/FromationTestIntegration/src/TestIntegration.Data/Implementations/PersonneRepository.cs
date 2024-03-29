﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Data.Abstractions;
using TestIntegration.Models;

namespace TestIntegration.Data.Implementations
{
    public class PersonneRepository : IPersonneRepository
    {
        private PersonneDbContext _personneDbContext;
        public PersonneRepository( PersonneDbContext personneDbContext)
        {
             _personneDbContext = personneDbContext;
        }
        public async Task AddPersonne(Personne personne)
        {
              _personneDbContext.Personnes.Add(personne);
            await _personneDbContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Personne>> GetAllPersonnes()
        {
            return await _personneDbContext.Personnes.ToListAsync();
        }
    }
}
