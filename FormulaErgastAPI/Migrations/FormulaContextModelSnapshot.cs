﻿// <auto-generated />
using FormulaErgastAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormulaErgastAPI.Migrations
{
    [DbContext(typeof(FormulaContext))]
    partial class FormulaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormulaErgastAPI.Models.CircuitErgast", b =>
                {
                    b.Property<int>("circuitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("circuitId"));

                    b.Property<string>("alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("circuitRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("circuitId");

                    b.ToTable("circuits");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.ConstructorResultsErgast", b =>
                {
                    b.Property<int>("constructorResultsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("constructorResultsId"));

                    b.Property<int>("constructorId")
                        .HasColumnType("int");

                    b.Property<string>("points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("constructorResultsId");

                    b.ToTable("constructorResults");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.ConstructorStandingsErgast", b =>
                {
                    b.Property<int>("constructorStandingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("constructorStandingsId"));

                    b.Property<int>("constructorId")
                        .HasColumnType("int");

                    b.Property<string>("points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("positionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceId")
                        .HasColumnType("int");

                    b.Property<int>("wins")
                        .HasColumnType("int");

                    b.HasKey("constructorStandingsId");

                    b.ToTable("constructorStandings");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.ConstructorsErgast", b =>
                {
                    b.Property<int>("constructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("constructorId"));

                    b.Property<string>("constructorRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("constructorId");

                    b.ToTable("constructors");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.DriverStandingsErgast", b =>
                {
                    b.Property<int>("driverStandingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("driverStandingsId"));

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<string>("points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("positionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceId")
                        .HasColumnType("int");

                    b.Property<int>("wins")
                        .HasColumnType("int");

                    b.HasKey("driverStandingsId");

                    b.ToTable("driverStandings");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.DriversErgast", b =>
                {
                    b.Property<int>("driverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("driverId"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("driverRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("forename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("driverId");

                    b.ToTable("drivers");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.LapTimesErgast", b =>
                {
                    b.Property<int>("raceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raceId"));

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<int>("lap")
                        .HasColumnType("int");

                    b.Property<int>("milliseconds")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("raceId");

                    b.ToTable("lapTimes");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.PitStopsErgast", b =>
                {
                    b.Property<int>("raceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raceId"));

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<string>("duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lap")
                        .HasColumnType("int");

                    b.Property<int>("milliseconds")
                        .HasColumnType("int");

                    b.Property<int>("stop")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("raceId");

                    b.ToTable("pitStops");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.RacesErgast", b =>
                {
                    b.Property<int>("raceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("raceId"));

                    b.Property<int>("circuitId")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp1_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp1_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp2_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp2_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp3_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fp3_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quali_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quali_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("round")
                        .HasColumnType("int");

                    b.Property<string>("sprint_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sprint_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("raceId");

                    b.ToTable("races");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.ResultsErgast", b =>
                {
                    b.Property<int>("resultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("resultId"));

                    b.Property<int>("constructorId")
                        .HasColumnType("int");

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<string>("fastestLap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fastestLapSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fastestLapTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("laps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("milliseconds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("positionOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("positionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceId")
                        .HasColumnType("int");

                    b.Property<string>("rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("resultId");

                    b.ToTable("results");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.SeasonsErgast", b =>
                {
                    b.Property<int>("year")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("year"));

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("year");

                    b.ToTable("seasons");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.SprintResultsErgast", b =>
                {
                    b.Property<int>("resultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("resultId"));

                    b.Property<int>("constructorId")
                        .HasColumnType("int");

                    b.Property<int>("driverId")
                        .HasColumnType("int");

                    b.Property<string>("fastestLap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fastestLapTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("grid")
                        .HasColumnType("int");

                    b.Property<int>("laps")
                        .HasColumnType("int");

                    b.Property<string>("milliseconds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("points")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("positionOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("positionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("raceId")
                        .HasColumnType("int");

                    b.Property<int>("statusId")
                        .HasColumnType("int");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("resultId");

                    b.ToTable("sprintResults");
                });

            modelBuilder.Entity("FormulaErgastAPI.Models.StatusErgast", b =>
                {
                    b.Property<int>("statusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("statusId"));

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("statusId");

                    b.ToTable("statuses");
                });
#pragma warning restore 612, 618
        }
    }
}
