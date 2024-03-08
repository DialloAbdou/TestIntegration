using IntegrationDemo.Data.Abstractions;
using IntegrationDemo.Models;
using IntegrationDemo.Services.Abstractions;
using IntegrationDemo.Services.Implementations;

namespace IntegrationDemo.Services.IntegrationTests;

public class PeopleServiceTests
{
    private Mock<IPeopleRepository> peopleRepoMock = new();
    private Mock<ITextOutput> textOutputMock = new();
    private Mock<IPersonIdentityFormater> identityFormaterMock = new();

    [Fact]
    public async Task PeopleService_Should_Use_PersonIdentityFormater()
    {
        peopleRepoMock.Setup(m => m.GetAll())
            .Returns(new[]
            {
                new Person{ Name = "Christophe", LastName = "Mommer"}
            }.ToAsyncEnumerable());

        var service = new PeopleService(
            peopleRepoMock.Object,
            new PersonIdentityFormater(),
            textOutputMock.Object
            );

        await service.SayHelloToAll();

        textOutputMock.Verify(m => m.WriteLine("Hello Christophe Mommer !"), Times.Once());
    }

    [Fact]
    public async Task PeopleService_Should_Write_To_Console()
    {
        peopleRepoMock.Setup(m => m.GetAll())
            .Returns(new[]
            {
                    new Person{ Name = "Christophe", LastName = "Mommer"}
            }.ToAsyncEnumerable());

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var service = new PeopleService(
            peopleRepoMock.Object,
            new PersonIdentityFormater(),
            new ConsoleTextOutput()
            );

        await service.SayHelloToAll();

        stringWriter.ToString().Should().StartWith("Hello Christophe Mommer !");
         }
    }