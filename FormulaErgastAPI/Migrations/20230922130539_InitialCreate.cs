using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaErgastAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "circuits",
                columns: table => new
                {
                    circuitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    circuitRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circuits", x => x.circuitId);
                });

            migrationBuilder.CreateTable(
                name: "constructorResults",
                columns: table => new
                {
                    constructorResultsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceId = table.Column<int>(type: "int", nullable: false),
                    constructorId = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constructorResults", x => x.constructorResultsId);
                });

            migrationBuilder.CreateTable(
                name: "constructors",
                columns: table => new
                {
                    constructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    constructorRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constructors", x => x.constructorId);
                });

            migrationBuilder.CreateTable(
                name: "constructorStandings",
                columns: table => new
                {
                    constructorStandingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceId = table.Column<int>(type: "int", nullable: false),
                    constructorId = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    positionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_constructorStandings", x => x.constructorStandingsId);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    driverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.driverId);
                });

            migrationBuilder.CreateTable(
                name: "driverStandings",
                columns: table => new
                {
                    driverStandingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    positionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverStandings", x => x.driverStandingsId);
                });

            migrationBuilder.CreateTable(
                name: "lapTimes",
                columns: table => new
                {
                    raceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    lap = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    milliseconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lapTimes", x => x.raceId);
                });

            migrationBuilder.CreateTable(
                name: "pitStops",
                columns: table => new
                {
                    raceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    stop = table.Column<int>(type: "int", nullable: false),
                    lap = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    milliseconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pitStops", x => x.raceId);
                });

            migrationBuilder.CreateTable(
                name: "races",
                columns: table => new
                {
                    raceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    round = table.Column<int>(type: "int", nullable: false),
                    circuitId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp1_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp1_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp2_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp2_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp3_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fp3_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quali_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quali_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sprint_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sprint_time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_races", x => x.raceId);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    resultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    constructorId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    laps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    milliseconds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fastestLap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fastestLapTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fastestLapSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.resultId);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    year = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.year);
                });

            migrationBuilder.CreateTable(
                name: "sprintResults",
                columns: table => new
                {
                    resultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    constructorId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grid = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positionOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    laps = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    milliseconds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fastestLap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fastestLapTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sprintResults", x => x.resultId);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    statusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.statusId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "circuits");

            migrationBuilder.DropTable(
                name: "constructorResults");

            migrationBuilder.DropTable(
                name: "constructors");

            migrationBuilder.DropTable(
                name: "constructorStandings");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "driverStandings");

            migrationBuilder.DropTable(
                name: "lapTimes");

            migrationBuilder.DropTable(
                name: "pitStops");

            migrationBuilder.DropTable(
                name: "races");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "sprintResults");

            migrationBuilder.DropTable(
                name: "statuses");
        }
    }
}
