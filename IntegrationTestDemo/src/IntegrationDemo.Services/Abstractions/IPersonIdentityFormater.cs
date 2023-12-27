using IntegrationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Services.Abstractions;

public interface IPersonIdentityFormater
{
    string FormatIdentity(Person person);
}
