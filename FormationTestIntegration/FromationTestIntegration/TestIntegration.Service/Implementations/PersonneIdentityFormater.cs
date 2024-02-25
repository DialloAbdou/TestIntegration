using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Models;
using TestIntegration.Service.Abstractions;

namespace TestIntegration.Service.Implementations
{
    public class PersonneIdentityFormater : IPersonneIdentityFormater
    {
        public string FormateIdentity(Personne personne)
        {
            return $"{personne.Nom}, {personne.Prenom}";
        }
    }
}
