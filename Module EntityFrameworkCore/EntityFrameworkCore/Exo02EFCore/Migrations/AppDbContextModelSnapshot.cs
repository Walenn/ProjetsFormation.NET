﻿// <auto-generated />
using System;
using Exo01EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exo02EFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exo02EFCore.Models.Chambre", b =>
                {
                    b.Property<int>("NumeroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("numero_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroId"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_id");

                    b.Property<int>("NombreLits")
                        .HasColumnType("int")
                        .HasColumnName("nombre_lits");

                    b.Property<int>("Statut")
                        .HasColumnType("int")
                        .HasColumnName("statut");

                    b.Property<decimal>("Tarif")
                        .HasPrecision(20, 2)
                        .HasColumnType("decimal(20,2)")
                        .HasColumnName("tarif");

                    b.HasKey("NumeroId");

                    b.HasIndex("HotelId");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_id");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nom");

                    b.Property<string>("NumeroTelephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("numero_telephone");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("prenom");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Nom = "Ratata",
                            NumeroTelephone = "01544884",
                            Prenom = "Max"
                        });
                });

            modelBuilder.Entity("Exo02EFCore.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("client_id");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotel_id");

                    b.Property<int>("Statut")
                        .HasColumnType("int")
                        .HasColumnName("statut");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("HotelId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Exo02EFCore.Models.ReservationChambre", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int")
                        .HasColumnName("reservation_id");

                    b.Property<int>("ChambreId")
                        .HasColumnType("int")
                        .HasColumnName("chambre_id");

                    b.HasKey("ReservationId", "ChambreId");

                    b.HasIndex("ChambreId");

                    b.ToTable("ReservationChambres");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Chambre", b =>
                {
                    b.HasOne("Exo02EFCore.Models.Hotel", "Hotel")
                        .WithMany("Chambres")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Client", b =>
                {
                    b.HasOne("Exo02EFCore.Models.Hotel", "Hotel")
                        .WithMany("Clients")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Reservation", b =>
                {
                    b.HasOne("Exo02EFCore.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exo02EFCore.Models.Hotel", "Hotel")
                        .WithMany("Reservations")
                        .HasForeignKey("HotelId");

                    b.Navigation("Client");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Exo02EFCore.Models.ReservationChambre", b =>
                {
                    b.HasOne("Exo02EFCore.Models.Chambre", "Chambre")
                        .WithMany("ReservationChambres")
                        .HasForeignKey("ChambreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Exo02EFCore.Models.Reservation", "Reservation")
                        .WithMany("ReservationChambres")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chambre");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Chambre", b =>
                {
                    b.Navigation("ReservationChambres");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Hotel", b =>
                {
                    b.Navigation("Chambres");

                    b.Navigation("Clients");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Exo02EFCore.Models.Reservation", b =>
                {
                    b.Navigation("ReservationChambres");
                });
#pragma warning restore 612, 618
        }
    }
}
