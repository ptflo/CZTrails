﻿// <auto-generated />
using System;
using CZTrails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CZTrails.Migrations
{
    [DbContext(typeof(CZTrailsDbContext))]
    [Migration("20230720215201_Pridano SPZ pole do Region tabulky")]
    partial class PridanoSPZpoledoRegiontabulky
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CZTrails.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spz")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("CZTrails.Models.Domain.Trail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrailDifficultyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrailImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionID");

                    b.HasIndex("TrailDifficultyID");

                    b.ToTable("Trails");
                });

            modelBuilder.Entity("CZTrails.Models.Domain.TrailDifficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrailDifficulties");
                });

            modelBuilder.Entity("CZTrails.Models.Domain.Trail", b =>
                {
                    b.HasOne("CZTrails.Models.Domain.Region", "Region")
                        .WithMany("Trails")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CZTrails.Models.Domain.TrailDifficulty", "TrailDifficulty")
                        .WithMany()
                        .HasForeignKey("TrailDifficultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("TrailDifficulty");
                });

            modelBuilder.Entity("CZTrails.Models.Domain.Region", b =>
                {
                    b.Navigation("Trails");
                });
#pragma warning restore 612, 618
        }
    }
}