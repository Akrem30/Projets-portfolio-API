using PortfolioProjets.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortfolioProjets.API.Models
{
    public class Projet :BaseEntity
    {
        
        [Required,MaxLength(100,ErrorMessage ="Le titre ne doit pas dépasser 100 caractères")]
        public  string? Titre { get; set; }
        [Required,MaxLength(300,ErrorMessage ="La description ne doit pas dépasser 300 caractères")]
        public string? Description { get; set; }
        [Required,RegularExpression("^(https?|ftp)://[^\\s/$.?#].[^\\s]*$",ErrorMessage ="Entrez une url valide")]
        public string? UrlCodeSource {  get; set; }
        [Required, RegularExpression("^(https?|ftp)://[^\\s/$.?#].[^\\s]*$", ErrorMessage = "Entrez une url valide")]
        public string? UrlImage {  get; set; }
        [Required]
        public List<string>? Tags { get; set; } 
    }
}
