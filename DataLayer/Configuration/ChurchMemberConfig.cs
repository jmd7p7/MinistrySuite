using MinistrySuite.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchMemberConfig : EntityTypeConfiguration<ChurchMember>
    {
        public ChurchMemberConfig()
        {
            HasKey(cm => cm.Id);
            Property(cm => cm.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cm => cm.FirstName).HasMaxLength(50);
            Property(cm => cm.LastName).HasMaxLength(50);
            Property(cm => cm.DateOfBirth).IsOptional();

            Ignore(cm => cm.FullName);
            Ignore(cm => cm.GetPrimaryAddress);
            Ignore(cm => cm.GetPrimaryEmailAddress);
            Ignore(cm => cm.GetPrimaryPhoneNumber);

            HasRequired(cm => cm.Church)
                .WithMany(ch => ch.ChurchMembers)
                .HasForeignKey(cm => cm.ChurchId);
        }
    }
}
