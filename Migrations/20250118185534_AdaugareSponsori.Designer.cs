﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvenimenteSportive.Migrations
{
    [DbContext(typeof(EvenimenteContext))]
    [Migration("20250118185534_AdaugareSponsori")]
    partial class AdaugareSponsori
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EvenimenteSportive.Models.EvenimentSportiv", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDLocatie")
                        .HasColumnType("int");

                    b.Property<int>("LocatieID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LocatieID");

                    b.ToTable("EvenimenteSportive");
                });

            modelBuilder.Entity("EvenimenteSportive.Models.Locatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacitate")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locatii");
                });

            modelBuilder.Entity("Participant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Echipa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvenimentSportivID")
                        .HasColumnType("int");

                    b.Property<int>("IDEveniment")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Varsta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EvenimentSportivID");

                    b.ToTable("Participanti");
                });

            modelBuilder.Entity("Sponsor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Buget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DurataContract")
                        .HasColumnType("int");

                    b.Property<int>("EvenimentSportivID")
                        .HasColumnType("int");

                    b.Property<int>("IDEveniment")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EvenimentSportivID");

                    b.ToTable("Sponsori");
                });

            modelBuilder.Entity("EvenimenteSportive.Models.EvenimentSportiv", b =>
                {
                    b.HasOne("EvenimenteSportive.Models.Locatie", "Locatie")
                        .WithMany("EvenimenteSportive")
                        .HasForeignKey("LocatieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("Participant", b =>
                {
                    b.HasOne("EvenimenteSportive.Models.EvenimentSportiv", "EvenimentSportiv")
                        .WithMany("Participanti")
                        .HasForeignKey("EvenimentSportivID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvenimentSportiv");
                });

            modelBuilder.Entity("Sponsor", b =>
                {
                    b.HasOne("EvenimenteSportive.Models.EvenimentSportiv", "EvenimentSportiv")
                        .WithMany("Sponsori")
                        .HasForeignKey("EvenimentSportivID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvenimentSportiv");
                });

            modelBuilder.Entity("EvenimenteSportive.Models.EvenimentSportiv", b =>
                {
                    b.Navigation("Participanti");

                    b.Navigation("Sponsori");
                });

            modelBuilder.Entity("EvenimenteSportive.Models.Locatie", b =>
                {
                    b.Navigation("EvenimenteSportive");
                });
#pragma warning restore 612, 618
        }
    }
}
