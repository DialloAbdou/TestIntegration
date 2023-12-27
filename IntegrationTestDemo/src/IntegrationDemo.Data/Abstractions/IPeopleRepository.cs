using IntegrationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationDemo.Data.Abstractions;

public interface IPeopleRepository
{
    Task Add(Person person);
    IAsyncEnumerable<Person> GetAll();
}
