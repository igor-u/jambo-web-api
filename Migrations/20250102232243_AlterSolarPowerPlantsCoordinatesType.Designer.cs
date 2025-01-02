﻿// <auto-generated />
using System;
using Jambo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jambo.Migrations
{
    [DbContext(typeof(JamboDbContext))]
    [Migration("20250102232243_AlterSolarPowerPlantsCoordinatesType")]
    partial class AlterSolarPowerPlantsCoordinatesType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Jambo.Models.SolarInverter", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("PeakPower")
                        .HasColumnType("int");

                    b.Property<int>("RatedPower")
                        .HasColumnType("int");

                    b.Property<long?>("SolarPowerPlantId")
                        .HasColumnType("bigint");

                    b.HasKey("SerialNumber");

                    b.HasIndex("SolarPowerPlantId");

                    b.ToTable("SolarInverters");
                });

            modelBuilder.Entity("Jambo.Models.SolarPanel", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<long?>("SolarPowerPlantId")
                        .HasColumnType("bigint");

                    b.HasKey("SerialNumber");

                    b.HasIndex("SolarPowerPlantId");

                    b.ToTable("SolarPanels");
                });

            modelBuilder.Entity("Jambo.Models.SolarPowerPlant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("varchar(19)");

                    b.HasKey("Id");

                    b.ToTable("SolarPowerPlants");
                });

            modelBuilder.Entity("Jambo.Models.SolarInverter", b =>
                {
                    b.HasOne("Jambo.Models.SolarPowerPlant", null)
                        .WithMany("SolarInverters")
                        .HasForeignKey("SolarPowerPlantId");
                });

            modelBuilder.Entity("Jambo.Models.SolarPanel", b =>
                {
                    b.HasOne("Jambo.Models.SolarPowerPlant", null)
                        .WithMany("SolarPanels")
                        .HasForeignKey("SolarPowerPlantId");
                });

            modelBuilder.Entity("Jambo.Models.SolarPowerPlant", b =>
                {
                    b.Navigation("SolarInverters");

                    b.Navigation("SolarPanels");
                });
#pragma warning restore 612, 618
        }
    }
}
