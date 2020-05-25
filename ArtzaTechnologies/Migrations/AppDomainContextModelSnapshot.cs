﻿// <auto-generated />
using System;
using ArtzaTechnologies.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArtzaTechnologies.Migrations
{
    [DbContext(typeof(AppDomainContext))]
    partial class AppDomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArtzaTechnologies.DAL.Domains.Aeroport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude");

                    b.Property<double>("Longtitude");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Aeroports");

                    b.HasData(
                        new { Id = 1, Latitude = 33.5333, Longtitude = -7.5833, Nom = "Mohammed 5" },
                        new { Id = 2, Latitude = 49.009691, Longtitude = 2.547925, Nom = "Charles de gualles" },
                        new { Id = 3, Latitude = 48.75, Longtitude = 2.4, Nom = "Orly" },
                        new { Id = 4, Latitude = 40.771133, Longtitude = -73.974187, Nom = "New york central park" }
                    );
                });

            modelBuilder.Entity("ArtzaTechnologies.DAL.Domains.Avion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsommationParKm");

                    b.Property<int>("EffortDecollage");

                    b.Property<string>("Libelle")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<float>("Vitesse");

                    b.HasKey("Id");

                    b.ToTable("Avions");

                    b.HasData(
                        new { Id = 1, ConsommationParKm = 5, EffortDecollage = 10, Libelle = "Avion 1", Type = "Boeing 1", Vitesse = 450f },
                        new { Id = 2, ConsommationParKm = 9, EffortDecollage = 7, Libelle = "Avion 2", Type = "Boeing 2", Vitesse = 300f },
                        new { Id = 3, ConsommationParKm = 3, EffortDecollage = 13, Libelle = "Avion 3", Type = "Boeing 3", Vitesse = 420f }
                    );
                });

            modelBuilder.Entity("ArtzaTechnologies.DAL.Domains.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("ArtzaTechnologies.DAL.Domains.Vol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AeroportArriveeId");

                    b.Property<int>("AeroportDepartId");

                    b.Property<int>("AvionId");

                    b.Property<DateTime>("DateArrivee");

                    b.Property<DateTime>("DateDepart");

                    b.HasKey("Id");

                    b.HasIndex("AeroportArriveeId");

                    b.HasIndex("AeroportDepartId");

                    b.HasIndex("AvionId");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("ArtzaTechnologies.DAL.Domains.Vol", b =>
                {
                    b.HasOne("ArtzaTechnologies.DAL.Domains.Aeroport", "AeroportArrivee")
                        .WithMany()
                        .HasForeignKey("AeroportArriveeId");

                    b.HasOne("ArtzaTechnologies.DAL.Domains.Aeroport", "AeroportDepart")
                        .WithMany()
                        .HasForeignKey("AeroportDepartId");

                    b.HasOne("ArtzaTechnologies.DAL.Domains.Avion", "Avion")
                        .WithMany("Vol")
                        .HasForeignKey("AvionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
