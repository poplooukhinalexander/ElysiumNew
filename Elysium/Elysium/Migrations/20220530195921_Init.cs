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
                name: "Language",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    HouseNumber = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
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
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DetailedDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: true),
                    RouteDifficultyDescription = table.Column<string>(type: "text", nullable: true),
                    DirectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    MeetPointId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    VisaMandatory = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    VisaDetails = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TransferDetails = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    MainPhotoLink = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    MainPhotoTitle = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Popularity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    FeedbackCount = table.Column<int>(type: "integer", nullable: false),
                    MinAge = table.Column<int>(type: "integer", nullable: true),
                    ParticipateTerms = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ArchivedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Locations_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Locations",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTour",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoutesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTour", x => new { x.CategoriesId, x.RoutesId });
                    table.ForeignKey(
                        name: "FK_CategoryTour_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTour_Tours_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageTour",
                columns: table => new
                {
                    LanguagesCode = table.Column<string>(type: "text", nullable: false),
                    ToursId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTour", x => new { x.LanguagesCode, x.ToursId });
                    table.ForeignKey(
                        name: "FK_LanguageTour_Language_LanguagesCode",
                        column: x => x.LanguagesCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageTour_Tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    EndedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TourId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrencyCode = table.Column<string>(type: "character varying(5)", nullable: false),
                    TicketNumber = table.Column<int>(type: "integer", nullable: false),
                    AvailableTicketNumber = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rides_Proviers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Proviers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rides_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DayNumber = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TourId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
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

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Link = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ScheduleItemId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_Photos_ScheduleItems_ScheduleItemId",
                        column: x => x.ScheduleItemId,
                        principalTable: "ScheduleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleItemId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_RoutePoint_ScheduleItems_ScheduleItemId",
                        column: x => x.ScheduleItemId,
                        principalTable: "ScheduleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "ara", "Arabic" },
                    { "deu", "German" },
                    { "eng", "English" },
                    { "fra", "French" },
                    { "ita", "Italian" },
                    { "jpn", "Japanese" },
                    { "rus", "Russian" },
                    { "spa", "Spanish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTour_RoutesId",
                table: "CategoryTour",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTour_ToursId",
                table: "LanguageTour",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Country_Region_City_Street_HouseNumber",
                table: "Locations",
                columns: new[] { "Country", "Region", "City", "Street", "HouseNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Longitude_Latitude",
                table: "Locations",
                columns: new[] { "Longitude", "Latitude" });

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
                name: "IX_Photos_ScheduleItemId",
                table: "Photos",
                column: "ScheduleItemId");

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
                name: "IX_Rides_AvailableTicketNumber",
                table: "Rides",
                column: "AvailableTicketNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CurrencyCode",
                table: "Rides",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CurrencyId",
                table: "Rides",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_Price_CurrencyId",
                table: "Rides",
                columns: new[] { "Price", "CurrencyId" });

            migrationBuilder.CreateIndex(
                name: "IX_Rides_ProviderId",
                table: "Rides",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_TourId",
                table: "Rides",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoint_LocationId",
                table: "RoutePoint",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoint_ScheduleItemId",
                table: "RoutePoint",
                column: "ScheduleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_DayNumber",
                table: "ScheduleItems",
                column: "DayNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_TourId",
                table: "ScheduleItems",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberTour_ToursId",
                table: "TeamMemberTour",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Difficulty",
                table: "Tours",
                column: "Difficulty");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_DirectionId",
                table: "Tours",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_IsActive",
                table: "Tours",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_MeetPointId",
                table: "Tours",
                column: "MeetPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Name",
                table: "Tours",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_Popularity",
                table: "Tours",
                column: "Popularity");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ProviderId",
                table: "Tours",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTour");

            migrationBuilder.DropTable(
                name: "LanguageTour");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Rides");

            migrationBuilder.DropTable(
                name: "RoutePoint");

            migrationBuilder.DropTable(
                name: "TeamMemberTour");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Proviers");
        }
    }
}
