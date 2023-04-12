﻿// <auto-generated />
using CityInfo.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.Api.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20230407102504_CityInfoDbSeedingDatabse")]
    partial class CityInfoDbSeedingDatabse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("CityInfo.Api.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "City 1 description",
                            Name = "City 1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "City 2 description",
                            Name = "City 2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "City 3 description",
                            Name = "City 3"
                        });
                });

            modelBuilder.Entity("CityInfo.Api.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterest");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "PointOfInterest 1 description",
                            Name = "PointOfInterest 1"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "PointOfInterest 2 description",
                            Name = "PointOfInterest 2"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Description = "PointOfInterest 3 description",
                            Name = "PointOfInterest 3"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Description = "PointOfInterest 3 description",
                            Name = "PointOfInterest 3"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            Description = "PointOfInterest 3 description",
                            Name = "PointOfInterest 3"
                        });
                });

            modelBuilder.Entity("CityInfo.Api.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.Api.Entities.City", "City")
                        .WithMany("PointOfInterests")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.Api.Entities.City", b =>
                {
                    b.Navigation("PointOfInterests");
                });
#pragma warning restore 612, 618
        }
    }
}
