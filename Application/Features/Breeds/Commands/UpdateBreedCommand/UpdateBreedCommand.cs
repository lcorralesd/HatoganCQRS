using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Breeds.Commands.UpdateBreedCommand
{
    public class UpdateBreedCommand : IRequest<Response<UpdateBreedCommand>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
