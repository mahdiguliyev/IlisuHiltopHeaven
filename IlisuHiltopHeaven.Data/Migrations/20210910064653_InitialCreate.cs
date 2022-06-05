using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IlisuHiltopHeaven.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAnswerd = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhatsappUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advantage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advantage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvantageHiltop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageHiltop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvantageHiltop_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvantageOfPurchasings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageOfPurchasings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvantageOfPurchasings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageTwo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageThree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFour = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFive = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banners_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionsOfPurchasings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionsOfPurchasings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionsOfPurchasings_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomePageInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePageInformation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PageName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    floor1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    floor2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    floor3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Image3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousingProjects_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Number1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Number3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkDays = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkHours = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MainPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComlexLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageOne = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImageTwo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImageThree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImageFour = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImageFive = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImageSix = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageTwo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageThree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFour = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFive = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageSix = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellConditions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentageOwner = table.Column<int>(type: "int", nullable: false),
                    PercentageIHH = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitlesAndSubtitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subtitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subtitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subtitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesAndSubtitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitlesAndSubtitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageTwo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageThree = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFour = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageFive = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageSix = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAdvantages",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    AdvantageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAdvantages", x => new { x.ServiceId, x.AdvantageId });
                    table.ForeignKey(
                        name: "FK_ServiceAdvantages_Advantage_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "Advantage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceAdvantages_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHiltopAdvantages",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    AdvantageHiltopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHiltopAdvantages", x => new { x.ServiceId, x.AdvantageHiltopId });
                    table.ForeignKey(
                        name: "FK_ServiceHiltopAdvantages_AdvantageHiltop_AdvantageHiltopId",
                        column: x => x.AdvantageHiltopId,
                        principalTable: "AdvantageHiltop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceHiltopAdvantages_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageCode" },
                values: new object[,]
                {
                    { 1, "az" },
                    { 2, "eng" },
                    { 3, "rus" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "edd336ae-3627-4bf0-97df-546cfc0562ef", "Admin", "ADMIN" },
                    { 2, "26aca8f1-77c0-4227-a76f-d66dca3fc757", "Editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "FacebookUrl", "InstagramUrl", "PhoneNumber", "WhatsappUrl", "YoutubeUrl" },
                values: new object[] { 1, "https://www.facebook.com", "https://www.instagram.com", "+994 50 200 00 00", "https://wa.me/994502000000", "https://www.youtube.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, "Admin User of ProgrammersBlog", 0, "3381710a-77ee-4005-bdd5-61789c6b3553", "mahdiguliyev@gmail.com", true, "Mahdi", "Guliyev", false, null, "MAHDIGULIYEV@GMAIL.COM", "MAHDIGULIYEV", "AQAAAAEAACcQAAAAEPL25Z7lTFmfXD4Tv+aQlUMOAdXhiBDunJoD2X9YjvXkQ40u2bVuUWUtWepIVFqWww==", "+905555555555", true, "/userImages/defaultUser.png", "37ff3296-7c6b-4620-bbda-1ed4671d6659", false, "mahdiguliyev" },
                    { 2, "Editor User of ProgrammersBlog", 0, "ef5d9bd1-fd26-4739-a78a-8fca49163036", "guliyevsadiq@gmail.com", true, "Sadiq", "Guliyev", false, null, "GULIYEVSADIQ@GMAIL.COM", "GULIYEVSADIQ", "AQAAAAEAACcQAAAAEGQVc2L0Ui6KJ53uj91sqcPBClpt2/AGjWyIhSsgRLFAFwH2K3h/Vuec7emnRk7yOQ==", "+905555555555", true, "/userImages/defaultUser.png", "69c75f3b-ef0e-4101-bec4-7f8a41a66a56", false, "guliyevsadiq" }
                });

            migrationBuilder.InsertData(
                table: "Advantage",
                columns: new[] { "Id", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Sizin xalis gəliriniz" },
                    { 18, 3, "Прочие форс-мажорные расходы" },
                    { 15, 3, "Подоходный налог и налог на прибыль" },
                    { 12, 3, "Затраты на обслуживание" },
                    { 9, 3, "Коммунальные расходы" },
                    { 6, 3, "Расходы на управление" },
                    { 3, 3, "Ваш чистый доход" },
                    { 5, 2, "Management costs" },
                    { 8, 2, "Utility costs" },
                    { 2, 2, "Your net income" },
                    { 14, 2, "Income and profit tax" },
                    { 17, 2, "Other force majeure expenses" },
                    { 16, 1, "Sair forsmajor xərclər" },
                    { 13, 1, "Gəlir və mənfəət vergisi" },
                    { 10, 1, "Xidmət xərclər" },
                    { 7, 1, "Komunal xərclər" },
                    { 4, 1, "İdarəetmə xərcləri" },
                    { 11, 2, "Service costs" }
                });

            migrationBuilder.InsertData(
                table: "AdvantageHiltop",
                columns: new[] { "Id", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 3, 3, "Расходы на управление" },
                    { 8, 2, "Service costs" },
                    { 11, 2, "Income and profit tax" },
                    { 14, 2, "Other force majeure expenses" },
                    { 2, 2, "Management costs" },
                    { 6, 3, "Коммунальные расходы" },
                    { 12, 3, "Подоходный налог и налог на прибыль" },
                    { 1, 1, "İdarəetmə xərcləri" },
                    { 4, 1, "Komunal xərclər" },
                    { 7, 1, "Xidmət xərclər" },
                    { 10, 1, "Gəlir və mənfəət vergisi" },
                    { 13, 1, "Sair forsmajor xərclər" },
                    { 9, 3, "Затраты на обслуживание" },
                    { 5, 2, "Utility costs" },
                    { 15, 3, "Прочие форс-мажорные расходы" }
                });

            migrationBuilder.InsertData(
                table: "AdvantageOfPurchasings",
                columns: new[] { "Id", "Description1", "Description2", "Description3", "Image1", "Image2", "Image3", "LanguageGroupId", "LanguageId", "MainTitle", "Title1", "Title2", "Title3" },
                values: new object[,]
                {
                    { 1, "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.", "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.", "Siz öz biznes-mənzillerinizi icareye verərək stabil gəlir əldə edirsiniz. Sizin qazancınız sizdən və bizdən asılı olacaq. Nə qədər çox icarəyə versəz bir o qədər də gəliriniz çox olacaq.", "sprite.svg#icon-key", "sprite.svg#icon-profit", "sprite.svg#icon-money", new Guid("a1c87b2d-890d-4a31-a3cb-41b26776dd71"), 1, "Mənzilləri almaqla nə əldə edirik?", "Daşınmaz əmlak", "Əlavə gəlir", "Sərmayəmizi qorumaq" },
                    { 3, "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.", "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.", "Сдавая в аренду бизнес-апартаменты, вы получаете стабильный доход. Ваш заработок будет зависеть от вас и нас. Чем больше вы арендуете, тем больше у вас будет доход.", "sprite.svg#icon-key", "sprite.svg#icon-profit", "sprite.svg#icon-money", new Guid("a1c87b2d-890d-4a31-a3cb-41b26776dd71"), 3, "Что мы получаем, покупая квартиры?", "Недвижимость", "Дополнительный доход", "Защитите нашу столицу" },
                    { 2, "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.", "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.", "You get a steady income by renting out your business apartments. Your earnings will depend on you and us. The more you rent, the more income you will have.", "sprite.svg#icon-key", "sprite.svg#icon-profit", "sprite.svg#icon-money", new Guid("a1c87b2d-890d-4a31-a3cb-41b26776dd71"), 2, "What do we get by buying apartments?", "Real Estate", "Extra income", "Protect our capital" }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "Description", "ImageFive", "ImageFour", "ImageOne", "ImageThree", "ImageTwo", "LanguageGroupId", "LanguageId", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { 2, "We are the first in Azerbaijan to combine residential and non-residential to create a new business-housing model for you. We offer business apartments in 11 buildings built on 1 hectare of private land with a view of the Kumruk River and Ilisu gorge at the foot of the Caucasus Mountains.", "banner/bannerimage5.jpg", "banner/bannerimage4.jpg", "banner/bannerimage1.jpg", "banner/bannerimage3.jpg", "banner/bannerimage2.jpg", new Guid("0c08254b-2041-43de-8ee8-e41b1936dd0e"), 2, "Ilisu Hiltop Heaven", "video url" },
                    { 1, "Sizin üçün yeni iş mənzili yaratmaq üçün Azərbaycanda yaşayış və qeyri-yaşayış sahələrini birləşdirən ilk şəxs olduq. Qafqaz dağlarının ətəyində, Kumruk çayı və İlisu dərəsinə baxan 1 hektar özəl ərazidə inşa etdiyimiz 11 binada, ehtiyaclarınıza uyğun bir ərazidə iş mənzilləri təklif edirik.", "banner/bannerimage5.jpg", "banner/bannerimage4.jpg", "banner/bannerimage1.jpg", "banner/bannerimage3.jpg", "banner/bannerimage2.jpg", new Guid("0c08254b-2041-43de-8ee8-e41b1936dd0e"), 1, "İlisu Hiltop Heaven", "video url" },
                    { 3, "Мы первые в Азербайджане объединили жилое и нежилое, чтобы создать для вас новую модель бизнес-жилья. У подножия Кавказских гор, в 11 зданиях, которые мы построили на 1 гектаре частной земли с видом на реку Кумрук и ущелье Илису, мы предлагаем бизнес-апартаменты в районе, который соответствует вашим потребностям.", "banner/bannerimage5.jpg", "banner/bannerimage4.jpg", "banner/bannerimage1.jpg", "banner/bannerimage3.jpg", "banner/bannerimage2.jpg", new Guid("0c08254b-2041-43de-8ee8-e41b1936dd0e"), 3, "Илису Хилтоп Хевен", "video url" }
                });

            migrationBuilder.InsertData(
                table: "ConditionsOfPurchasings",
                columns: new[] { "Id", "Description1", "Description2", "Description3", "Image1", "Image2", "Image3", "LanguageGroupId", "LanguageId", "MainTitle", "Title1", "Title2", "Title3" },
                values: new object[,]
                {
                    { 2, "There may be a three-line sentence about selling with a full repayment loan here to make it look standard.", "There may be a three-line sentence about selling a mortgage loan here that looks standard.", "There may be a three-line sentence about selling with a short-term domestic loan here.", "sprite.svg#icon-payment", "sprite.svg#icon-bank", "sprite.svg#icon-loan", new Guid("45475a49-c5e9-40f7-86f7-00ef82d5725e"), 2, "How can we get apartments?", "Full sale", "Sale with a mortgage loan", "Sale on short-term domestic credit" },
                    { 1, "Tam ödəniş krediti ilə satışa dair üç sətirlik cümlə ola bilər burda ki, standart görünsün.", "İpoteka krediti ilə satışa dair üç sətirlik cümlə ola bilər burda ki, standars görünsün.", "Qısamüddətli daxili krediti ilə satışa dair üç sətirlik cümlə ola bilər burda.", "sprite.svg#icon-payment", "sprite.svg#icon-bank", "sprite.svg#icon-loan", new Guid("45475a49-c5e9-40f7-86f7-00ef82d5725e"), 1, "Biz mənzilləri necə əldə edə bilərik?", "Tam ödənişlə satış", "İpoteka krediti ilə satış", "Qısamüddətli daxili kreditlə satış" },
                    { 3, "Здесь может быть предложение из трех строк о продаже с полным погашением кредита, чтобы это выглядело стандартным.", "Здесь может быть предложение из трех строк о продаже ипотечного кредита, которое выглядит стандартным.", "Здесь может быть приговор о продаже с краткосрочным внутренним займом.", "sprite.svg#icon-payment", "sprite.svg#icon-bank", "sprite.svg#icon-loan", new Guid("45475a49-c5e9-40f7-86f7-00ef82d5725e"), 3, "Как мы можем получить квартиры?", "Полная продажа", "Продажа с ипотечной ссудой", "Продажа по краткосрочному внутреннему кредиту" }
                });

            migrationBuilder.InsertData(
                table: "HomePageInformation",
                columns: new[] { "Id", "Description", "Image", "LanguageGroupId", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 2, "By purchasing these apartments, you will be able to rent them to anyone with our help without any hassle and without wasting time on additional documentation. And those guests, like you, will use the services of the complex, reception, security, housing, sports complex located in the area, playground, indoor and outdoor pools, restaurants, beauty salons, shops, without leaving the complex.", "homepageinformation/homepageinf1.png", new Guid("b11f49b5-980c-4cb3-9102-fe27a24c8abf"), 2, "Stable income apartments" },
                    { 6, "Приобретая квартиру в этом комплексе, вы можете в любое время поехать в Азербайджан, Илису и провести интересный отдых в кругу друзей и знакомых. Если у вас есть собственный дом, зачем тратить лишние деньги в другом месте? Наши бизнес-апартаменты такие же прочные и экологичные, как и горы, в которых они расположены. Купив квартиру, вы можете как сэкономить, так и приумножить свой капитал. Для себя и своих детей.", "homepageinformation/homepageinf2.png", new Guid("c9d418ea-9fa1-4560-92e0-55925fcab11f"), 3, "Комплекс Hilltop Heaven: сочетание дома и бизнеса." },
                    { 9, "Согласно законодательству Азербайджана, лицо может быть владельцем деловой квартиры независимо от страны гражданства. Для этого вам будет предоставлена ​​выписка из государственного реестра о том, что вы являетесь собственником квартиры, сделав регистрацию у нотариуса или, соответственно, в сервисном центре Easy.", "homepageinformation/homepageinf3.png", new Guid("1974cb23-83c1-468a-a7eb-40ffe2b9fc78"), 3, "Условия приобретения имущественных прав на квартиры" },
                    { 3, "Купив эти апартаменты, вы сможете сдать их кому угодно с нашей помощью без лишних хлопот и тратя время на дополнительную документацию. А такие гости, как и вы, будут пользоваться услугами комплекса, ресепшн, охраны, жилья, спорткомплекса, расположенного на территории, детской площадки, закрытого и открытого бассейнов, ресторанов, салонов красоты, магазинов, не выходя из комплекса.", "homepageinformation/homepageinf1.png", new Guid("b11f49b5-980c-4cb3-9102-fe27a24c8abf"), 3, "Квартиры со стабильным доходом" },
                    { 5, "When you buy an apartment in this complex, you can travel to Azerbaijan, Ilisu at any time and have an interesting vacation with your friends and acquaintances. If you have your own house, why spend extra money elsewhere? Our business apartments are as solid and sustainable as the mountains in which they are located. You can both save and increase your capital by buying an apartment. To yourself and your children.", "homepageinformation/homepageinf2.png", new Guid("c9d418ea-9fa1-4560-92e0-55925fcab11f"), 2, "Hilltop Heaven complex: a combination of home and business." },
                    { 8, "According to the legislation of Azerbaijan, a person can be the owner of a business apartment, regardless of the country of citizenship. For this purpose, an extract from the state register will be submitted to you, stating that you are the owner of the apartment by making a registration at a notary or, accordingly, in the Easy service center.", "homepageinformation/homepageinf3.png", new Guid("1974cb23-83c1-468a-a7eb-40ffe2b9fc78"), 2, "Conditions for acquiring property rights to apartments" },
                    { 7, "Azərbaycan qanunvericiliyinə əsasən hansı ölkənin vətəndaşı olmağınnan asılı olmayaraq biznes-mənzilin mülkiyyetçisi ola biler. Bunun üçün ödeniş olunaraq notariusda ve ya muvaviq olaraq Asan xidmet merkezkerində resmileşdirmə apararaq menzilin mulkiyyetçisi olmağınlz barede dövlət reyestrindən çixarış təqdim olunacaq", "homepageinformation/homepageinf3.png", new Guid("1974cb23-83c1-468a-a7eb-40ffe2b9fc78"), 1, "Mənzillərə mülkiyyət hüququ əldə etmək şərtləri" },
                    { 4, "Siz bu kompleksden mənzil alaraq istediyiniz zaman Azerbaycana, ilisuya gelerek seyahet edib öz dostlariniz ve tanişlarinizla maraqli istirahet etmək imkani elde edirsiniz. Əgər öz eviniz varsa niye diğer yerlere elave vesait xercləməlisiniz? Bizim biznes-mənzillərimiz yerleşdiyi dağlar kimi möhkem, dayaniqli bir biznes temelidir. Siz mənzil almaqla öz sermayenizi hem saxlaya hem da artırıa bilərsiniz. Həm özünüzə, həm də övladlarınıza.", "homepageinformation/homepageinf2.png", new Guid("c9d418ea-9fa1-4560-92e0-55925fcab11f"), 1, "Hilltop Heaven kompleksi: ev və biznesin vəhdətidir." },
                    { 1, "Bu mənzilləri əldə ederek siz heç bir əziyyət və əlavə sənədləşməyə zaman itirməden bizim kömeyimizlə istədiyiniz şəxslərə icarəyə verə biləcəksiniz. Və həmin qonaqlar da Sizin kimi kompleksdəki servis və xidmətlərdən, resepşn, təhlükəsizlik, mənzillərə xidmət, ərazidə yerləşən idman kompleksindən, uşaq meydançasından, açıq və qapalı hovuzlardan, restoran, gözəllik salonlarindan, mağazadan, kompleksi tərk etmədən istifadə edəcəksiniz.", "homepageinformation/homepageinf1.png", new Guid("b11f49b5-980c-4cb3-9102-fe27a24c8abf"), 1, "Stabil qazanc gətirən mənzillər" }
                });

            migrationBuilder.InsertData(
                table: "HomePages",
                columns: new[] { "Id", "Description", "Image", "LanguageGroupId", "LanguageId", "PageName", "Title" },
                values: new object[,]
                {
                    { 12, "Если вам нужна дополнительная информация о бизнес-квартирах, мы с радостью ответим на все ваши вопросы. Вы можете связаться с офисом продаж по контактным телефонам.", "", new Guid("f4b68874-fbf0-4d5e-8754-3b6a4739eddd"), 3, "contact", "Связаться с нами" },
                    { 4, null, "homepageinf/projectpage.jpg", new Guid("842e30a3-ee1d-4e6e-9068-1ba66b071781"), 1, "project", "Layihə səhifəsi" },
                    { 1, null, "homepageinf/homepageimage.jpg", new Guid("c66e40f5-472d-4df6-9567-297a1fc11b5b"), 1, "homepage", "Huzurlu yaşam və sığortalı gəlir təminatı" },
                    { 2, null, "homepageinf/homepageimage.jpg", new Guid("c66e40f5-472d-4df6-9567-297a1fc11b5b"), 2, "homepage", "Secure living and insured income" },
                    { 5, null, "homepageinf/projectpage.jpg", new Guid("842e30a3-ee1d-4e6e-9068-1ba66b071781"), 2, "project", "Project page" },
                    { 8, "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land. The total area of the 3-storey residential building is 570 sq.m. meters. The total area of each of the non-residential buildings is 500 sq.m. meters.", "homepageinf/servicespage.jpg", new Guid("f4b61f73-c7cb-4a31-9aeb-786e773a0394"), 2, "services", "Services page" },
                    { 11, "If you need more information about business apartments, we are happy to answer all your questions. You can contact the sales office via contact numbers.", "", new Guid("f4b68874-fbf0-4d5e-8754-3b6a4739eddd"), 2, "contact", "Contact us" },
                    { 10, "Biznes-mənzillərlə bağlı daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq. Əlaqə nömrələri vasitəsiylə satış ofisiylə əlaqə saxlaya bilərsiniz.", "", new Guid("f4b68874-fbf0-4d5e-8754-3b6a4739eddd"), 1, "contact", "Bizimlə əlaqə" },
                    { 3, null, "homepageinf/homepageimage.jpg", new Guid("c66e40f5-472d-4df6-9567-297a1fc11b5b"), 3, "homepage", "Безопасная жизнь и застрахованный доход" },
                    { 7, "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur. 3 mərtəbəli yaşayış binasının ümumi sahəsi 570 kv. metrdir. Qeyri yaşayış binalarının hər birinin ümumi sahəsi 500 kv. metrdir", "homepageinf/servicespage.jpg", new Guid("f4b61f73-c7cb-4a31-9aeb-786e773a0394"), 1, "services", "Xidmətlər sahifəsi" },
                    { 9, "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома. Общая площадь 3-х этажного жилого дома 570 кв.м. метров. Общая площадь каждого нежилого дома составляет 500 кв.м. метров.", "homepageinf/servicespage.jpg", new Guid("f4b61f73-c7cb-4a31-9aeb-786e773a0394"), 3, "services", "Страница услуг" },
                    { 6, null, "homepageinf/projectpage.jpg", new Guid("842e30a3-ee1d-4e6e-9068-1ba66b071781"), 3, "project", "Страница проекта" }
                });

            migrationBuilder.InsertData(
                table: "HousingProjects",
                columns: new[] { "Id", "Description", "Image1", "Image2", "Image3", "LanguageGroupId", "LanguageId", "MainTitle", "floor1", "floor2", "floor3" },
                values: new object[,]
                {
                    { 3, "Здесь должен быть краткий текст о плане проекта. это условные тексты, которые позволяют управлять, контролировать и сдавать в аренду свой бизнес, не заходя в комплекс. Вы также можете использовать апартаменты для личного отдыха и проживания.", "housingproject/project1.jpg", "housingproject/project2.jpg", "housingproject/project3.jpg", new Guid("382b9a82-6872-49db-8243-67ca61aad9ba"), 3, "Жилищный проект", "1-й этаж", "2-й этаж", "3-й этаж" },
                    { 2, "There should be a short text about the project plan here. these are conditional texts that allow you to manage, control and lease your business without having to come to the complex. You can also use the apartments for your personal recreation and living.", "housingproject/project1.jpg", "housingproject/project2.jpg", "housingproject/project3.jpg", new Guid("382b9a82-6872-49db-8243-67ca61aad9ba"), 2, "Housing project", "1st floor", "2nd floor", "3rd floor" },
                    { 1, "Layihenin planı haqqında qısa mətn olmalıdır burda. bunlar şərti mətndir, sizə kompleksə gəlmədən öz biznesinizi idarə etmə, nəzarətdə saxlama və icarəyə verə bilmə imkanı yaradır. Mənzilləri öz şəxsi istirahətiniz və yaşayışınız üçün də istifadə edə bilərsiniz.", "housingproject/project1.jpg", "housingproject/project2.jpg", "housingproject/project3.jpg", new Guid("382b9a82-6872-49db-8243-67ca61aad9ba"), 1, "Mənzillərin layihəsi", "1-ci mərtəbə", "2-ci mərtəbə", "3-ci mərtəbə" }
                });

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "Id", "Address", "Email", "IsMain", "LanguageGroupId", "LanguageId", "MapUrl", "Number1", "Number2", "Number3", "OfficeName", "WorkDays", "WorkHours" },
                values: new object[,]
                {
                    { 4, "2054, Filan küçə, Səbayıl rayonu, Bakı şəhəri, Azərbaycan", "info@asrz.com.ua", false, new Guid("5be32188-d2ae-4ef3-a36c-4a7aa92ff694"), 1, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Qax ofisi", "Bazar ertəsi - Şənbə", "09:00 - 19:00" },
                    { 6, "2054, улица Филана, Сабаильский район, город Баку, Азербайджан", "info@asrz.com.ua", false, new Guid("5be32188-d2ae-4ef3-a36c-4a7aa92ff694"), 3, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Офис Qax", "Понедельник - Суббота", "09:00 - 19:00" },
                    { 3, "2054, улица Филана, Сабаильский район, город Баку, Азербайджан", "info@asrz.com.ua", true, new Guid("ce5d4fc0-946b-4cdc-b0bc-86ce5360f7b5"), 3, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Сабаильский офис", "Понедельник - Суббота", "09:00 - 19:00" },
                    { 2, "2054, Filan street, Sabail district, Baku city, Azerbaijan", "info@asrz.com.ua", true, new Guid("ce5d4fc0-946b-4cdc-b0bc-86ce5360f7b5"), 2, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Sabail office", "Monday - Saturday", "09:00 - 19:00" },
                    { 1, "2054, Filan küçə, Səbayıl rayonu, Bakı şəhəri, Azərbaycan", "info@asrz.com.ua", true, new Guid("ce5d4fc0-946b-4cdc-b0bc-86ce5360f7b5"), 1, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Səbayıl ofisi", "Bazar ertəsi - Şənbə", "09:00 - 19:00" },
                    { 5, "2054, Filan street, Sabail district, Baku city, Azerbaijan", "info@asrz.com.ua", false, new Guid("5be32188-d2ae-4ef3-a36c-4a7aa92ff694"), 2, "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "+380 (629) 53 01 91", null, null, "Qax office", "Monday - Saturday", "09:00 - 19:00" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "BuildingProject", "ComlexLoc", "ImageFive", "ImageFour", "ImageOne", "ImageSix", "ImageThree", "ImageTwo", "LanguageGroupId", "LanguageId", "MainImageFive", "MainImageFour", "MainImageOne", "MainImageSix", "MainImageThree", "MainImageTwo", "MainPlan", "MapUrl", "Title1", "Title2" },
                values: new object[,]
                {
                    { 3, "Прежде всего, мы можем определить и продать жилую площадь в Азербайджане исходя из финансового положения покупателя. 28 кв. М. 190 квадратных метров. Вы можете владеть квартирой любой площади до метра. Вы можете скачать этаж квартиры. Если вам нужна дополнительная информация, мы с радостью ответим на все ваши вопросы.", "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома.", "project/projectimage5.png", "project/projectimage4.png", "project/projectimage1.png", "project/projectimage6.png", "project/projectimage3.png", "project/projectimage2.png", new Guid("74e718a8-8b75-4f26-af88-d07762734b01"), 3, "project/projectimage11.jpg", "project/projectimage10.jpg", "project/projectimage7.png", "project/projectimage12.jpg", "project/projectimage9.png", "project/projectimage8.png", "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома. Общая площадь 3-х этажного жилого дома 570 кв.м. метров. Общая площадь каждого нежилого дома составляет 500 кв.м. метров. Здесь есть крытый и открытый ресторан, крытый бассейн, спа-центр, фитнес-центр, диетическое кафе, эстетический центр для женщин, салон красоты и рынок.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "Расположение комплекса", "Жилищный проект" },
                    { 1, "Biz ilk olaraq Azərbaycanda alıcının maliyyə durumuna uyğun olaraq mənzil sahəsini müyənnləşdirib sata bilirik. 28 kv. metrdən 190 kv. metrədək istənilən sahədə mənzil sahibi ola bilərsiniz. Mərtəbələr üzrə mənzilin palını yükləyə bilərsizniz. Daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq.", "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur.", "project/projectimage5.png", "project/projectimage4.png", "project/projectimage1.png", "project/projectimage6.png", "project/projectimage3.png", "project/projectimage2.png", new Guid("74e718a8-8b75-4f26-af88-d07762734b01"), 1, "project/projectimage11.jpg", "project/projectimage10.jpg", "project/projectimage7.png", "project/projectimage12.jpg", "project/projectimage9.png", "project/projectimage8.png", "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur. 3 mərtəbəli yaşayış binasının ümumi sahəsi 570 kv. metrdir. Qeyri yaşayış binalarının hər birinin ümumi sahəsi 500 kv. metrdir. Burada qapalı və açıq restoran, qapalı hovuz, spa mərkəzi, fitnes mərkəzi, diyetik kafe, qadınlar üçün estetik mərkəz, gözəllik salonu və market nəzərdə tutulmuşdur.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "Kompleksin lokasiyası", "Mənzillərin layihəsi" },
                    { 2, "First of all, we can determine and sell the housing area in Azerbaijan according to the financial situation of the buyer. 28 sq. M. 190 square meters. You can own an apartment in any area up to a meter. You can download the floor of the apartment. If you need more information, we are happy to answer all your questions.", "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land.", "project/projectimage5.png", "project/projectimage4.png", "project/projectimage1.png", "project/projectimage6.png", "project/projectimage3.png", "project/projectimage2.png", new Guid("74e718a8-8b75-4f26-af88-d07762734b01"), 2, "project/projectimage11.jpg", "project/projectimage10.jpg", "project/projectimage7.png", "project/projectimage12.jpg", "project/projectimage9.png", "project/projectimage8.png", "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land. The total area of the 3-storey residential building is 570 sq.m. meters. The total area of each of the non-residential buildings is 500 sq.m. meters. There is an indoor and outdoor restaurant, an indoor pool, a spa center, a fitness center, a diet cafe, an aesthetic center for women, a beauty salon and a market.", "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>", "Location of the complex", "Housing project" }
                });

            migrationBuilder.InsertData(
                table: "SellConditions",
                columns: new[] { "Id", "Description", "LanguageGroupId", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 3, "На все жилые дома, входящие в комплекс, предоставляется выписка. Вам будет предоставлена ​​выписка о квартирах соответствующей площади, которую вы получите, вместе с выпиской из государственного реестра на основании нотариально удостоверенного договора купли-продажи.", new Guid("5cbe81b3-c281-4be6-9842-8c6426eb8861"), 3, "Продажа и документация" },
                    { 2, "All residential buildings included in the complex are provided with an extract. An extract on the apartments corresponding to the area you will acquire will be provided to you with an extract from the state register on the basis of a notarized purchase agreement.", new Guid("5cbe81b3-c281-4be6-9842-8c6426eb8861"), 2, "Sales and documentation" },
                    { 1, "Kompleksə daxil olan bütün yaşayış binaları çıxarışla təmin edilmişdir. Əldə edəcəyiniz sahəyə uyğun mənzillərə dair çıxarış notarial qaydada təsdiq edilmiş alqı-satqı müqaviləsinin əsasında dövlət reyestrindən çıxarışla sizə təqdim ediləcəkdir.", new Guid("5cbe81b3-c281-4be6-9842-8c6426eb8861"), 1, "Satış və sənədləşmə" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Description", "Image", "IsActive", "LanguageId", "PercentageIHH", "PercentageOwner", "Title" },
                values: new object[,]
                {
                    { 3, "Сумма арендной платы будет варьироваться в зависимости от площади вашей квартиры. 55% этой арендной платы будет считаться вашим чистым доходом. Из этой суммы вы не будете платить никаких налогов, комиссий и коммунальных услуг (эти условия распространяются только на период аренды). Оставшиеся 45% включают комиссию управления компании, коммунальные услуги и услуги, расходы по налогу на прибыль и прибыль и другие расходы на форс-мажорные обстоятельства. Схема распределения арендных средств:", "sprite.svg#icon-big-1", true, 3, 45, 55, "Организация процесса лизинга" },
                    { 6, "За исключением периода вашего пребывания, уборка ваших квартир в период аренды осуществляется нашей компанией бесплатно.", "sprite.svg#icon-big-2", true, 3, 0, 0, "Чистота квартир" },
                    { 9, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-3", true, 3, 0, 0, "Текущий ремонт приборов и оборудования" },
                    { 12, "Полностью предусмотрена защита предметов домашнего обихода. Это можно дополнительно отметить несколькими предложениями.", "sprite.svg#icon-big-4", true, 3, 0, 0, "ЗОткрытый и закрытый бассейн" },
                    { 15, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-5", true, 3, 0, 0, "Организация бесперебойной работы служб связи" },
                    { 18, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-6", true, 3, 0, 0, "Помощь инвалидам и гостям" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Description", "Image", "IsActive", "LanguageId", "PercentageIHH", "PercentageOwner", "Title" },
                values: new object[,]
                {
                    { 10, "Məişət əşyalarının qorunması tam təmin olunur. Əlavə olaraq bir neçə cümlədə əlavə olaraq qeyd edilə bilər.", "sprite.svg#icon-big-4", true, 1, 0, 0, "Açıq və qapalı hovuz" },
                    { 1, "Mənzilinizin sahəsindən asılı olaraq icarəyə verəcəyiniz məbləğ fərqli olacaq. Həmin icarə məbləğinin 55%-i sizin təmiz gəliriniz hesab ediləcək. Bu məbləğdən siz heçbir vergi, komissiya və komunal xərclər ödəməyəcəksiniz (bu şərtlər yalnız icarəyə verilən dövrü əhatə edir). Yerdə qalan 45% şirkətin idarəetmə komissiyası, komunal xərclər və xidmətlər, gəlir və mənfəət vergisi xərcləri və sair fors-major xərclər daxildir. İcarədən əldə edilən vəsaitin bölünmə sxemi:", "sprite.svg#icon-big-1", true, 1, 45, 55, "İcarəyə verilmə prosesinin təşkili" },
                    { 31, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-11", true, 1, 0, 0, "Turist marşturlarının təşkili" },
                    { 28, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-10", true, 1, 0, 0, "Uşaq əyləncə meydançası" },
                    { 25, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-9", true, 1, 0, 0, "Qapalı fitnes idman zalı" },
                    { 22, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-8", true, 1, 0, 0, "Spa və gözəllik salonu" },
                    { 19, "Biznes-mənzilinizin onlayn idarə edilməsi", "sprite.svg#icon-big-7", true, 1, 0, 0, "Mənzilinizin onlayn idarə edilməsi" },
                    { 16, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-6", true, 1, 0, 0, "Əngəlli sakin və qonaqlarına köməklik" },
                    { 2, "The amount you will rent will vary depending on the area of your apartment. 55% of that rent will be considered your net income. From this amount you will not pay any taxes, commissions and utilities (these terms only cover the lease period). The remaining 45% includes the company's management commission, utilities and services, income and profit tax expenses, and other force majeure expenses. Distribution scheme of rental funds:", "sprite.svg#icon-big-1", true, 2, 45, 55, "Organization of the leasing process" },
                    { 5, "Except for the period of your stay, the cleaning of your apartments during the lease period is carried out by our company free of charge.", "sprite.svg#icon-big-2", true, 2, 0, 0, "Cleanliness of apartments" },
                    { 8, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-3", true, 2, 0, 0, "Current repair of devices and equipment " },
                    { 11, "The protection of household items is fully provided. It can be additionally noted in a few sentences.", "sprite.svg#icon-big-4", true, 2, 0, 0, "Outdoor and indoor pool" },
                    { 27, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-9", true, 3, 0, 0, "Крытый фитнес-зал" },
                    { 14, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-5", true, 2, 0, 0, "Organization of uninterrupted work of communication services" },
                    { 20, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-7", true, 2, 0, 0, "Manage your apartment online" },
                    { 23, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-8", true, 2, 0, 0, "Spa and beauty salon" },
                    { 26, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-9", true, 2, 0, 0, "Indoor fitness gym" },
                    { 29, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-10", true, 2, 0, 0, "Children's playground" },
                    { 32, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-11", true, 2, 0, 0, "Организация туристических маршрутов" },
                    { 33, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-11", true, 3, 0, 0, "Organization of tourist routes" },
                    { 30, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-10", true, 3, 0, 0, "Детская площадка" },
                    { 13, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-5", true, 1, 0, 0, "Kommunikasiya xidmetlerinin fasiləsiz işinin təşkili" },
                    { 21, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-7", true, 3, 0, 0, "Управляйте своей квартирой онлайн" },
                    { 7, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.", "sprite.svg#icon-big-3", true, 1, 0, 0, "Cihaz və avadanliqlarin cari təmiri" },
                    { 4, "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə mənzillərinizin təmizliyini ödənişsiz şirkətimiz tərəfindən həyata keçirilr.", "sprite.svg#icon-big-2", true, 1, 0, 0, "Mənzillərin təmizliyi" },
                    { 17, "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.", "sprite.svg#icon-big-6", true, 2, 0, 0, "Assistance to disabled residents and guests" },
                    { 24, "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.", "sprite.svg#icon-big-8", true, 3, 0, 0, "Спа и салон красоты" }
                });

            migrationBuilder.InsertData(
                table: "TitlesAndSubtitles",
                columns: new[] { "Id", "IsActive", "LanguageGroupId", "LanguageId", "Subtitle1", "Subtitle2", "Subtitle3", "Title1", "Title2", "Title3" },
                values: new object[,]
                {
                    { 3, true, new Guid("af135637-054f-42d2-bdaa-e47401426534"), 3, "У подножия Кавказских гор, в 11 зданиях, которые мы построили на 1 гектаре частной земли с видом на реку Кумрук и ущелье Илису, мы предлагаем бизнес-апартаменты в районе, который соответствует вашим потребностям.", "Два коротких предложения об услугах, которые необходимо получить после получения квартиры.", "Наш жилой комплекс находится в одном шаге от государственного природного заповедника Илису. Илисуский государственный заповедник расположен на южном склоне Большого Кавказа в Гахском районе, между Загатальским и Исмаиллинским заповедниками на высоте 700-2100 м. Рельеф местности характерен для крутых склонов Главного Кавказского хребта, интенсивно разделенных речными долинами. По мере его подъема терригенные отложения современного континентального, нижнего и верхнего мела и средней юры сменяют друг друга.", "Впервые в Азербайджане мы создали для вас новую модель бизнес-жилья, сочетающую жилое и нежилое.", "Жители получают следующие услуги", "Разместите одно из самых красивых мест в экотуризме." },
                    { 1, true, new Guid("af135637-054f-42d2-bdaa-e47401426534"), 1, "Qafqaz dağlarının ətəyində, Kümrük çayına və İlisu dərəsinə baxış görünüşü olan 1 ha özəl torpaqda inşa etdiyimiz 11 ədəd binada, istəyinizə uyğun olan sahəli biznes-mənzillər təklif edirik.", "Mənzil əldə etdikdən sonra əldə ediləcək xidmətlərə dair qısa məzmunlu iki cümlə.", "Yaşayış kompleksimiz İlisu Dövlət Təbiət Qoruğunun bir addımlığındadır. İlisu dövlət qoruğu Böyük Qafqazın cənub yamacında Qax rayonu ərazisində, Zaqatala və İsmayıllı qoruqlarının arasında 700–2100 m hündürlükdə yerləşir. Ərazi Baş Qafqaz dağlarının dik yamaclı,çay dərələri vasitəsilə intensiv parçalanmış sahələri üçün səciyyəvi olan relyefə malikdir. Hündürlüyə qalxdıqca müasir kontinental, alt və üst təbaşirin, orta yuranın terrigen çöküntüləri bir birini əvəz edir.", "Azərbaycanda ilk olaraq yaşayış və qeyri-yaşayışı bir arada birləşdirərək sizlərə yeni bir biznes-mənzil modelini yaratdıq", "Sakinlər aşağıdakı xidmətləri əldə edir", "Ekoturizmin ən gözəl məkanlarından birində ev sahibi olun" },
                    { 2, true, new Guid("af135637-054f-42d2-bdaa-e47401426534"), 2, "At the foot of the Caucasus Mountains, in 11 buildings we built on 1 hectare of private land with a view of the Kumruk River and Ilisu Gorge, we offer business apartments in the area that suits your needs.", "Two short sentences about the services to be obtained after obtaining an apartment.", "Our residential complex is one step away from the Ilisu State Nature Reserve. Ilisu State Reserve is located on the southern slope of the Greater Caucasus in the Gakh region, between the Zagatala and Ismayilli reserves at an altitude of 700-2100 m. The area has a relief typical of the steep slopes of the Main Caucasus Mountains, intensively divided by river valleys. As it rises, terrigenous sediments of modern continental, lower and upper Cretaceous, and Middle Jurassic replace each other.", "For the first time in Azerbaijan, we have created a new business-housing model for you, combining residential and non-residential", "Residents receive the following services", "Host one of the most beautiful places in ecotourism" }
                });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Description", "ImageFive", "ImageFour", "ImageOne", "ImageSix", "ImageThree", "ImageTwo", "LanguageGroupId", "LanguageId", "Title" },
                values: new object[,]
                {
                    { 2, "Our company regularly organizes sales tours to get acquainted with the apartments and the area in detail. All you need is a few days to see everything with your own eyes, choose the apartment you want, get advice on the spot and make a purchase, if necessary. At the same time, you will have an interesting time and get acquainted with the ancient culture and history of Ilisu. If you need more information about the tours, we are happy to answer all your questions. You can contact the sales office through the contact numbers posted on the site.", "toure/toureimage5.png", "toure/toureimage4.png", "toure/toureimage1.png", "toure/toureimage6.png", "toure/toureimage3.png", "toure/toureimage2.png", new Guid("556eebb0-3602-4ae5-9c6d-f3d89261c129"), 2, "Travel for the purchase and sale of business apartments" },
                    { 3, "Наша компания регулярно организует торговые туры для детального ознакомления с квартирами и районом. Достаточно несколько дней, чтобы увидеть все своими глазами, выбрать нужную квартиру, получить консультацию на месте и при необходимости совершить покупку. Заодно интересно проведете время и познакомитесь с древней культурой и историей Илису. Если вам нужна дополнительная информация о турах, мы с радостью ответим на все ваши вопросы. Связаться с офисом продаж можно по контактным номерам, указанным на сайте.", "toure/toureimage5.png", "toure/toureimage4.png", "toure/toureimage1.png", "toure/toureimage6.png", "toure/toureimage3.png", "toure/toureimage2.png", new Guid("556eebb0-3602-4ae5-9c6d-f3d89261c129"), 3, "Путешествие по покупке и продаже бизнес-квартир" },
                    { 1, "Şirkətimiz tərəfindən mütəmadi olaraq mənzillərlə və əraziylə detallı tanış olmaq üçün satış turlar təşkil edilir. Bunun üçün sizin cəmi bir neçə gününüz kifayətdir ki hərşeyi öz göznüzlə görüb, istədiyiniz mənzili seçməyiniz, ehtiyac olduğu təqdirdə yerində konsultasiya almaq və alqı satqını həyata keçirə bilərsiniz. Bununla bərabər siz həm də zamanınızı maraqlı keçirərək İlisunun qəıdim mədəniyyət və tarixiylə tanış olursunuz. Turlarla bağlı daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq. Saytda yerlışdirilən əlaqə nömrələri vasitəsiylə satış ofisiylə əlaqə saxlaya bilərsiniz.", "toure/toureimage5.png", "toure/toureimage4.png", "toure/toureimage1.png", "toure/toureimage6.png", "toure/toureimage3.png", "toure/toureimage2.png", new Guid("556eebb0-3602-4ae5-9c6d-f3d89261c129"), 1, "Biznes-mənzillərin alqı-satqısı üçün edilən səyahət" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advantage_LanguageId",
                table: "Advantage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageHiltop_LanguageId",
                table: "AdvantageHiltop",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageOfPurchasings_LanguageId",
                table: "AdvantageOfPurchasings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_LanguageId",
                table: "Banners",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionsOfPurchasings_LanguageId",
                table: "ConditionsOfPurchasings",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePageInformation_LanguageId",
                table: "HomePageInformation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HomePages_LanguageId",
                table: "HomePages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HousingProjects_LanguageId",
                table: "HousingProjects",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_LanguageId",
                table: "Office",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LanguageId",
                table: "Projects",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SellConditions_LanguageId",
                table: "SellConditions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_LanguageId",
                table: "Service",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAdvantages_AdvantageId",
                table: "ServiceAdvantages",
                column: "AdvantageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHiltopAdvantages_AdvantageHiltopId",
                table: "ServiceHiltopAdvantages",
                column: "AdvantageHiltopId");

            migrationBuilder.CreateIndex(
                name: "IX_TitlesAndSubtitles_LanguageId",
                table: "TitlesAndSubtitles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_LanguageId",
                table: "Travels",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvantageOfPurchasings");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "ConditionsOfPurchasings");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "HomePageInformation");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "HousingProjects");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SellConditions");

            migrationBuilder.DropTable(
                name: "ServiceAdvantages");

            migrationBuilder.DropTable(
                name: "ServiceHiltopAdvantages");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "TitlesAndSubtitles");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Advantage");

            migrationBuilder.DropTable(
                name: "AdvantageHiltop");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
