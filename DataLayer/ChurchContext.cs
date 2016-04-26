using EFDataLayer.Configuration;
using MinistrySuite.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFDataLayer
{
    public class ChurchContext : DbContext
    {
        public virtual DbSet<Church> Churches { get; set; }
        public virtual DbSet<ChurchMember> ChurchMemebrs { get; set; }
        public DbSet<PrayerRequest> PrayerRequests { get; set; }
        public DbSet<Ministry> Ministries { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ChurchConfig());
            modelBuilder.Configurations.Add(new ChurchMemberConfig());
            modelBuilder.Configurations.Add(new ChurchAddressesConfig());
            modelBuilder.Configurations.Add(new ChurchMemberAddressConfig());
            modelBuilder.Configurations.Add(new MinistryConfig());
            modelBuilder.Configurations.Add(new PrayerRequestConfig());
            modelBuilder.Configurations.Add(new ChurchEmailAddressConfig());
            modelBuilder.Configurations.Add(new ChurchMemberEmailAddressConfig());
            modelBuilder.Configurations.Add(new ChurchPhoneNumberConfig());
            modelBuilder.Configurations.Add(new ChurchMemberPhoneNumberConfig());
            modelBuilder.Configurations.Add(new PrayerRequestUpdateConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
