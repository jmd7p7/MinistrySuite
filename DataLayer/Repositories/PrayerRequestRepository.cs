using EFDataLayer;
using EFDataLayer.Repositories;
using MinistrySuite.Entities;
using System;
using System.Collections.Generic;
using Repositories.Contracts;
using System.Linq;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class PrayerRequestRepository : RepositoryBase<PrayerRequest, ChurchContext>, IPrayerRequestRepository
    {
        public ICollection<PrayerRequest> GetByDateRangeAndChurchId(DateTimeOffset startDateMin, DateTimeOffset startDateMax, int ChurchId)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                return entityContext.PrayerRequests.Where(pr => 
                    pr.ChurchId == ChurchId && 
                    pr.StartDate >= startDateMin && 
                    pr.StartDate <= startDateMax)
                .ToList();
            } 
        }

        public ICollection<PrayerRequest> GetByDateRangeAndMinistryId(DateTimeOffset startDateMin, DateTimeOffset startDateMax, int ministryId)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                 return entityContext.Ministries
                    .Where(m => m.Id == ministryId)
                    .Include(m => m.PrayerRequests)
                    .FirstOrDefault()
                    .PrayerRequests
                    .Where(pr=> pr.StartDate >= startDateMin && pr.StartDate <= startDateMax)
                    .ToList();

            }
        }

        public PrayerRequest GetByIdWithUpdates(int prayerRequestId)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                return entityContext.PrayerRequests
                    .Where(pr => pr.Id == prayerRequestId)
                    .Include(pr => pr.Updates)
                    .FirstOrDefault();
            }
        }

        protected override PrayerRequest AddEntity(ChurchContext entityContext, PrayerRequest entity)
        {
            return entityContext.PrayerRequests.Add(entity);
        }

        protected override ICollection<PrayerRequest> GetEntities(ChurchContext entityContext, int churchId)
        {
            return entityContext.PrayerRequests.Where(pr => pr.ChurchId == churchId).ToList();
        }

        protected override PrayerRequest GetEntityById(ChurchContext entityContext, int id)
        {
            return entityContext.PrayerRequests.Where(pr => pr.Id == id).FirstOrDefault();
        }

        protected override PrayerRequest GetExistingEntityFromUpdatedEntity(ChurchContext entityContext, PrayerRequest entity)
        {
            return entityContext.PrayerRequests.Where(pr => pr.Id == entity.Id).FirstOrDefault();
        }
    }
}
