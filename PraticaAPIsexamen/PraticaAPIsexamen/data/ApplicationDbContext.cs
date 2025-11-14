using Microsoft.EntityFrameworkCore;
using PraticaAPIsexamen.models;

namespace PraticaAPIsexamen.data
{
    public class ApplicationDbContext : DbContext
    {
        // 1. El Constructor "mágico"
        // (Esto le permite a Visual Studio "inyectar" la conexión más tarde)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // 2. Las "Secciones" de nuestro archivo
        // (Le decimos a EF Core que queremos tablas para Usuarios y Roles)

        public DbSet <Producto> Producto { get; set; }
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet <Proveedor> proveedors { get; set; }
        
    }
}


