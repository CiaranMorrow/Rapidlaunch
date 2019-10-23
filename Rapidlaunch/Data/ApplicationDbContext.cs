using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rapidlaunch.Models;

namespace Rapidlaunch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<SafetyRating> SafetyRatings { get; set; }
        public DbSet<PadStatus> PadStatuses { get; set; }
        public DbSet<ITAccountType> ITAccountTypes { get; set; }
        public DbSet<ITAccount> ITAccounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProviderContact> ProviderContacts { get; set; }
        public DbSet<LaunchStaffSchedule> LaunchStaffSchedules { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<RocketType> RocketTypes { get; set; }  
        public DbSet<StaffAddress> StaffAddresses { get; set; }
        public DbSet<StaffSafetyRecord> StaffSafetyRecords { get; set; }
        public DbSet<ProviderAddress> ProviderAddresses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Launch> Launches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("tbl_Addresses");
            builder.Entity<Country>().ToTable("tbl_Countries");
            builder.Entity<ITAccount>().ToTable("tbl_ITAccounts");
            builder.Entity<Launch>().ToTable("tbl_Launches");
            builder.Entity<LaunchStaffSchedule>().ToTable("tbl_LaunchStaffSchedule");
            builder.Entity<PadStatus>().ToTable("tbl_PadStatus"); 
            builder.Entity<Provider>().ToTable("tbl_Provider");
            builder.Entity<ProviderContact>().ToTable("tbl_ProviderContact");
            builder.Entity<Rocket>().ToTable("tbl_Rockets");
            builder.Entity<RocketType>().ToTable("tbl_RocketTypes");
            builder.Entity<Role>().ToTable("tbl_Role");
            builder.Entity<SafetyRating>().ToTable("tbl_SafetyRatings");
            builder.Entity<Staff>().ToTable("tbl_Staffs");
            builder.Entity<StaffAddress>().ToTable("tbl_StaffAddress");
            builder.Entity<StaffSafetyRecord>().ToTable("tbl_StaffSafetyRecords");

            builder.Entity<StaffSafetyRecord>()
                .HasKey(c => new { c.safetyRatingID, c.staffID });

            builder.Entity<StaffAddress>()
                .HasKey(c => new { c.staffAdrressID, c.staffIdentID });

            builder.Entity<ProviderAddress>()
                .HasKey(c => new {  c.providerID, c.addressIdentID });
            
                
        }



        
    }
}
