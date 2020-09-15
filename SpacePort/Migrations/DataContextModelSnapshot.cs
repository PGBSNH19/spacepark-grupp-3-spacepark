﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpacePort.Models;

namespace SpacePort.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpacePort.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverId");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("SpacePort.Models.Parkinglot", b =>
                {
                    b.Property<int>("ParkinglotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParkinglotId");

                    b.ToTable("Parkinglot");

                    b.HasData(
                        new
                        {
                            ParkinglotId = 1,
                            Name = "Hoth"
                        },
                        new
                        {
                            ParkinglotId = 2,
                            Name = "Kamino"
                        },
                        new
                        {
                            ParkinglotId = 3,
                            Name = "Dagobah"
                        });
                });

            modelBuilder.Entity("SpacePort.Models.Parkingspot", b =>
                {
                    b.Property<int>("ParkingspotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("ParkinglotId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ParkingspotId");

                    b.HasIndex("ParkinglotId");

                    b.ToTable("Parkingspot");

                    b.HasData(
                        new
                        {
                            ParkingspotId = 1,
                            Occupied = false,
                            ParkinglotId = 1,
                            Size = 1
                        },
                        new
                        {
                            ParkingspotId = 2,
                            Occupied = false,
                            ParkinglotId = 1,
                            Size = 2
                        },
                        new
                        {
                            ParkingspotId = 3,
                            Occupied = false,
                            ParkinglotId = 1,
                            Size = 3
                        },
                        new
                        {
                            ParkingspotId = 4,
                            Occupied = false,
                            ParkinglotId = 2,
                            Size = 1
                        },
                        new
                        {
                            ParkingspotId = 5,
                            Occupied = false,
                            ParkinglotId = 2,
                            Size = 2
                        },
                        new
                        {
                            ParkingspotId = 6,
                            Occupied = false,
                            ParkinglotId = 2,
                            Size = 3
                        },
                        new
                        {
                            ParkingspotId = 7,
                            Occupied = false,
                            ParkinglotId = 3,
                            Size = 1
                        },
                        new
                        {
                            ParkingspotId = 8,
                            Occupied = false,
                            ParkinglotId = 3,
                            Size = 2
                        },
                        new
                        {
                            ParkingspotId = 9,
                            Occupied = false,
                            ParkinglotId = 3,
                            Size = 3
                        });
                });

            modelBuilder.Entity("SpacePort.Models.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParkingspotId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReceiptId");

                    b.HasIndex("DriverId");

                    b.HasIndex("ParkingspotId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("SpacePort.Models.Parkingspot", b =>
                {
                    b.HasOne("SpacePort.Models.Parkinglot", "Parkinglot")
                        .WithMany("Parkingspot")
                        .HasForeignKey("ParkinglotId");
                });

            modelBuilder.Entity("SpacePort.Models.Receipt", b =>
                {
                    b.HasOne("SpacePort.Models.Driver", null)
                        .WithMany("Receipts")
                        .HasForeignKey("DriverId");

                    b.HasOne("SpacePort.Models.Parkingspot", "Parkingspot")
                        .WithMany()
                        .HasForeignKey("ParkingspotId");
                });
#pragma warning restore 612, 618
        }
    }
}