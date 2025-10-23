using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RotativoO9.Entities;

namespace RotativoO9.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<FilhoCadastro> FilhosCadastro { get; set; }

    }
}
