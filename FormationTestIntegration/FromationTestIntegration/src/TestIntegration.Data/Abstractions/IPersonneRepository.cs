using TestIntegration.Models;

namespace TestIntegration.Data.Abstractions
{
    public interface IPersonneRepository
    {
        Task AddPersonne(Personne personne);

        Task<IEnumerable<Personne>> GetAllPersonnes();
    }
}
