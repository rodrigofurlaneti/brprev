using Microsoft.EntityFrameworkCore;
using BRASILPREV.Models;
namespace BRASILPREV.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}