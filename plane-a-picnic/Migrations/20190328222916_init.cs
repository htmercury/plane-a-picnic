using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace planeapicnic.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Continent = table.Column<string>(nullable: false),
                    WikipediaLink = table.Column<string>(nullable: false),
                    Keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    LocalCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Continent = table.Column<string>(nullable: false),
                    IsoCountry = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    WikipediaLink = table.Column<string>(nullable: false),
                    Keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ident = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LatitudeDeg = table.Column<double>(nullable: false),
                    LongitudeDeg = table.Column<double>(nullable: false),
                    ElevationFt = table.Column<double>(nullable: false),
                    Continent = table.Column<string>(nullable: false),
                    IsoCountry = table.Column<string>(nullable: false),
                    IsoRegion = table.Column<string>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    Municipality = table.Column<string>(nullable: false),
                    ScheduledService = table.Column<bool>(nullable: false),
                    GpsCode = table.Column<string>(nullable: true),
                    IataCode = table.Column<string>(nullable: true),
                    LocalCode = table.Column<string>(nullable: true),
                    HomeLink = table.Column<string>(nullable: true),
                    WikipediaLink = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Airports_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runways",
                columns: table => new
                {
                    RunwayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportId = table.Column<int>(nullable: false),
                    LengthFt = table.Column<double>(nullable: false),
                    WidthFt = table.Column<double>(nullable: false),
                    Surface = table.Column<string>(nullable: false),
                    Lighted = table.Column<bool>(nullable: false),
                    Closed = table.Column<bool>(nullable: false),
                    LeIdent = table.Column<string>(nullable: false),
                    LeLatitudeDeg = table.Column<double>(nullable: true),
                    LeLongitudeDeg = table.Column<double>(nullable: true),
                    LeElevationFt = table.Column<double>(nullable: true),
                    LeHeadingDegT = table.Column<double>(nullable: true),
                    LeDisplacedThresholdFt = table.Column<double>(nullable: true),
                    HeIdent = table.Column<int>(nullable: false),
                    HeLatitudeDeg = table.Column<double>(nullable: true),
                    HeLongitudeDeg = table.Column<double>(nullable: true),
                    HeElevationFt = table.Column<double>(nullable: true),
                    HeHeadingDegT = table.Column<double>(nullable: true),
                    HeDisplacedThresholdFt = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runways", x => x.RunwayId);
                    table.ForeignKey(
                        name: "FK_Runways_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_RegionId",
                table: "Airports",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Runways_AirportId",
                table: "Runways",
                column: "AirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runways");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
