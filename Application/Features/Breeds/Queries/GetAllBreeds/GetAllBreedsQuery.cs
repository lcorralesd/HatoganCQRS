using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Queries.GetAllBreeds
{
    public class GetAllBreedsQuery : IRequest<PageResponse<List<BreedDto>>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string Name { get; set; }
    }
}
