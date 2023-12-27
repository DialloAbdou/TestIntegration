using IntegrationDemo.Data.Implementations;
using IntegrationDemo.Services;
using IntegrationDemo.Services.Implementations;

var service = new PeopleService(
    new FilePeopleRepository(),
    new PersonIdentityFormater(),
    new ConsoleTextOutput());

await service.CreatePerson("Christophe", "Mommer", new DateTime(1988, 12, 18));
await service.CreatePerson("Mégane", "Mommer", new DateTime(1988, 8, 7));

await service.SayHelloToAll();
