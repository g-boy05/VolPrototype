using ArtzaTechnologies.DAL.Domains;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ArtzaTechnologies.DAL.Contexts
{
    public static class SeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Avions par default pour test
            SeedAvions(modelBuilder);
            //Aeroports par defaut pour test
            SeedAeroports(modelBuilder);
        }

        #region Private

        private static void SeedAvions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avion>().HasData(
                new Avion
                {
                    Id = 1,
                    Libelle = "Avion 1",
                    Type = "Boeing 1",
                    ConsommationParKm = 5,
                    Vitesse = 450,
                    EffortDecollage = 10
                },
                new Avion
                {
                    Id = 2,
                    Libelle = "Avion 2",
                    Type = "Boeing 2",
                    ConsommationParKm = 9,
                    Vitesse = 300,
                    EffortDecollage = 7
                },
                new Avion
                {
                    Id = 3,
                    Libelle = "Avion 3",
                    Type = "Boeing 3",
                    ConsommationParKm = 3,
                    Vitesse = 420,
                    EffortDecollage = 13
                }
            );
        }

        private static void SeedAeroports(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aeroport>().HasData(
                new Aeroport()
                {
                    Id = 1,
                    Nom = "Mohammed 5",
                    Latitude = 33.5333,
                    Longtitude = -7.5833
                },
                new Aeroport()
                {
                    Id = 2,
                    Nom = "Charles de gualles",
                    Latitude = 49.009691,
                    Longtitude = 2.547925
                },
                new Aeroport()
                {
                    Id = 3,
                    Nom = "Orly",
                    Latitude = 48.75,
                    Longtitude = 2.4
                },
                new Aeroport()
                {
                    Id = 4,
                    Nom = "New york central park",
                    Latitude = 40.771133,
                    Longtitude = -73.974187
                }
            );
        }


        #endregion
    }
}
