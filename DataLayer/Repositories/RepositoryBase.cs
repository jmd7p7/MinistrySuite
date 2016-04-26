using MinistrySuite.Util;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLayer.Repositories
{
    public abstract class RepositoryBase<T, U> : IChurchDomainRepository<T> 
        where U : DbContext, new()
        where T : class, new()
    {
        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T GetExistingEntityFromUpdatedEntity(U entityContext, T entity);

        protected abstract ICollection<T> GetEntities(U entityContext, int churchId);

        protected abstract T GetEntityById(U entityContext, int id);
        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public ICollection<T> GetAll(int churchId)
        {
            using (U entityContext = new U())
            {
                return (GetEntities(entityContext, churchId)).ToArray().ToList();
            }
        }

        public T GetById(int id)
        {
            using (U entityContext = new U())
            {
                return GetEntityById(entityContext, id);
            }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntityById(entityContext, id);
                entityContext.Entry(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using(U entityContext = new U())
            {
                T existingEntity = GetExistingEntityFromUpdatedEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);

                entityContext.SaveChanges();
                return existingEntity;
            }
        }
    }
}
