using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestIntegration.Data.Implementations;

namespace TestIntegration.Data.testsUnits.Implimentations
{
    public class FileRepositoryTests : IDisposable
    {


        public FileRepositoryTests()
        {
            if(File.Exists("personne.csv"))
            {
                File.Delete("personne.csv");
            }
        }


        [Fact]
        public void  Ctor_Should_Create_File_Not_Existed()
        {
          
                File.Exists("personne.csv").Should().BeFalse();

                var repo = new FilePersonneRepository();

                File.Exists("personne.csv").Should().BeTrue();
          

        }




        [Fact]
        public async Task Add_Should_Weite_Personne_In_File_()
        {

                var repo = new FilePersonneRepository();
                await repo.AddPersonne(new Models.Personne
                {
                    Nom = "Diallo",
                    Prenom = "Abdou",
                    BirthDay = new DateTime(1980, 5, 6)

                });

            var list = await repo.GetAllPersonnes();

            list.Should().NotBeNull();
        }

        public void Dispose()
        {
            File.Delete("personne.csv");
        }
    }
}
