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
    class ChoreRemoveCommandHandler : IRequestHandler<ChoreRemoveCommand, Chore>
    {
        private IChoreRepository _choreRepository;
        public ChoreRemoveCommandHandler(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository ??
            throw new ArgumentNullException(nameof(choreRepository));
        }

        public async Task<Chore> Handle(ChoreRemoveCommand request, CancellationToken cancellationToken)
        {
            var chore = await _choreRepository.GetById(request.Id);

            if (chore == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _choreRepository.Remove(chore);
                return result;
            }
        }
    }
}
