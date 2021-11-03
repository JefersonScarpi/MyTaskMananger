using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ListIndexService : IListIndexService

    {
        private readonly IListIndexRepository _listIndexRepository;
        private readonly IMapper _mapper;
        public ListIndexService(IListIndexRepository listIndexRepository, IMapper mapper)
        {
            _listIndexRepository = listIndexRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListIndexDTO>> GetListIndexDTOs()
        {
            var listIndexesEntity = await _listIndexRepository.GetListIndexes();
            return _mapper.Map<IEnumerable<ListIndexDTO>>(listIndexesEntity);
        }
        public async Task<ListIndexDTO> GetById(int? id)
        {
            var listIndexEntity = await _listIndexRepository.GetById(id);
            return _mapper.Map<ListIndexDTO>(listIndexEntity);
        }


        public async Task Add(ListIndexDTO listIndexDTO)
        {
            var listIndexesEntity = _mapper.Map<ListIndex>(listIndexDTO);
            await _listIndexRepository.Create(listIndexesEntity);
        }
        

        public async Task Update(ListIndexDTO listIndexDTO)        {
            
                 var listIndexesEntity = _mapper.Map<ListIndex>(listIndexDTO);
            await _listIndexRepository.Update(listIndexesEntity);
        }

        public async Task Remove(int? id)
        {
            var listIndexesEntity = _listIndexRepository.GetById(id).Result;
            await _listIndexRepository.Remove(listIndexesEntity);
        }
    }
}
