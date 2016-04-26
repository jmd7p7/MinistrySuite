using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IChurchDomainRepository<T>
    {
        T GetById(int id);
        ICollection<T> GetAll(int churchId);
        void Remove(int id);
        void Remove(T entity);
        T Add(T entity);
        T Update(T entity);
    }
}
