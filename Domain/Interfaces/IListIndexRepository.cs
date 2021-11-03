using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IListIndexRepository
    {
        Task<IEnumerable<ListIndex>> GetListIndexes();
        Task<ListIndex> GetById(int? id);
        Task<ListIndex> Create(ListIndex listIndex);
        Task<ListIndex> Update(ListIndex listIndex);
        Task<ListIndex> Remove(ListIndex listIndex);
        

    }
}
