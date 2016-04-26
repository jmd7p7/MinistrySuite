using MinistrySuite.Entities;
using MinistrySuite.SecondaryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPrayerRequestRepository : IChurchDomainRepository<PrayerRequest>
    {
        ICollection<PrayerRequest> GetByDateRangeAndChurchId(DateTimeOffset startDateMin, 
            DateTimeOffset startDateMax, int ChurchId);
        ICollection<PrayerRequest> GetByDateRangeAndMinistryId(DateTimeOffset startDateMin, 
            DateTimeOffset startDateMax, int ministryId);
        PrayerRequest GetByIdWithUpdates(int prayerRequestId);

    }
}
