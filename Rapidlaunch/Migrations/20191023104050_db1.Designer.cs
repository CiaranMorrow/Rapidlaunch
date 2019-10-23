﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rapidlaunch.Data;

namespace Rapidlaunch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191023104050_db1")]
    partial class db1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addressLine1");

                    b.Property<string>("addressLine2");

                    b.Property<string>("addressLine3");

                    b.Property<int>("countryID");

                    b.Property<string>("postCode");

                    b.HasKey("AddressID");

                    b.HasIndex("countryID");

                    b.ToTable("tbl_Addresses");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("countryName");

                    b.HasKey("CountryID");

                    b.ToTable("tbl_Countries");
                });

            modelBuilder.Entity("Rapidlaunch.Models.ITAccount", b =>
                {
                    b.Property<int>("ITAccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("itAccountTypeID");

                    b.Property<int>("itaccountTypeIdentID");

                    b.HasKey("ITAccountID");

                    b.HasIndex("itAccountTypeID");

                    b.ToTable("tbl_ITAccounts");
                });

            modelBuilder.Entity("Rapidlaunch.Models.ITAccountType", b =>
                {
                    b.Property<int>("itAccountTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("authorisationLevel");

                    b.HasKey("itAccountTypeID");

                    b.ToTable("ITAccountTypes");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Launch", b =>
                {
                    b.Property<int>("LaunchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PadStatusID");

                    b.Property<int?>("ProviderAddressaddressIdentID");

                    b.Property<int?>("ProviderAddressproviderID");

                    b.Property<int?>("ProviderID");

                    b.Property<int?>("RocketID");

                    b.Property<DateTime>("launchDate");

                    b.Property<string>("launchName");

                    b.Property<string>("padStatusIdenet");

                    b.Property<int>("providerIdent");

                    b.Property<string>("rocketIdentID");

                    b.HasKey("LaunchID");

                    b.HasIndex("PadStatusID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("RocketID");

                    b.HasIndex("ProviderAddressproviderID", "ProviderAddressaddressIdentID");

                    b.ToTable("tbl_Launches");
                });

            modelBuilder.Entity("Rapidlaunch.Models.LaunchStaffSchedule", b =>
                {
                    b.Property<int>("LaunchStaffScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("launchID");

                    b.Property<int>("staffID");

                    b.HasKey("LaunchStaffScheduleID");

                    b.HasIndex("launchID");

                    b.HasIndex("staffID");

                    b.ToTable("tbl_LaunchStaffSchedule");
                });

            modelBuilder.Entity("Rapidlaunch.Models.PadStatus", b =>
                {
                    b.Property<int>("PadStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("padStatus");

                    b.HasKey("PadStatusID");

                    b.ToTable("tbl_PadStatus");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Provider", b =>
                {
                    b.Property<int>("ProviderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProviderName");

                    b.Property<int>("ProviderRegNo");

                    b.HasKey("ProviderID");

                    b.ToTable("tbl_Provider");
                });

            modelBuilder.Entity("Rapidlaunch.Models.ProviderAddress", b =>
                {
                    b.Property<int>("providerID");

                    b.Property<int>("addressIdentID");

                    b.Property<int?>("AddressID");

                    b.HasKey("providerID", "addressIdentID");

                    b.HasIndex("AddressID");

                    b.ToTable("ProviderAddresses");
                });

            modelBuilder.Entity("Rapidlaunch.Models.ProviderContact", b =>
                {
                    b.Property<int>("ProviderContactID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contactEmail");

                    b.Property<int>("contactTelNum");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<int>("providerID");

                    b.Property<int?>("roleID");

                    b.Property<int>("roleIdentID");

                    b.HasKey("ProviderContactID");

                    b.HasIndex("providerID");

                    b.HasIndex("roleID");

                    b.ToTable("tbl_ProviderContact");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Rocket", b =>
                {
                    b.Property<int>("RocketID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("rocketName");

                    b.Property<int?>("rocketTypeID");

                    b.Property<int>("rocketypeID");

                    b.HasKey("RocketID");

                    b.HasIndex("rocketTypeID");

                    b.ToTable("tbl_Rockets");
                });

            modelBuilder.Entity("Rapidlaunch.Models.RocketType", b =>
                {
                    b.Property<int>("rocketTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("height");

                    b.Property<string>("rocketPropellant");

                    b.Property<string>("rocketignitor");

                    b.Property<int>("width");

                    b.HasKey("rocketTypeID");

                    b.ToTable("tbl_RocketTypes");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("roleName");

                    b.HasKey("roleID");

                    b.ToTable("tbl_Role");
                });

            modelBuilder.Entity("Rapidlaunch.Models.SafetyRating", b =>
                {
                    b.Property<int>("safetyRatingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("safetyRating");

                    b.HasKey("safetyRatingID");

                    b.ToTable("tbl_SafetyRatings");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Staff", b =>
                {
                    b.Property<int>("staffID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ITAccountID");

                    b.Property<string>("firstNameIdent");

                    b.Property<int>("itAccountIdentID");

                    b.Property<string>("lastNameIdent");

                    b.Property<int?>("roleID");

                    b.Property<int>("roleIdentID");

                    b.Property<string>("staffEmail");

                    b.Property<string>("staffTel");

                    b.HasKey("staffID");

                    b.HasIndex("ITAccountID");

                    b.HasIndex("roleID");

                    b.ToTable("tbl_Staffs");
                });

            modelBuilder.Entity("Rapidlaunch.Models.StaffAddress", b =>
                {
                    b.Property<int>("staffAdrressID");

                    b.Property<int>("staffIdentID");

                    b.Property<int?>("AddressID");

                    b.Property<int?>("staffID");

                    b.HasKey("staffAdrressID", "staffIdentID");

                    b.HasIndex("AddressID");

                    b.HasIndex("staffID");

                    b.ToTable("tbl_StaffAddress");
                });

            modelBuilder.Entity("Rapidlaunch.Models.StaffSafetyRecord", b =>
                {
                    b.Property<int>("safetyRatingID");

                    b.Property<int>("staffID");

                    b.Property<int>("rocketTypeID");

                    b.HasKey("safetyRatingID", "staffID");

                    b.HasIndex("rocketTypeID");

                    b.HasIndex("staffID");

                    b.ToTable("tbl_StaffSafetyRecords");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rapidlaunch.Models.Address", b =>
                {
                    b.HasOne("Rapidlaunch.Models.Country", "country")
                        .WithMany("Addresses")
                        .HasForeignKey("countryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rapidlaunch.Models.ITAccount", b =>
                {
                    b.HasOne("Rapidlaunch.Models.ITAccountType", "ITAccountType")
                        .WithMany("ITAccounts")
                        .HasForeignKey("itAccountTypeID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Launch", b =>
                {
                    b.HasOne("Rapidlaunch.Models.PadStatus", "PadStatus")
                        .WithMany("Launches")
                        .HasForeignKey("PadStatusID");

                    b.HasOne("Rapidlaunch.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID");

                    b.HasOne("Rapidlaunch.Models.Rocket", "rocket")
                        .WithMany("Launches")
                        .HasForeignKey("RocketID");

                    b.HasOne("Rapidlaunch.Models.ProviderAddress")
                        .WithMany("Launches")
                        .HasForeignKey("ProviderAddressproviderID", "ProviderAddressaddressIdentID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.LaunchStaffSchedule", b =>
                {
                    b.HasOne("Rapidlaunch.Models.Launch", "Launch")
                        .WithMany("LaunchStaffSchedules")
                        .HasForeignKey("launchID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rapidlaunch.Models.Staff", "staff")
                        .WithMany("LaunchStaffSchedules")
                        .HasForeignKey("staffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rapidlaunch.Models.ProviderAddress", b =>
                {
                    b.HasOne("Rapidlaunch.Models.Address", "Address")
                        .WithMany("ProviderAddresses")
                        .HasForeignKey("AddressID");

                    b.HasOne("Rapidlaunch.Models.Provider", "Provider")
                        .WithMany("ProviderAddresses")
                        .HasForeignKey("providerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rapidlaunch.Models.ProviderContact", b =>
                {
                    b.HasOne("Rapidlaunch.Models.Provider", "provider")
                        .WithMany("ProviderContacts")
                        .HasForeignKey("providerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rapidlaunch.Models.Role", "role")
                        .WithMany("providerContacts")
                        .HasForeignKey("roleID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Rocket", b =>
                {
                    b.HasOne("Rapidlaunch.Models.RocketType", "RocketType")
                        .WithMany("Rockets")
                        .HasForeignKey("rocketTypeID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.Staff", b =>
                {
                    b.HasOne("Rapidlaunch.Models.ITAccount", "ITAccount")
                        .WithMany("Staffs")
                        .HasForeignKey("ITAccountID");

                    b.HasOne("Rapidlaunch.Models.Role", "Role")
                        .WithMany("staff")
                        .HasForeignKey("roleID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.StaffAddress", b =>
                {
                    b.HasOne("Rapidlaunch.Models.Address", "Address")
                        .WithMany("StaffAddresses")
                        .HasForeignKey("AddressID");

                    b.HasOne("Rapidlaunch.Models.Staff", "staff")
                        .WithMany("StaffAddresses")
                        .HasForeignKey("staffID");
                });

            modelBuilder.Entity("Rapidlaunch.Models.StaffSafetyRecord", b =>
                {
                    b.HasOne("Rapidlaunch.Models.RocketType", "rocketType")
                        .WithMany("staffSafetyRecords")
                        .HasForeignKey("rocketTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rapidlaunch.Models.SafetyRating", "SafetyRating")
                        .WithMany("StaffSafetyRecords")
                        .HasForeignKey("safetyRatingID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rapidlaunch.Models.Staff")
                        .WithMany("StaffSafetyRecords")
                        .HasForeignKey("staffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}