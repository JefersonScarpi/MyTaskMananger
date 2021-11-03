using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chores.Commands
{
    class ChoreRemoveCommand : IRequest<Chore>
    {
        public int Id { get; set; }
        public ChoreRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
