using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IListIndexService
    {
        Task<IEnumerable<ListIndexDTO>> GetListIndexDTOs();
        Task<ListIndexDTO> GetById(int? id);
        Task Add(ListIndexDTO listIndexDTO);
        Task Update(ListIndexDTO listIndexDTO);
        Task Remove(int? id);


    }
}
