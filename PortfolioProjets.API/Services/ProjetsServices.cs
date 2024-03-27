using PortfolioProjets.API.Interfaces;
using PortfolioProjets.API.Models;

namespace PortfolioProjets.API.Services
{
    public class ProjetsServices : IProjetsServices
    {
        private readonly IAsyncRepository<Projet> _projetRepository;
        public ProjetsServices(IAsyncRepository<Projet> projetRepository)
        {
            _projetRepository = projetRepository;
        }

        public async Task<Projet> AjouterProjet(Projet projet)
        {
          await _projetRepository.AddAsync(projet);
            return projet;
        }

        public async Task<Projet> ModifierProjet(Projet projet)
        {
            var projetAmodifier = await ObtenirProjetSelonId(projet.Id);
            projetAmodifier.Description = projet.Description;
            projetAmodifier.UrlCodeSource = projet.UrlCodeSource;
            projetAmodifier.UrlImage = projet.UrlImage;
            projet.Titre = projet.Titre;
            await _projetRepository.EditAsync(projetAmodifier);
            return projetAmodifier;
        }

        public async Task<IEnumerable<Projet>> ObtenirProjets()
        {
           return await _projetRepository.ListAsync();
        }

        public async Task<Projet> ObtenirProjetSelonId(Guid id)
        {
            return  await _projetRepository.GetByIdAsync(id);
        }

        public async Task SupprimerProjet(Guid id)
        {
            var projet =await ObtenirProjetSelonId(id);
            await _projetRepository.DeleteAsync(projet);
        }
    }
}
