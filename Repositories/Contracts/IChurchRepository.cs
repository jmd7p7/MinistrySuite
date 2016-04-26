using MinistrySuite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IChurchRepository
    {
        Church GetById(int churchId);
        ICollection<Church> GetAll();
        Church Add(Church church);
        Church Update(Church church);
        void Remove(int churchId);
        void Remove(Church church);
        
    }
}
