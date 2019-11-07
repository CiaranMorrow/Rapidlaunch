using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rapidlaunch.Migrations
{
    public partial class whatever : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ITAccountTypes",
                columns: table => new
                {
                    itAccountTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    authorisationLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITAccountTypes", x => x.itAccountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    countryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PadStatus",
                columns: table => new
                {
                    PadStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    padStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PadStatus", x => x.PadStatusID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderName = table.Column<string>(nullable: true),
                    ProviderRegNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Provider", x => x.ProviderID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RocketTypes",
                columns: table => new
                {
                    rocketTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    rocketignitor = table.Column<string>(nullable: true),
                    rocketPropellant = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RocketTypes", x => x.rocketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role",
                columns: table => new
                {
                    roleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SafetyRatings",
                columns: table => new
                {
                    safetyRatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    safetyRating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SafetyRatings", x => x.safetyRatingID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "tbl_ITAccounts",
                columns: table => new
                {
                    ITAccountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itaccountTypeIdentID = table.Column<int>(nullable: false),
                    itAccountTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ITAccounts", x => x.ITAccountID);
                    table.ForeignKey(
                        name: "FK_tbl_ITAccounts_ITAccountTypes_itAccountTypeID",
                        column: x => x.itAccountTypeID,
                        principalTable: "ITAccountTypes",
                        principalColumn: "itAccountTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    addressLine1 = table.Column<string>(nullable: true),
                    addressLine2 = table.Column<string>(nullable: true),
                    addressLine3 = table.Column<string>(nullable: true),
                    countryID = table.Column<int>(nullable: false),
                    postCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_tbl_Addresses_tbl_Countries_countryID",
                        column: x => x.countryID,
                        principalTable: "tbl_Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Rockets",
                columns: table => new
                {
                    RocketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    rocketName = table.Column<string>(nullable: true),
                    rocketypeID = table.Column<int>(nullable: false),
                    rocketTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Rockets", x => x.RocketID);
                    table.ForeignKey(
                        name: "FK_tbl_Rockets_tbl_RocketTypes_rocketTypeID",
                        column: x => x.rocketTypeID,
                        principalTable: "tbl_RocketTypes",
                        principalColumn: "rocketTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProviderContact",
                columns: table => new
                {
                    ProviderContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    providerID = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    contactEmail = table.Column<string>(nullable: true),
                    roleIdentID = table.Column<int>(nullable: false),
                    contactTelNum = table.Column<int>(nullable: false),
                    roleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProviderContact", x => x.ProviderContactID);
                    table.ForeignKey(
                        name: "FK_tbl_ProviderContact_tbl_Provider_providerID",
                        column: x => x.providerID,
                        principalTable: "tbl_Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_ProviderContact_tbl_Role_roleID",
                        column: x => x.roleID,
                        principalTable: "tbl_Role",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Staffs",
                columns: table => new
                {
                    staffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    roleIdentID = table.Column<int>(nullable: false),
                    staffTel = table.Column<string>(nullable: true),
                    firstNameIdent = table.Column<string>(nullable: true),
                    lastNameIdent = table.Column<string>(nullable: true),
                    staffEmail = table.Column<string>(nullable: true),
                    itAccountIdentID = table.Column<int>(nullable: false),
                    roleID = table.Column<int>(nullable: true),
                    ITAccountID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Staffs", x => x.staffID);
                    table.ForeignKey(
                        name: "FK_tbl_Staffs_tbl_ITAccounts_ITAccountID",
                        column: x => x.ITAccountID,
                        principalTable: "tbl_ITAccounts",
                        principalColumn: "ITAccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Staffs_tbl_Role_roleID",
                        column: x => x.roleID,
                        principalTable: "tbl_Role",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderAddresses",
                columns: table => new
                {
                    ProviderID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderAddresses", x => new { x.ProviderID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_tbl_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "tbl_Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderAddresses_tbl_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "tbl_Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StaffAddress",
                columns: table => new
                {
                    staffID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StaffAddress", x => new { x.staffID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_tbl_StaffAddress_tbl_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "tbl_Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_StaffAddress_tbl_Staffs_staffID",
                        column: x => x.staffID,
                        principalTable: "tbl_Staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StaffSafetyRecords",
                columns: table => new
                {
                    staffID = table.Column<int>(nullable: false),
                    safetyRatingID = table.Column<int>(nullable: false),
                    rocketTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StaffSafetyRecords", x => new { x.safetyRatingID, x.staffID });
                    table.ForeignKey(
                        name: "FK_tbl_StaffSafetyRecords_tbl_RocketTypes_rocketTypeID",
                        column: x => x.rocketTypeID,
                        principalTable: "tbl_RocketTypes",
                        principalColumn: "rocketTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_StaffSafetyRecords_tbl_SafetyRatings_safetyRatingID",
                        column: x => x.safetyRatingID,
                        principalTable: "tbl_SafetyRatings",
                        principalColumn: "safetyRatingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_StaffSafetyRecords_tbl_Staffs_staffID",
                        column: x => x.staffID,
                        principalTable: "tbl_Staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Launches",
                columns: table => new
                {
                    LaunchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    providerIdent = table.Column<int>(nullable: false),
                    launchDate = table.Column<DateTime>(nullable: false),
                    launchName = table.Column<string>(nullable: true),
                    padStatusIdenet = table.Column<string>(nullable: true),
                    rocketIdentID = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: true),
                    PadStatusID = table.Column<int>(nullable: true),
                    RocketID = table.Column<int>(nullable: true),
                    ProviderAddressAddressID = table.Column<int>(nullable: true),
                    ProviderAddressProviderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Launches", x => x.LaunchID);
                    table.ForeignKey(
                        name: "FK_tbl_Launches_tbl_PadStatus_PadStatusID",
                        column: x => x.PadStatusID,
                        principalTable: "tbl_PadStatus",
                        principalColumn: "PadStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Launches_tbl_Provider_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "tbl_Provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Launches_tbl_Rockets_RocketID",
                        column: x => x.RocketID,
                        principalTable: "tbl_Rockets",
                        principalColumn: "RocketID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Launches_ProviderAddresses_ProviderAddressProviderID_ProviderAddressAddressID",
                        columns: x => new { x.ProviderAddressProviderID, x.ProviderAddressAddressID },
                        principalTable: "ProviderAddresses",
                        principalColumns: new[] { "ProviderID", "AddressID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LaunchStaffSchedule",
                columns: table => new
                {
                    LaunchStaffScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    launchID = table.Column<int>(nullable: false),
                    staffID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LaunchStaffSchedule", x => x.LaunchStaffScheduleID);
                    table.ForeignKey(
                        name: "FK_tbl_LaunchStaffSchedule_tbl_Launches_launchID",
                        column: x => x.launchID,
                        principalTable: "tbl_Launches",
                        principalColumn: "LaunchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_LaunchStaffSchedule_tbl_Staffs_staffID",
                        column: x => x.staffID,
                        principalTable: "tbl_Staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_ProviderAddresses_AddressID",
                table: "ProviderAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Addresses_countryID",
                table: "tbl_Addresses",
                column: "countryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ITAccounts_itAccountTypeID",
                table: "tbl_ITAccounts",
                column: "itAccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Launches_PadStatusID",
                table: "tbl_Launches",
                column: "PadStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Launches_ProviderID",
                table: "tbl_Launches",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Launches_RocketID",
                table: "tbl_Launches",
                column: "RocketID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Launches_ProviderAddressProviderID_ProviderAddressAddressID",
                table: "tbl_Launches",
                columns: new[] { "ProviderAddressProviderID", "ProviderAddressAddressID" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LaunchStaffSchedule_launchID",
                table: "tbl_LaunchStaffSchedule",
                column: "launchID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LaunchStaffSchedule_staffID",
                table: "tbl_LaunchStaffSchedule",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProviderContact_providerID",
                table: "tbl_ProviderContact",
                column: "providerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ProviderContact_roleID",
                table: "tbl_ProviderContact",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Rockets_rocketTypeID",
                table: "tbl_Rockets",
                column: "rocketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StaffAddress_AddressID",
                table: "tbl_StaffAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Staffs_ITAccountID",
                table: "tbl_Staffs",
                column: "ITAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Staffs_roleID",
                table: "tbl_Staffs",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StaffSafetyRecords_rocketTypeID",
                table: "tbl_StaffSafetyRecords",
                column: "rocketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StaffSafetyRecords_staffID",
                table: "tbl_StaffSafetyRecords",
                column: "staffID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "tbl_LaunchStaffSchedule");

            migrationBuilder.DropTable(
                name: "tbl_ProviderContact");

            migrationBuilder.DropTable(
                name: "tbl_StaffAddress");

            migrationBuilder.DropTable(
                name: "tbl_StaffSafetyRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tbl_Launches");

            migrationBuilder.DropTable(
                name: "tbl_SafetyRatings");

            migrationBuilder.DropTable(
                name: "tbl_Staffs");

            migrationBuilder.DropTable(
                name: "tbl_PadStatus");

            migrationBuilder.DropTable(
                name: "tbl_Rockets");

            migrationBuilder.DropTable(
                name: "ProviderAddresses");

            migrationBuilder.DropTable(
                name: "tbl_ITAccounts");

            migrationBuilder.DropTable(
                name: "tbl_Role");

            migrationBuilder.DropTable(
                name: "tbl_RocketTypes");

            migrationBuilder.DropTable(
                name: "tbl_Addresses");

            migrationBuilder.DropTable(
                name: "tbl_Provider");

            migrationBuilder.DropTable(
                name: "ITAccountTypes");

            migrationBuilder.DropTable(
                name: "tbl_Countries");
        }
    }
}
