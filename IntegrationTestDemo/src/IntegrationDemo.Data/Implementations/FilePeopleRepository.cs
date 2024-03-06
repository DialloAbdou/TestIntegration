using IntegrationDemo.Data.Abstractions;
using IntegrationDemo.Models;
//using static System.Environment;

namespace IntegrationDemo.Data.Implementations;
public class FilePeopleRepository : IPeopleRepository
{
    public FilePeopleRepository()
    {
        if (!File.Exists("people.csv"))
        {
            File.WriteAllText("people.csv", $"name;lastname;birthdate{NewLine}");
        }
    }
    public async Task Add(Person person)
    {
        var allPeople = await GetAll().ToListAsync();
        if (!allPeople.Any(p => p.Name == person.Name && p.LastName == person.LastName))
        {
            await File.AppendAllTextAsync("people.csv", $"{person.Name};{person.LastName};{person.Birthday:dd/MM/yyyy}{NewLine}");
        }
    }

    public async IAsyncEnumerable<Person> GetAll()
    {
        foreach (var item in (await File.ReadAllLinesAsync("people.csv")).Skip(1))
        {
            var data = item.Split(';');
            yield return new Person
            {
                Name = data[0],
                LastName = data[1],
                Birthday = DateTime.ParseExact(data[2], "dd/MM/yyyy", null)
            };
        }
    }
}
