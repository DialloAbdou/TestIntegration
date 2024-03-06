using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestIntegration.Data.Abstractions;
using TestIntegration.Models;
using static System.Environment;

namespace TestIntegration.Data.Implementations
{
    public class FilePersonneRepository : IPersonneRepository
    {
        public FilePersonneRepository() 
        {
            if (!File.Exists("personne.csv"))
            {
                File.WriteAllText($"personne.csv", $"Prenom; Nom;BirthDay {NewLine}");
            }
        }
        public async Task AddPersonne(Personne personne)
        {
            var listePeoples = await GetAllPersonnes();
            if(!listePeoples.All(p=>p.Prenom == personne.Prenom && p.Nom ==  personne.Nom))
            {
               await  File.AppendAllTextAsync($"personne.csv", $"{personne.Nom};{personne.Prenom};{personne!.BirthDay:dd/mm/yyyyy}{NewLine}");
            }
        }

        public async Task<IEnumerable<Personne>> GetAllPersonnes()
        {
            IEnumerable<Personne> listpersonne = new List<Personne>();
           
            foreach (var item in( await File.ReadAllLinesAsync("personne.csv")).Skip(1))
            {
                var data = item.Split(';');
                 listpersonne.Append( new Personne
                {
                    Nom = data[0],
                    Prenom = data[1],
                    BirthDay = DateTime.ParseExact(data[2], "dd/mm/yyyy", null)
                });
            }
            return listpersonne;
        }
    }
}
