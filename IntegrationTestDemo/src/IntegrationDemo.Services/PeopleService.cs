using IntegrationDemo.Data.Abstractions;
using IntegrationDemo.Services.Abstractions;

namespace IntegrationDemo.Services;
public class PeopleService
{
    private readonly IPeopleRepository peopleRepository;
    private readonly IPersonIdentityFormater personIdentityFormater;
    private readonly ITextOutput textOutput;

    public PeopleService(
        IPeopleRepository peopleRepository,
        IPersonIdentityFormater personIdentityFormater,
        ITextOutput textOutput)
    {
        this.peopleRepository = peopleRepository;
        this.personIdentityFormater = personIdentityFormater;
        this.textOutput = textOutput;
    }

    public async Task CreatePerson(string name, string lastName, DateTime birthDay)
    {
        await peopleRepository.Add(new Models.Person
        {
            Name = name,
            LastName = lastName,
            Birthday = birthDay
        });
    }

    public async Task SayHelloToAll()
    {
        await foreach (var person in peopleRepository.GetAll())
        {
            textOutput.WriteLine(
                $"Hello {personIdentityFormater.FormatIdentity(person)} !"
                );
        }
    }
}
