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
    public class ChoreUpadeCommandHandler : IRequestHandler<ChoreUpdateCommand, Chore>
    {
        private IChoreRepository _choreRepository;
        public ChoreUpadeCommandHandler(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository ??
            throw new ArgumentNullException(nameof(choreRepository));
        }

        public async Task<Chore> Handle(ChoreUpdateCommand request, CancellationToken cancellationToken)
        {
            var chore = await _choreRepository.GetById(request.Id);

            if (chore == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                chore.Update(request.Title, request.Description, request.ListIndexId, request.Complete);
                return await _choreRepository.Update(chore);
            }
        }
    }
}
