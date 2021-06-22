using Application.Features.Breeds.Commands.CreateBreedCommand;
using Application.Features.Breeds.Commands.DeleteBreedCommand;
using Application.Features.Breeds.Commands.UpdateBreedCommand;
using Application.Features.Breeds.Queries.GetAllBreeds;
using Application.Features.Breeds.Queries.GetBreedById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BreedsController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetBreeds([FromQuery]GetAllBreedsParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllBreedsQuery 
            { 
                Name = filter.Name,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize 
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed(int id)
        {
            return Ok(await Mediator.Send(new GetBreedByIdQuery(id)));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostBreed(CreateBreedCommand breedCommand)
        {
            return Ok(await Mediator.Send(breedCommand));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBreed(int id, UpdateBreedCommand updateBreed)
        {
            return Ok(await Mediator.Send(updateBreed));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            return Ok(await Mediator.Send(new DeleteBreedCommand { Id = id }));
        }
    }
}
