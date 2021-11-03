using Application.Chores.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Chores.Handlers
{
    class GetChoreByIdQueryHandler : IRequestHandler<GetChoreByIdQuery, Chore>
    {
        private IChoreRepository _choreRepository;
        public GetChoreByIdQueryHandler(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository ??
            throw new ArgumentNullException(nameof(choreRepository));
        }

        public async Task<Chore> Handle(GetChoreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _choreRepository.GetById(request.Id);
            
        }
    }
}
