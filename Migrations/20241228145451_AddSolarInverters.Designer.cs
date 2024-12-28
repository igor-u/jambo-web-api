﻿// <auto-generated />
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
    [Migration("20241228145451_AddSolarInverters")]
    partial class AddSolarInverters
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
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PeakPower")
                        .HasColumnType("int");

                    b.Property<int>("RatedPower")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.ToTable("SolarInverters");
                });

            modelBuilder.Entity("Jambo.Models.SolarPanel", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.ToTable("SolarPanels");
                });
#pragma warning restore 612, 618
        }
    }
}
