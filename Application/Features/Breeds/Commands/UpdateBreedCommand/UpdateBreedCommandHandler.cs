using Application.Exceptions;
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

namespace Application.Features.Breeds.Commands.UpdateBreedCommand
{
    public class UpdateBreedCommandHandler : IRequestHandler<UpdateBreedCommand, Response<UpdateBreedCommand>>
    {
        private readonly IRepositoryAsync<Breed> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateBreedCommandHandler(IRepositoryAsync<Breed> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<UpdateBreedCommand>> Handle(UpdateBreedCommand request, CancellationToken cancellationToken)
        {
            var breed = await _repositoryAsync.GetByIdAsync(request.Id);

            if(breed is null)
            {
                throw new KeyNotFoundException($"Registro con id: {request.Id} no se encontro");
            }

            var recordToUpdate = _mapper.Map<Breed>(request);
            
            await _repositoryAsync.UpdateAsync(recordToUpdate);
            var response = _mapper.Map<UpdateBreedCommand>(recordToUpdate);

            return new Response<UpdateBreedCommand>(response, message: "El registro fue actualizado exitosamente");
        }
    }
}
