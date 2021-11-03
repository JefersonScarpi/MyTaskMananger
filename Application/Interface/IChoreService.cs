using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IChoreService
    {
        Task<IEnumerable<ChoreDTO>> GetChoresDTOs();
        Task<ChoreDTO> GetById(int? id);
        //Task<ChoreDTO> GetChoreListIndex(int? id);


        Task Add(ChoreDTO choreDTO);
        Task Update(ChoreDTO choreDTO);
        Task Remove(int? id);
    }
}
