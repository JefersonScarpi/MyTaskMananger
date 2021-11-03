using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class ChoreRepository : IChoreRepository
    {
        ApplicationDbContext _ChoreContext;
        public ChoreRepository(ApplicationDbContext context)
        {
            _ChoreContext = context;
        }

        public async Task<Chore> Create(Chore chore)
        {
            _ChoreContext.Add(chore);
            await _ChoreContext.SaveChangesAsync();
            return chore;
        }

        public async Task<Chore> GetById(int? id)
        {
            //return await _ChoreContext.Chores.FindAsync(id);
            return await _ChoreContext.Chores.Include(c => c.ListIndex)
               .SingleOrDefaultAsync(p => p.Id == id);
        }

        //public async Task<Chore> GetChoreListIndex(int? id)
        //{
        //    return await _ChoreContext.Chores.Include(c => c.ListIndex)
        //        .SingleOrDefaultAsync(p => p.Id == id);

        //}

        public async Task<IEnumerable<Chore>> GetChores()
        {
            return await _ChoreContext.Chores.ToListAsync();
        }

        public async Task<Chore> Remove(Chore chore)
        {
            _ChoreContext.Remove(chore);
            await _ChoreContext.SaveChangesAsync();
            return chore;
        }

        public async Task<Chore> Update(Chore chore)
        {
            _ChoreContext.Update(chore);
            await _ChoreContext.SaveChangesAsync();
            return chore;
        }
    }
}
