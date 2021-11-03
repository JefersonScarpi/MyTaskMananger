using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChoreRepository
    {
        Task<IEnumerable<Chore>> GetChores();
        Task<Chore> GetById(int? id);

        //Task<Chore> GetChoreListIndex(int? id);



        Task<Chore> Create(Chore chore);
        Task<Chore> Update(Chore chore);
        Task<Chore> Remove(Chore chore);
    }
}
