using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class ListIndexRepository : IListIndexRepository        
    {
        ApplicationDbContext _ListIndexContext;
        public ListIndexRepository(ApplicationDbContext context)
        {
            _ListIndexContext = context;
        }

        public async Task<ListIndex> Create(ListIndex listIndex)
        {
             _ListIndexContext.Add(listIndex);
            await _ListIndexContext.SaveChangesAsync();
            return listIndex;
        }

        public async Task<ListIndex> GetById(int? id)
        {
            return await _ListIndexContext.ListIndexes.FindAsync(id);
        }

        public async Task<IEnumerable<ListIndex>> GetListIndexes()
        {
            return await _ListIndexContext.ListIndexes.ToListAsync();
        }

        public async Task<ListIndex> Remove(ListIndex listIndex)
        {
            _ListIndexContext.Remove(listIndex);
            await _ListIndexContext.SaveChangesAsync();
            return listIndex;
        }

        public async Task<ListIndex> Update(ListIndex listIndex)
        {
            _ListIndexContext.Update(listIndex);
            await _ListIndexContext.SaveChangesAsync();
            return listIndex;
        }
    }
}
