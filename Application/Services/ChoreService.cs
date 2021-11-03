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
using MediatR;
using Application.Chores.Queries;
using Application.Chores.Commands;

namespace Application.Services
{
    public class ChoreService : IChoreService
    {
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ChoreService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ChoreDTO>> GetChoresDTOs()
        {
            
            var choresQuery = new GetChoresQuery();
            if (choresQuery == null)
                throw new Exception($"Entity could not be loaded.");
            var result = await _mediator.Send(choresQuery);
            return _mapper.Map<IEnumerable<ChoreDTO>>(result);

        }

        public async Task<ChoreDTO> GetById(int? id)
        {
            var choreByIdQuery = new GetChoreByIdQuery(id.Value);
            if (choreByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");
            var result = await _mediator.Send(choreByIdQuery);
            return _mapper.Map<ChoreDTO>(result);
        }
        //public async Task<ChoreDTO> GetChoreListIndex(int? id)
        //{
        //    var choreByIdQuery = new GetChoreByIdQuery(id.Value);
        //    if (choreByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded.");
        //    var result = await _mediator.Send(choreByIdQuery);
        //    return _mapper.Map<ChoreDTO>(result);

        //}

        public async Task Add(ChoreDTO choreDTO)
        {
            var choreCreateCommand = _mapper.Map<ChoreCreateCommand>(choreDTO);
            await _mediator.Send(choreCreateCommand);

        }

        public async Task Update(ChoreDTO choreDTO)
        {
            var choreUpdateCommand = _mapper.Map<ChoreUpdateCommand>(choreDTO);
            await _mediator.Send(choreUpdateCommand);

        }


        public async Task Remove(int? id)
        {
            var choreRemoveCommand = new ChoreRemoveCommand(id.Value);
            if(choreRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");
            await _mediator.Send(choreRemoveCommand);

        }




    }
}
