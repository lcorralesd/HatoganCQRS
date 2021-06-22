using Application.DTOs;
using Application.Features.Breeds.Commands.CreateBreedCommand;
using Application.Features.Breeds.Commands.UpdateBreedCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Commands
            CreateMap<CreateBreedCommand, Breed>();
            CreateMap<UpdateBreedCommand, Breed>().ReverseMap();

            // DTOs
            CreateMap<Breed, BreedDto>();
        }
    }
}
