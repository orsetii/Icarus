using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Veil.Services.Migrations
{
    /// <inheritdoc />
    public partial class WeatherFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "WeatherForecasts");

            migrationBuilder.RenameColumn(
                name: "TemperatureC",
                table: "WeatherForecasts",
                newName: "utc_offset_seconds");

            migrationBuilder.AddColumn<int>(
                name: "dailyId",
                table: "WeatherForecasts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "daily_unitsId",
                table: "WeatherForecasts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "elevation",
                table: "WeatherForecasts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "generationtime_ms",
                table: "WeatherForecasts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "hourlyId",
                table: "WeatherForecasts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hourly_unitsId",
                table: "WeatherForecasts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "latitude",
                table: "WeatherForecasts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitude",
                table: "WeatherForecasts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "timezone",
                table: "WeatherForecasts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "timezone_abbreviation",
                table: "WeatherForecasts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Daily",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apparenttemperaturemax = table.Column<List<double>>(name: "apparent_temperature_max", type: "double precision[]", nullable: false),
                    apparenttemperaturemin = table.Column<List<double>>(name: "apparent_temperature_min", type: "double precision[]", nullable: false),
                    et0faoevapotranspiration = table.Column<List<double>>(name: "et0_fao_evapotranspiration", type: "double precision[]", nullable: false),
                    precipitationhours = table.Column<List<double>>(name: "precipitation_hours", type: "double precision[]", nullable: false),
                    precipitationsum = table.Column<List<double>>(name: "precipitation_sum", type: "double precision[]", nullable: false),
                    rainsum = table.Column<List<double>>(name: "rain_sum", type: "double precision[]", nullable: false),
                    shortwaveradiationsum = table.Column<List<double>>(name: "shortwave_radiation_sum", type: "double precision[]", nullable: false),
                    showerssum = table.Column<List<double>>(name: "showers_sum", type: "double precision[]", nullable: false),
                    snowfallsum = table.Column<List<double>>(name: "snowfall_sum", type: "double precision[]", nullable: false),
                    sunrise = table.Column<List<string>>(type: "text[]", nullable: false),
                    sunset = table.Column<List<string>>(type: "text[]", nullable: false),
                    temperature2mmax = table.Column<List<double>>(name: "temperature_2m_max", type: "double precision[]", nullable: false),
                    temperature2mmin = table.Column<List<double>>(name: "temperature_2m_min", type: "double precision[]", nullable: false),
                    time = table.Column<List<string>>(type: "text[]", nullable: false),
                    weathercode = table.Column<List<int>>(type: "integer[]", nullable: false),
                    winddirection10mdominant = table.Column<List<int>>(name: "winddirection_10m_dominant", type: "integer[]", nullable: false),
                    windgusts10mmax = table.Column<List<double>>(name: "windgusts_10m_max", type: "double precision[]", nullable: false),
                    windspeed10mmax = table.Column<List<double>>(name: "windspeed_10m_max", type: "double precision[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apparenttemperaturemax = table.Column<string>(name: "apparent_temperature_max", type: "text", nullable: false),
                    apparenttemperaturemin = table.Column<string>(name: "apparent_temperature_min", type: "text", nullable: false),
                    et0faoevapotranspiration = table.Column<string>(name: "et0_fao_evapotranspiration", type: "text", nullable: false),
                    precipitationhours = table.Column<string>(name: "precipitation_hours", type: "text", nullable: false),
                    precipitationsum = table.Column<string>(name: "precipitation_sum", type: "text", nullable: false),
                    rainsum = table.Column<string>(name: "rain_sum", type: "text", nullable: false),
                    shortwaveradiationsum = table.Column<string>(name: "shortwave_radiation_sum", type: "text", nullable: false),
                    showerssum = table.Column<string>(name: "showers_sum", type: "text", nullable: false),
                    snowfallsum = table.Column<string>(name: "snowfall_sum", type: "text", nullable: false),
                    sunrise = table.Column<string>(type: "text", nullable: false),
                    sunset = table.Column<string>(type: "text", nullable: false),
                    temperature2mmax = table.Column<string>(name: "temperature_2m_max", type: "text", nullable: false),
                    temperature2mmin = table.Column<string>(name: "temperature_2m_min", type: "text", nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    weathercode = table.Column<string>(type: "text", nullable: false),
                    winddirection10mdominant = table.Column<string>(name: "winddirection_10m_dominant", type: "text", nullable: false),
                    windgusts10mmax = table.Column<string>(name: "windgusts_10m_max", type: "text", nullable: false),
                    windspeed10mmax = table.Column<string>(name: "windspeed_10m_max", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hourly",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apparenttemperature = table.Column<List<double>>(name: "apparent_temperature", type: "double precision[]", nullable: false),
                    cloudcover = table.Column<List<int>>(type: "integer[]", nullable: false),
                    dewpoint2m = table.Column<List<double>>(name: "dewpoint_2m", type: "double precision[]", nullable: false),
                    et0faoevapotranspiration = table.Column<List<double>>(name: "et0_fao_evapotranspiration", type: "double precision[]", nullable: false),
                    evapotranspiration = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    freezinglevelheight = table.Column<List<double>>(name: "freezinglevel_height", type: "double precision[]", nullable: false),
                    precipitation = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    rain = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    relativehumidity2m = table.Column<List<int>>(name: "relativehumidity_2m", type: "integer[]", nullable: false),
                    showers = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    snowdepth = table.Column<List<double>>(name: "snow_depth", type: "double precision[]", nullable: false),
                    snowfall = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    soilmoisture01cm = table.Column<List<double>>(name: "soil_moisture_0_1cm", type: "double precision[]", nullable: false),
                    soiltemperature0cm = table.Column<List<double>>(name: "soil_temperature_0cm", type: "double precision[]", nullable: false),
                    surfacepressure = table.Column<List<double>>(name: "surface_pressure", type: "double precision[]", nullable: false),
                    temperature2m = table.Column<List<double>>(name: "temperature_2m", type: "double precision[]", nullable: false),
                    time = table.Column<List<string>>(type: "text[]", nullable: false),
                    visibility = table.Column<List<double>>(type: "double precision[]", nullable: false),
                    weathercode = table.Column<List<int>>(type: "integer[]", nullable: false),
                    winddirection10m = table.Column<List<int>>(name: "winddirection_10m", type: "integer[]", nullable: false),
                    windgusts10m = table.Column<List<double>>(name: "windgusts_10m", type: "double precision[]", nullable: false),
                    windspeed10m = table.Column<List<double>>(name: "windspeed_10m", type: "double precision[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hourly", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlyUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    apparenttemperature = table.Column<string>(name: "apparent_temperature", type: "text", nullable: false),
                    cloudcover = table.Column<string>(type: "text", nullable: false),
                    dewpoint2m = table.Column<string>(name: "dewpoint_2m", type: "text", nullable: false),
                    et0faoevapotranspiration = table.Column<string>(name: "et0_fao_evapotranspiration", type: "text", nullable: false),
                    evapotranspiration = table.Column<string>(type: "text", nullable: false),
                    freezinglevelheight = table.Column<string>(name: "freezinglevel_height", type: "text", nullable: false),
                    precipitation = table.Column<string>(type: "text", nullable: false),
                    rain = table.Column<string>(type: "text", nullable: false),
                    relativehumidity2m = table.Column<string>(name: "relativehumidity_2m", type: "text", nullable: false),
                    showers = table.Column<string>(type: "text", nullable: false),
                    snowdepth = table.Column<string>(name: "snow_depth", type: "text", nullable: false),
                    snowfall = table.Column<string>(type: "text", nullable: false),
                    soilmoisture01cm = table.Column<string>(name: "soil_moisture_0_1cm", type: "text", nullable: false),
                    soiltemperature0cm = table.Column<string>(name: "soil_temperature_0cm", type: "text", nullable: false),
                    surfacepressure = table.Column<string>(name: "surface_pressure", type: "text", nullable: false),
                    temperature2m = table.Column<string>(name: "temperature_2m", type: "text", nullable: false),
                    time = table.Column<string>(type: "text", nullable: false),
                    visibility = table.Column<string>(type: "text", nullable: false),
                    weathercode = table.Column<string>(type: "text", nullable: false),
                    winddirection10m = table.Column<string>(name: "winddirection_10m", type: "text", nullable: false),
                    windgusts10m = table.Column<string>(name: "windgusts_10m", type: "text", nullable: false),
                    windspeed10m = table.Column<string>(name: "windspeed_10m", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyUnits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_daily_unitsId",
                table: "WeatherForecasts",
                column: "daily_unitsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_dailyId",
                table: "WeatherForecasts",
                column: "dailyId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_hourly_unitsId",
                table: "WeatherForecasts",
                column: "hourly_unitsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_hourlyId",
                table: "WeatherForecasts",
                column: "hourlyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_DailyUnits_daily_unitsId",
                table: "WeatherForecasts",
                column: "daily_unitsId",
                principalTable: "DailyUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Daily_dailyId",
                table: "WeatherForecasts",
                column: "dailyId",
                principalTable: "Daily",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_HourlyUnits_hourly_unitsId",
                table: "WeatherForecasts",
                column: "hourly_unitsId",
                principalTable: "HourlyUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherForecasts_Hourly_hourlyId",
                table: "WeatherForecasts",
                column: "hourlyId",
                principalTable: "Hourly",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_DailyUnits_daily_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Daily_dailyId",
                table: "WeatherForecasts");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_HourlyUnits_hourly_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropForeignKey(
                name: "FK_WeatherForecasts_Hourly_hourlyId",
                table: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "Daily");

            migrationBuilder.DropTable(
                name: "DailyUnits");

            migrationBuilder.DropTable(
                name: "Hourly");

            migrationBuilder.DropTable(
                name: "HourlyUnits");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_daily_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_dailyId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_hourly_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropIndex(
                name: "IX_WeatherForecasts_hourlyId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "dailyId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "daily_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "elevation",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "generationtime_ms",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "hourlyId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "hourly_unitsId",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "timezone",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "timezone_abbreviation",
                table: "WeatherForecasts");

            migrationBuilder.RenameColumn(
                name: "utc_offset_seconds",
                table: "WeatherForecasts",
                newName: "TemperatureC");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WeatherForecasts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "WeatherForecasts",
                type: "text",
                nullable: true);
        }
    }
}
