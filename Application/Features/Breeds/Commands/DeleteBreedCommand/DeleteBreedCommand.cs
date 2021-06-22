using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Commands.DeleteBreedCommand
{
    public class DeleteBreedCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
