using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Data.Abstractions;
using TestIntegration.Models;
using TestIntegration.Service.Abstractions;
using TestIntegration.Service.Implementations;

namespace TestIntegration.Service.TestUnit
{
    public class PeopleServiceTest
    {
        private Mock<IPersonneRepository> _personneRepositoryMock = new Mock<IPersonneRepository>();
        private Mock<ITextOutput> _textOutputMock = new Mock<ITextOutput>();
        private Mock<IPersonneIdentityFormater> _identityFormaterMock = new Mock<IPersonneIdentityFormater>();

        [Fact]
        public async Task PeopleService_Sholud_Use_PersonneIdentityFormater()
        {
            var personne = new Personne { Nom = "DIALLO", Prenom = "Abdou" };
            _personneRepositoryMock.Setup(p => p.GetAllPersonnes())
                .ReturnsAsync(new List<Personne>() {personne});

              var formater = new PersonneIdentityFormater();
            _textOutputMock.Setup(t => t.getChaineOut($"Bonjour {formater.FormateIdentity(personne)}"))
                .Returns($"Bonjour {formater.FormateIdentity(personne)}");
             
            var service = new PeopleService( 
                _personneRepositoryMock.Object,
                     formater,
                _textOutputMock.Object

                );

            var result = await service.GetAllPersonnesByString();
            result.Should().NotBeNullOrEmpty();

          //  _textOutputMock.Verify(t => t.getChaineOut($"Bonjour {formater.FormateIdentity(personne)}"));
        }

    }
}
