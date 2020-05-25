using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.DAL.Domains.Base;
using Microsoft.EntityFrameworkCore;

namespace ArtzaTechnologies.DAL.Contexts
{
    public class AppDomainContext:DbContext
    {
        public DbSet<Aeroport> Aeroports { get; set; }
        public DbSet<Avion> Avions { get; set; }
        public DbSet<Vol> Vols { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        /// <summary>
        /// Constructeur lié au context entity.
        /// </summary>
        /// <param name="options"> Les options du context.</param>
        public AppDomainContext(DbContextOptions<AppDomainContext> options)
            : base(options)
        { }

        /// <summary>
        /// Permet de récupérer le DbSet du type {T} souhaité.
        /// </summary>
        /// <typeparam name="T"> Le type du domain de bd.</typeparam>
        /// <returns> Un objet {DbSet<T>}.</returns>
        public DbSet<T> GetDbSetFor<T>() where T : DomainObject
        {
            if (typeof(T) == typeof(Aeroport))
            {
                return Aeroports as DbSet<T>;
            }
            else if (typeof(T) == typeof(Vol))
            {
                return Vols as DbSet<T>;
            }
            else if (typeof(T) == typeof(Avion))
            {
                return Avions as DbSet<T>;
            }
            else if (typeof(T) == typeof(Utilisateur))
            {
                return Utilisateurs as DbSet<T>;
            }
            return null;
        }

        /// <summary>
        /// Stratégie de mappage EF.
        /// </summary>
        /// <param name="modelBuilder"> l'objet parent : <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Vol>().HasKey(x => x.Id);
            modelBuilder.Entity<Vol>().HasOne(depart => depart.AeroportDepart).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Vol>().HasOne(arrivee => arrivee.AeroportArrivee).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Seed();
        }
    }
}
