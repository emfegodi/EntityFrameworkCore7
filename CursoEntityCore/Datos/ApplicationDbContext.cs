using CursoEntityCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityCore.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones):base(opciones)
        {
            
        }

        //Escribir modelos
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<DetalleUsuario> DetalleUsuario { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticuloEtiqueta>().HasKey(ae => new {ae.Etiqueta_Id, ae.Articulo_Id });

            //Siembra de datos se hace en este método

            var categoria6 = new Categoria()
            {
                Categoria_Id = 33,
                Nombre = "Categoría 6",
                FechaCreacion = new DateTime(2023, 08, 30),
                Activo = true
            };
            var categoria7 = new Categoria()
            {
                Categoria_Id = 34,
                Nombre = "Categoría 7",
                FechaCreacion = new DateTime(2023, 08, 30),
                Activo = false
            };

            modelBuilder.Entity<Categoria>().HasData(new Categoria[]{ categoria6, categoria7});
            base.OnModelCreating(modelBuilder);

        }

        //Cuando crear mnigraciones (buenas prácticas)
        //1-Cuando se crea una nueva clase (tabla en la bd)
        //2-Cuando agregue una nueva propiedad (crear un campo nuevo en la bd)
        //3-Modifique un valor de campo en la clase (modificar campo en bd)



    }
}
