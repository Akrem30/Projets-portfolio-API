using Microsoft.EntityFrameworkCore;
using PortfolioProjets.API.Models;

namespace PortfolioProjets.API.Data
{
    public class ProjetsContext : DbContext
    {
        public ProjetsContext(DbContextOptions<ProjetsContext> options) : base(options)
        {
        }

        public DbSet<Projet>? Projets { get; set; }
    }
}
