using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Queries.GetBreedById
{
    public class GetBreedByIdQuery : IRequest<Response<BreedDto>>
    {
        public GetBreedByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
