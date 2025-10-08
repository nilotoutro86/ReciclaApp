using Microsoft.EntityFrameworkCore;
using ReciclaBackend.Models;
// ... otros usings

namespace ReciclaBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        
       
        public ApplicationDbContext() { } 

        // 2. CONSTRUCTOR EXISTENTE (USADO POR LA APLICACIÓN WEB)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}