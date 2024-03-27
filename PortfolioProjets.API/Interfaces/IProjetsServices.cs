using PortfolioProjets.API.Models;

namespace PortfolioProjets.API.Interfaces
{
    public interface IProjetsServices
    {
        Task<Projet> AjouterProjet(Projet projet);
        Task<Projet> ModifierProjet(Projet projet);
        Task SupprimerProjet(Guid id);
        Task<IEnumerable<Projet>> ObtenirProjets();
        Task<Projet> ObtenirProjetSelonId(Guid id);
    }
}
