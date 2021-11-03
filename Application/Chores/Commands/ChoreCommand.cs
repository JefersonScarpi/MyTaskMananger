using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chores.Commands
{
    public abstract class ChoreCommand : IRequest<Chore>
    {
        public int Id { get; set; }        
        public string Title { get; private set; }        
        public string Description { get; private set; }

        public bool Complete { get; private set; }

        public int ListIndexId { get; set; }
        
    }
}
