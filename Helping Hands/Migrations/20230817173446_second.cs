using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Helping_Hands.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdNumber = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    AdminContact = table.Column<int>(nullable: false),
                    LineAddress1 = table.Column<string>(nullable: true),
                    LineAddress2 = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminUserID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChronicInfections",
                columns: table => new
                {
                    ChronicID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicInfections", x => x.ChronicID);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    NurseUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    NurseCode = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    NurseContact = table.Column<string>(nullable: true),
                    LineAddress1 = table.Column<string>(nullable: true),
                    LineAddress2 = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    SuburbID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.NurseUserID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abbrev = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    SuburbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburbs_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    NpoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationName = table.Column<string>(nullable: true),
                    NpoNumber = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    WeekDay1 = table.Column<string>(nullable: true),
                    WeekDay2 = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<TimeSpan>(nullable: true),
                    ClosingTime = table.Column<TimeSpan>(nullable: true),
                    LineAddress1 = table.Column<string>(nullable: true),
                    LineAddress2 = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.NpoID);
                    table.ForeignKey(
                        name: "FK_Organisations_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organisations_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Organisations_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdNumber = table.Column<double>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: true),
                    NextOfKinName = table.Column<string>(nullable: true),
                    NextOfKinContact = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    PatientContact = table.Column<string>(nullable: true),
                    AdditionalInfor = table.Column<string>(nullable: true),
                    LineAddress1 = table.Column<string>(nullable: true),
                    LineAddress2 = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientUserID);
                    table.ForeignKey(
                        name: "FK_Patients_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Patients_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PreferedSuburbs",
                columns: table => new
                {
                    PreferedSubID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseUserID = table.Column<int>(nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    SuburbID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferedSuburbs", x => x.PreferedSubID);
                    table.ForeignKey(
                        name: "FK_PreferedSuburbs_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreferedSuburbs_Nurses_NurseUserID",
                        column: x => x.NurseUserID,
                        principalTable: "Nurses",
                        principalColumn: "NurseUserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreferedSuburbs_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageArchive",
                columns: table => new
                {
                    ImageArchiveID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    NpoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageArchive", x => x.ImageArchiveID);
                    table.ForeignKey(
                        name: "FK_ImageArchive_Organisations_NpoID",
                        column: x => x.NpoID,
                        principalTable: "Organisations",
                        principalColumn: "NpoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerUserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdNumber = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    ManagerContact = table.Column<string>(nullable: true),
                    NpoID = table.Column<int>(nullable: true),
                    LineAddress1 = table.Column<string>(nullable: true),
                    LineAddress2 = table.Column<string>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    SuburbID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerUserID);
                    table.ForeignKey(
                        name: "FK_Managers_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managers_Organisations_NpoID",
                        column: x => x.NpoID,
                        principalTable: "Organisations",
                        principalColumn: "NpoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managers_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Managers_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CareContracts",
                columns: table => new
                {
                    ContractNumberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractDate = table.Column<DateTime>(nullable: false),
                    PatientUserID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    WoundDescription = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    NurseUserID = table.Column<int>(nullable: false),
                    ProvinceID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareContracts", x => x.ContractNumberID);
                    table.ForeignKey(
                        name: "FK_CareContracts_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareContracts_Nurses_NurseUserID",
                        column: x => x.NurseUserID,
                        principalTable: "Nurses",
                        principalColumn: "NurseUserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareContracts_Patients_PatientUserID",
                        column: x => x.PatientUserID,
                        principalTable: "Patients",
                        principalColumn: "PatientUserID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CareContracts_Provinces_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CareContracts_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChronicAccoms",
                columns: table => new
                {
                    ChronicAccomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChronicID = table.Column<int>(nullable: true),
                    PatientUserID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicAccoms", x => x.ChronicAccomID);
                    table.ForeignKey(
                        name: "FK_ChronicAccoms_ChronicInfections_ChronicID",
                        column: x => x.ChronicID,
                        principalTable: "ChronicInfections",
                        principalColumn: "ChronicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChronicAccoms_Patients_PatientUserID",
                        column: x => x.PatientUserID,
                        principalTable: "Patients",
                        principalColumn: "PatientUserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CareVisits",
                columns: table => new
                {
                    CareVisitsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumberID = table.Column<int>(nullable: false),
                    NurseUserID = table.Column<int>(nullable: false),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    ApproxArriva = table.Column<TimeSpan>(nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(nullable: true),
                    DepartTime = table.Column<TimeSpan>(nullable: true),
                    WoundCondition = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareVisits", x => x.CareVisitsID);
                    table.ForeignKey(
                        name: "FK_CareVisits_CareContracts_ContractNumberID",
                        column: x => x.ContractNumberID,
                        principalTable: "CareContracts",
                        principalColumn: "ContractNumberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareVisits_Nurses_NurseUserID",
                        column: x => x.NurseUserID,
                        principalTable: "Nurses",
                        principalColumn: "NurseUserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CareContracts_CityID",
                table: "CareContracts",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_CareContracts_NurseUserID",
                table: "CareContracts",
                column: "NurseUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CareContracts_PatientUserID",
                table: "CareContracts",
                column: "PatientUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CareContracts_ProvinceID",
                table: "CareContracts",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_CareContracts_SuburbID",
                table: "CareContracts",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_CareVisits_ContractNumberID",
                table: "CareVisits",
                column: "ContractNumberID");

            migrationBuilder.CreateIndex(
                name: "IX_CareVisits_NurseUserID",
                table: "CareVisits",
                column: "NurseUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicAccoms_ChronicID",
                table: "ChronicAccoms",
                column: "ChronicID");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicAccoms_PatientUserID",
                table: "ChronicAccoms",
                column: "PatientUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceID",
                table: "Cities",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_ImageArchive_NpoID",
                table: "ImageArchive",
                column: "NpoID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CityID",
                table: "Managers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_NpoID",
                table: "Managers",
                column: "NpoID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ProvinceID",
                table: "Managers",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_SuburbID",
                table: "Managers",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_CityID",
                table: "Organisations",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ProvinceID",
                table: "Organisations",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_SuburbID",
                table: "Organisations",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CityID",
                table: "Patients",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProvinceID",
                table: "Patients",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SuburbID",
                table: "Patients",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_PreferedSuburbs_CityID",
                table: "PreferedSuburbs",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_PreferedSuburbs_NurseUserID",
                table: "PreferedSuburbs",
                column: "NurseUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PreferedSuburbs_SuburbID",
                table: "PreferedSuburbs",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityID",
                table: "Suburbs",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CareVisits");

            migrationBuilder.DropTable(
                name: "ChronicAccoms");

            migrationBuilder.DropTable(
                name: "ImageArchive");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "PreferedSuburbs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CareContracts");

            migrationBuilder.DropTable(
                name: "ChronicInfections");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Suburbs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
