using TestIntegration.Models;

namespace TestIntegration.Data.Abstractions
{
    public interface IPersonneRepository
    {
        Task AddPersonne(Personne personne);

        IAsyncEnumerable<Personne> GetAllPersonnes();
    }
}
