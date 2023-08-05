using CrudBaltaIo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudBaltaIo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
    }
}
