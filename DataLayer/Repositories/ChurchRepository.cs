using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinistrySuite.Entities;
using EFDataLayer;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class ChurchRepository : IChurchRepository
    {
        public Church Add(Church church)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                Church addedEntity = entityContext.Churches.Add(church);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public ICollection<Church> GetAll()
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                return entityContext.Churches.ToList();
            }
        }

        public Church GetById(int churchId)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                return entityContext.Churches.Where(c => c.Id == churchId).FirstOrDefault();
            }
        }

        public void Remove(Church church)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                entityContext.Entry(church).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int churchId)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                Church entityToDelete = entityContext.Churches.Where(c => c.Id == churchId).FirstOrDefault();
                entityContext.Entry(entityToDelete).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public Church Update(Church church)
        {
            using (ChurchContext entityContext = new ChurchContext())
            {
                entityContext.Entry(church).State = EntityState.Modified;
                entityContext.SaveChanges();
                return entityContext.Churches.Where(c => c.Id == church.Id).FirstOrDefault();
            }
        }
    }
}
