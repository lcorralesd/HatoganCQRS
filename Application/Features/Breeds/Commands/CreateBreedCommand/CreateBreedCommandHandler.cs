using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Commands.CreateBreedCommand
{
    public class CreateBreedCommandHandler : IRequestHandler<CreateBreedCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Breed> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateBreedCommandHandler(IRepositoryAsync<Breed> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBreedCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Breed>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id, message:"Fue creado exitosamente el registro");
        }
    }
}
