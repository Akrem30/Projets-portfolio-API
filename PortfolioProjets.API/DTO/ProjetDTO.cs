using System.ComponentModel.DataAnnotations;

namespace PortfolioProjets.API.DTO
{
    public class ProjetDTO
    {
        [Required]
        public string Titre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<string> Tags { get; set; }
    }
}
