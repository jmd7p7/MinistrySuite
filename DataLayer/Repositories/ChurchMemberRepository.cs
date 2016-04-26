using MinistrySuite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Repositories.Contracts;

namespace EFDataLayer.Repositories
{
    public class ChurchMemberRepository : RepositoryBase<ChurchMember, ChurchContext>, IChurchMemberRepository
    {
        protected override ChurchMember AddEntity(ChurchContext entityContext, ChurchMember entity)
        {
            return entityContext.ChurchMemebrs.Add(entity);
        }

        protected override ICollection<ChurchMember> GetEntities(ChurchContext entityContext, int churchId)
        {
            return entityContext.ChurchMemebrs.Where(cm => cm.ChurchId == churchId).ToList();
        }

        protected override ChurchMember GetEntityById(ChurchContext entityContext, int id)
        {
            return entityContext.ChurchMemebrs.Where(cm => cm.Id == id).FirstOrDefault();
        }

        protected override ChurchMember GetExistingEntityFromUpdatedEntity(ChurchContext entityContext, ChurchMember entity)
        {
            return entityContext.ChurchMemebrs.Where(cm => cm.Id == entity.Id).FirstOrDefault();
        }
    }
}
