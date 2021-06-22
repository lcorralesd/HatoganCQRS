using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Commands.DeleteBreedCommand
{
    public class DeleteBreedCommandHandler : IRequestHandler<DeleteBreedCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Breed> _repositoryAsync;

        public DeleteBreedCommandHandler(IRepositoryAsync<Breed> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteBreedCommand request, CancellationToken cancellationToken)
        {
            var recordToDelete = await _repositoryAsync.GetByIdAsync(request.Id);

            if(recordToDelete is null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con Id: {request.Id}");
            }

            await _repositoryAsync.DeleteAsync(recordToDelete);

            return new Response<int>(recordToDelete.Id, message:"Registro borrado exitosamente");
        }
    }
}
