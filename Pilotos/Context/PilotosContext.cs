using Microsoft.EntityFrameworkCore;
using Pilotos.Models;

namespace Pilotos.Context
{
    public class PilotosContext : DbContext
    {
        public PilotosContext(DbContextOptions<PilotosContext>options): base(options) { }
        
        public DbSet<Piloto> pilotos { get; set; }
        public DbSet<Nacionalidad> nacionalidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nacionalidad>().HasData(
                new Nacionalidad { NacionalidadId = 1, Descripcion = "Argentino" },
                new Nacionalidad { NacionalidadId = 2, Descripcion = "Uruguayo" },
                new Nacionalidad { NacionalidadId = 3, Descripcion = "Chileno" });

            modelBuilder.Entity<Piloto>().HasData(
                new Piloto
                {
                    Id = 1,
                    Name = "Manu",
                    NacionalidadId = 1,
                    CantHorasVuelo = 123,
                    Email = "MANU@UNAM",
                    Password = "qweqweqwe"

                },
                new Piloto
                {
                    Id = 2,
                    Name = "Guille",
                    NacionalidadId = 3,
                    CantHorasVuelo = 111,
                    Email = "ggg@ggg",
                    Password = "123123"

                });
        }

    }
}
