using MinistrySuite.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDataLayer.Configuration
{
    public class ChurchConfig : EntityTypeConfiguration<Church>
    {
        public ChurchConfig()
        {
            HasKey(ch => ch.Id);
            Property(ch => ch.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Ignore(ch => ch.GetPrimaryAddress);
            Ignore(ch => ch.GetPrimaryEmailAddress);
            Ignore(ch => ch.GetPrimaryPhoneNumber);
        }
    }
}
