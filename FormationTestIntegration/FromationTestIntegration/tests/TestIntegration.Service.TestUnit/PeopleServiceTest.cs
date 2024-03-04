using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Data.Abstractions;
using TestIntegration.Service.Abstractions;

namespace TestIntegration.Service.TestUnit
{
    public class PeopleServiceTest
    {
        private Mock<IPersonneRepository> _personneRepositoryMock = new Mock<IPersonneRepository>();
        private Mock<ITextOutput> _textOutputMock = new Mock<ITextOutput>();

        public async Task PeopleService_Sholud_Use_PersonneIdentityFormater()
        {
        
        }

    }
}
