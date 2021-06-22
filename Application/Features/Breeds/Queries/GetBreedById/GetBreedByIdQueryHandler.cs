using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace Application.Features.Breeds.Queries.GetBreedById
{
    public class GetBreedByIdQueryHandler : IRequestHandler<GetBreedByIdQuery, Response<BreedDto>>
    {
        private readonly IRepositoryAsync<Breed> _breedRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetBreedByIdQueryHandler(IRepositoryAsync<Breed> breedRepositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            _breedRepositoryAsync = breedRepositoryAsync;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<Response<BreedDto>> Handle(GetBreedByIdQuery request, CancellationToken cancellationToken)
        {
            var breed = await _breedRepositoryAsync.GetByIdAsync(request.Id);

            if(breed is null)
            {
                throw new KeyNotFoundException($"No se encontro un registro con Id: {request.Id}");
            }

            var result = _mapper.Map<BreedDto>(breed);

            return new Response<BreedDto>(result);
        }
    }
}
