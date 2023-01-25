﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Veil.Services.Database;

#nullable disable

namespace Veil.Services.Migrations
{
    [DbContext(typeof(VeilContext))]
    partial class VeilContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThirdPartyApis.Daily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<double>>("apparent_temperature_max")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("apparent_temperature_min")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("et0_fao_evapotranspiration")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("precipitation_hours")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("precipitation_sum")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("rain_sum")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("shortwave_radiation_sum")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("showers_sum")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("snowfall_sum")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<string>>("sunrise")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<string>>("sunset")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<double>>("temperature_2m_max")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("temperature_2m_min")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<string>>("time")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<int>>("weathercode")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<int>>("winddirection_10m_dominant")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<double>>("windgusts_10m_max")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("windspeed_10m_max")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.HasKey("Id");

                    b.ToTable("Daily");
                });

            modelBuilder.Entity("ThirdPartyApis.DailyUnits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("apparent_temperature_max")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("apparent_temperature_min")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("et0_fao_evapotranspiration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("precipitation_hours")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("precipitation_sum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rain_sum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("shortwave_radiation_sum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("showers_sum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("snowfall_sum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sunrise")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("sunset")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("temperature_2m_max")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("temperature_2m_min")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("weathercode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("winddirection_10m_dominant")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("windgusts_10m_max")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("windspeed_10m_max")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DailyUnits");
                });

            modelBuilder.Entity("ThirdPartyApis.ForecastResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("dailyId")
                        .HasColumnType("integer");

                    b.Property<int>("daily_unitsId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("dt_retreived")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("elevation")
                        .HasColumnType("double precision");

                    b.Property<double>("generationtime_ms")
                        .HasColumnType("double precision");

                    b.Property<int>("hourlyId")
                        .HasColumnType("integer");

                    b.Property<int>("hourly_unitsId")
                        .HasColumnType("integer");

                    b.Property<double>("latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("timezone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("timezone_abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("utc_offset_seconds")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("dailyId");

                    b.HasIndex("daily_unitsId");

                    b.HasIndex("hourlyId");

                    b.HasIndex("hourly_unitsId");

                    b.ToTable("WeatherForecasts");
                });

            modelBuilder.Entity("ThirdPartyApis.Hourly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<double>>("apparent_temperature")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<int>>("cloudcover")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<double>>("dewpoint_2m")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("et0_fao_evapotranspiration")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("evapotranspiration")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("freezinglevel_height")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("precipitation")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("rain")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<int>>("relativehumidity_2m")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<double>>("showers")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("snow_depth")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("snowfall")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("soil_moisture_0_1cm")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("soil_temperature_0cm")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("surface_pressure")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("temperature_2m")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<string>>("time")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<List<double>>("visibility")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<int>>("weathercode")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<int>>("winddirection_10m")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.Property<List<double>>("windgusts_10m")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.Property<List<double>>("windspeed_10m")
                        .IsRequired()
                        .HasColumnType("double precision[]");

                    b.HasKey("Id");

                    b.ToTable("Hourly");
                });

            modelBuilder.Entity("ThirdPartyApis.HourlyUnits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("apparent_temperature")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cloudcover")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dewpoint_2m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("et0_fao_evapotranspiration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("evapotranspiration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("freezinglevel_height")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("precipitation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("relativehumidity_2m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("showers")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("snow_depth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("snowfall")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("soil_moisture_0_1cm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("soil_temperature_0cm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("surface_pressure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("temperature_2m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("visibility")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("weathercode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("winddirection_10m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("windgusts_10m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("windspeed_10m")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HourlyUnits");
                });

            modelBuilder.Entity("Veil.Data.Geolocation.GeolocationCoordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Accuracy")
                        .HasColumnType("double precision");

                    b.Property<double?>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("AltitudeAccuracy")
                        .HasColumnType("double precision");

                    b.Property<double?>("Heading")
                        .HasColumnType("double precision");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<double?>("Speed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("GeolocationCoordinates");
                });

            modelBuilder.Entity("Veil.Data.Geolocation.GeolocationPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoordsId")
                        .HasColumnType("integer");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CoordsId");

                    b.ToTable("GeolocationPositions");
                });

            modelBuilder.Entity("Veil.Data.Stock.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StockLocationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StockLocationId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("Veil.Data.Stock.StockLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StockLocations");
                });

            modelBuilder.Entity("ThirdPartyApis.ForecastResult", b =>
                {
                    b.HasOne("ThirdPartyApis.Daily", "daily")
                        .WithMany()
                        .HasForeignKey("dailyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThirdPartyApis.DailyUnits", "daily_units")
                        .WithMany()
                        .HasForeignKey("daily_unitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThirdPartyApis.Hourly", "hourly")
                        .WithMany()
                        .HasForeignKey("hourlyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThirdPartyApis.HourlyUnits", "hourly_units")
                        .WithMany()
                        .HasForeignKey("hourly_unitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("daily");

                    b.Navigation("daily_units");

                    b.Navigation("hourly");

                    b.Navigation("hourly_units");
                });

            modelBuilder.Entity("Veil.Data.Geolocation.GeolocationPosition", b =>
                {
                    b.HasOne("Veil.Data.Geolocation.GeolocationCoordinates", "Coords")
                        .WithMany()
                        .HasForeignKey("CoordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coords");
                });

            modelBuilder.Entity("Veil.Data.Stock.StockItem", b =>
                {
                    b.HasOne("Veil.Data.Stock.StockLocation", "StockLocation")
                        .WithMany()
                        .HasForeignKey("StockLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
