using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elysium.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Longitide = table.Column<double>(type: "double precision", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proviers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FBId = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    VKId = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    InstagramId = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proviers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhotoLink = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    Profession = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    VisaMandatory = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    VisaDetails = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ArchivedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    MainPhotoLink = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    MainPhotoTitle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Proviers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Proviers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRoute",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoutesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRoute", x => new { x.CategoriesId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_CategoryRoute_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRoute_Routes_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePoint_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutePoint_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    EndedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MeetPointId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyCode = table.Column<string>(type: "character varying(5)", nullable: false),
                    TicketNumber = table.Column<int>(type: "integer", nullable: false),
                    AvailableTicketNumber = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Locations_MeetPointId",
                        column: x => x.MeetPointId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tours_Proviers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Proviers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tours_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Link = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RoutePointId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_RoutePoint_RoutePointId",
                        column: x => x.RoutePointId,
                        principalTable: "RoutePoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMemberTour",
                columns: table => new
                {
                    TeamMembersId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToursId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMemberTour", x => new { x.TeamMembersId, x.ToursId });
                    table.ForeignKey(
                        name: "FK_TeamMemberTour_TeamMembers_TeamMembersId",
                        column: x => x.TeamMembersId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMemberTour_Tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRoute_RoutesId",
                table: "CategoryRoute",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Country_Region",
                table: "Locations",
                columns: new[] { "Country", "Region" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Longitide_Latitude",
                table: "Locations",
                columns: new[] { "Longitide", "Latitude" },
                filter: "NOT Longitude IS NULL AND NOT Latitude IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name_Region",
                table: "Locations",
                columns: new[] { "Name", "Region" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Region",
                table: "Locations",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Region_Name",
                table: "Locations",
                columns: new[] { "Region", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_LocationId",
                table: "Photos",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RoutePointId",
                table: "Photos",
                column: "RoutePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Proviers_Name",
                table: "Proviers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proviers_Rate",
                table: "Proviers",
                column: "Rate");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoint_LocationId",
                table: "RoutePoint",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoint_RouteId",
                table: "RoutePoint",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Difficulty",
                table: "Routes",
                column: "Difficulty");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_LocationId",
                table: "Routes",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Name",
                table: "Routes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ProviderId",
                table: "Routes",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Rate",
                table: "Routes",
                column: "Rate");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberTour_ToursId",
                table: "TeamMemberTour",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_AvailableTicketNumber",
                table: "Tours",
                column: "AvailableTicketNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CurrencyCode",
                table: "Tours",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_CurrencyId",
                table: "Tours",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_MeetPointId",
                table: "Tours",
                column: "MeetPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Price_CurrencyId",
                table: "Tours",
                columns: new[] { "Price", "CurrencyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ProviderId",
                table: "Tours",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_RouteId",
                table: "Tours",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRoute");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TeamMemberTour");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "RoutePoint");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Proviers");
        }
    }
}
