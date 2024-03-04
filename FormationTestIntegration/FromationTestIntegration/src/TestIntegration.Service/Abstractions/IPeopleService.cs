using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Models;

namespace TestIntegration.Service.Abstractions
{
    public interface IPeopleService 
    {
        Task AddPersonne(Personne personne);
      
        Task<IEnumerable<String>> GetAllPersonnesByString();


    }
}
