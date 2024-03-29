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
    [Migration("20230812203545_Added SizeInBytes to Images table")]
    partial class AddedSizeInBytestoImagestable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CZTrails.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c79963a-414b-4211-8b17-80580786b447"),
                            Code = "STČ",
                            Name = "Středočeský kraj",
                            Spz = "S"
                        },
                        new
                        {
                            Id = new Guid("063f3cfb-f233-4422-bf9b-af3586f33c7e"),
                            Code = "PHA",
                            Name = "Hlavní město Praha",
                            Spz = "A"
                        },
                        new
                        {
                            Id = new Guid("13ec54c1-e829-4dda-93aa-f8bb014730f2"),
                            Code = "JHČ",
                            Name = "Jihočeský kraj",
                            Spz = "C"
                        },
                        new
                        {
                            Id = new Guid("41872f28-4c69-427e-b726-754e929f2b86"),
                            Code = "PLK",
                            Name = "Plzeňský kraj",
                            Spz = "P"
                        },
                        new
                        {
                            Id = new Guid("efc5a27a-e530-4d20-9f4b-448dac386eb6"),
                            Code = "KVK",
                            Name = "Karlovarský kraj",
                            Spz = "K"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("76f6f7e4-de7d-4a91-91e0-6c996f4a3bfc"),
                            Name = "Lehká"
                        },
                        new
                        {
                            Id = new Guid("f391738c-228e-45a0-938d-94f736cdbc96"),
                            Name = "Střední"
                        },
                        new
                        {
                            Id = new Guid("f7bc4218-d58c-4d81-be87-6d0635f85c00"),
                            Name = "Těžká"
                        });
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
