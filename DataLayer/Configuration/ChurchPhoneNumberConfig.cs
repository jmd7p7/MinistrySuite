using MinistrySuite.SecondaryEntities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchPhoneNumberConfig : EntityTypeConfiguration<ChurchPhoneNumber>
    {
        public ChurchPhoneNumberConfig()
        {
            HasKey(cpn => cpn.Id);
            Property(cpn => cpn.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(cpn => cpn.Number).HasMaxLength(10);
            Ignore(cpn => cpn.GetFormattedNumber);

            Map(m => m.MapInheritedProperties());

            HasRequired(cpn => cpn.Church)
                .WithMany(ch => ch.PhoneNumbers)
                .HasForeignKey(cpn => cpn.ChurchId);
        }
    }
}
