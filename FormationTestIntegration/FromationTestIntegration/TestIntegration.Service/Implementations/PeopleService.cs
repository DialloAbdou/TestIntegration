using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegration.Data.Abstractions;
using TestIntegration.Models;
using TestIntegration.Service.Abstractions;

namespace TestIntegration.Service.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly IPersonneRepository _personneRepository;
        private readonly IPersonneIdentityFormater _personneIdentityFormater;
        private readonly ITextOutput _textOutput;
        public PeopleService(
              IPersonneRepository personneRepository,
             IPersonneIdentityFormater personneIdentityFormater,
             ITextOutput textOutput
            )
        {
            _personneRepository = personneRepository;
            _personneIdentityFormater = personneIdentityFormater;
            _textOutput = textOutput;

        }
        public async Task AddPersonne(Personne personne)
        {
            await _personneRepository.AddPersonne(personne);
        }

        public async Task<IEnumerable<string>> GetAllPersonnesByString()
        {
            List<String> listString = new List<String>();
            await foreach (var personne in _personneRepository.GetAllPersonnes())
            {
               listString.Add( _textOutput.getChaineOut($" {_personneIdentityFormater.FormateIdentity(personne)}"));
            }
            return listString;
        }
    }
}
