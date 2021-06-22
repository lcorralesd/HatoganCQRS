using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Queries.GetAllBreeds
{
    public class GetAllBreedsQueryHandler : IRequestHandler<GetAllBreedsQuery, PageResponse<List<BreedDto>>>
    {
        private readonly IRepositoryAsync<Breed> _breedRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetAllBreedsQueryHandler(IRepositoryAsync<Breed> breedRepository, IMapper mapper, IDistributedCache distributedCache)
        {
            _breedRepository = breedRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<PageResponse<List<BreedDto>>> Handle(GetAllBreedsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"breedsList_{request.PageNumber}_{request.PageSize}_{request.Name}";
            string serializedBreedsList;
            var breedsList = new List<Breed>();
            var redisBreedsList = await _distributedCache.GetAsync(cacheKey);

            if(redisBreedsList is not null)
            {
                serializedBreedsList = Encoding.UTF8.GetString(redisBreedsList);
                breedsList = JsonSerializer.Deserialize<List<Breed>>(serializedBreedsList);
            }
            else
            {
                breedsList = await _breedRepository.ListAsync(new PagedBreedsSpecification(request.PageNumber, request.PageSize, request.Name));
                serializedBreedsList = JsonSerializer.Serialize<List<Breed>>(breedsList);
                redisBreedsList = Encoding.UTF8.GetBytes(serializedBreedsList);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisBreedsList, options);
            }
            var resultDtos = _mapper.Map<List<BreedDto>>(breedsList);

            return new PageResponse<List<BreedDto>>(resultDtos, request.PageNumber, request.PageSize);
        }
    }
}
