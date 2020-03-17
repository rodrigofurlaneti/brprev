using Microsoft.EntityFrameworkCore;
using BRASILPREV.WebApplication.Models;
namespace BRASILPREV.WebApplication.Dal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}