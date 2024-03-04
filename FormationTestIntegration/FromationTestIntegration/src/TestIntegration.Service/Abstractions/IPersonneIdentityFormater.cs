using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Models;

namespace TestIntegration.Service.Abstractions
{
    public interface IPersonneIdentityFormater
    {
        string FormateIdentity(Personne personne);
    }
}
