using IntegrationDemo.Models;
using IntegrationDemo.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Services.Implementations;

public class PersonIdentityFormater : IPersonIdentityFormater
{
    public string FormatIdentity(Person person)
         => $"{person.Name} {person.LastName}";
}
