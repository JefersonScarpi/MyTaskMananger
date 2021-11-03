using Application.Chores.Commands;
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
    class ChoreCreateCommandHandler : IRequestHandler<ChoreCreateCommand, Chore>
    {
        private readonly IChoreRepository _choreRepository;
        public ChoreCreateCommandHandler(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository ??
            throw new ArgumentNullException(nameof(choreRepository));
        }
        public async Task<Chore> Handle(ChoreCreateCommand request, CancellationToken cancellationToken)
        {
            var chore = new Chore(request.Title,request.Description,request.Complete);

            if (chore == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                chore.ListIndexId = request.ListIndexId;
                return await _choreRepository.Create(chore);
            }
        }
    }
}
