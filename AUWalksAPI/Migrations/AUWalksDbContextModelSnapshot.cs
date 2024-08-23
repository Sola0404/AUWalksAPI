﻿// <auto-generated />
using System;
using AUWalksAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AUWalksAPI.Migrations
{
    [DbContext(typeof(AUWalksDbContext))]
    partial class AUWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AUWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("883d7b93-a0a1-48ef-bdba-e52f5ce4febe"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("cc5fbb9d-5277-4f21-a84f-18276f71e593"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("5cad5a8d-5696-4333-9ece-b998a1997934"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("AUWalksAPI.Models.Domain.Region", b =>
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

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9eb79079-fe2e-464d-a061-e391a9ca603b"),
                            Code = "CBR",
                            Name = "Canberra",
                            RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/canberra-and-surrounds/guide-to-canberra/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                        },
                        new
                        {
                            Id = new Guid("a8720e10-e420-450b-a636-2da229378f90"),
                            Code = "SYD",
                            Name = "Sydney",
                            RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/sydney-and-surrounds/guide-to-sydney/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                        },
                        new
                        {
                            Id = new Guid("f1b3b3b4-1b3b-4b3b-8b3b-3b3b3b3b3b3b"),
                            Code = "MEL",
                            Name = "Melbourne",
                            RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/melbourne-and-surrounds/guide-to-melbourne/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"),
                            Code = "BNE",
                            Name = "Brisbane",
                            RegionImageUrl = "https://www.australia.com/content/australia/en_ca/places/brisbane-and-surrounds/guide-to-brisbane/_jcr_content/hero/desktop.adapt.1920.high.jpg"
                        });
                });

            modelBuilder.Entity("AUWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("AUWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("AUWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
