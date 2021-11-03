using Application.Chores.Commands;
using Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ChoreDTO, ChoreCreateCommand>();
            CreateMap<ChoreDTO, ChoreUpdateCommand>();
        }
    }
}
