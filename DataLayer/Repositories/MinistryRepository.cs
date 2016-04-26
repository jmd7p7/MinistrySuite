using System;
using System.Collections.Generic;
using EFDataLayer;
using EFDataLayer.Repositories;
using MinistrySuite.Entities;
using Repositories.Contracts;
using System.Linq;

namespace DataLayer.Repositories
{
    public class MinistryRepository : RepositoryBase<Ministry, ChurchContext>, IMinistryRepository
    {
        protected override Ministry AddEntity(ChurchContext entityContext, Ministry entity)
        {
            return entityContext.Ministries.Add(entity);
        }

        protected override ICollection<Ministry> GetEntities(ChurchContext entityContext, int churchId)
        {
            return entityContext.Ministries.Where(m => m.ChurchId == churchId).ToList();
        }

        protected override Ministry GetEntityById(ChurchContext entityContext, int id)
        {
            return entityContext.Ministries.Where(m => m.Id == id).FirstOrDefault();
        }

        protected override Ministry GetExistingEntityFromUpdatedEntity(ChurchContext entityContext, Ministry entity)
        {
            return entityContext.Ministries.Where(m => m.Id == entity.Id).FirstOrDefault();
        }
    }
}
