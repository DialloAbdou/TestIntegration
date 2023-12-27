using IntegrationDemo.Data.Implementations;

namespace IntegrationDemo.Data.IntegrationTests.Implementations
{
    public class FilePeopleRepositoryTests : IDisposable
    {
        public FilePeopleRepositoryTests()
        {
            if (File.Exists("people.csv"))
                File.Delete("people.csv");
        }

        [Fact]
        public void Ctor_Should_Create_File_If_Not_Exists()
        {
            File.Exists("people.csv").Should().BeFalse();

            var repo = new FilePeopleRepository();

            File.Exists("people.csv").Should().BeTrue();
        }

        [Fact]
        public async Task Add_Should_Write_Person_In_File()
        {
            var repo = new FilePeopleRepository();

            await repo.Add(new Models.Person
            {
                Name = "Christophe",
                LastName = "MOMMER",
                Birthday = new(1988, 12, 18)
            });

            var personLine = (await File.ReadAllLinesAsync("people.csv")).Skip(1).First();

            personLine.Should().NotBeNullOrWhiteSpace();
            personLine.Should().Contain("Christophe");
            personLine.Should().Contain("MOMMER");
        }

        public void Dispose()
        {
            try
            {
                File.Delete("people.csv");
            }
            catch { }
        }
    }
}