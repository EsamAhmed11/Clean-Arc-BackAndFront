using Application.DTOs;
using Application.PersonHandler.Commands;
using Application.PersonHandler.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PersonController(IMediator mediator, IMapper mapper)
        {
            _mediator=mediator;
            _mapper = mapper;
        }
        [HttpGet("GetById")]
        public async Task<IResult> GetById(int id)
        {
            var getPerson = new GetPersonById { Id = id };
            var person = await _mediator.Send(getPerson);

            return TypedResults.Ok(person);
        }
        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var getAllPersons = new GetAllPersons ();
            var person = await _mediator.Send(getAllPersons);

            return TypedResults.Ok(person);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(PersonDTO personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            var createPerson = new CreatePerson {  person = person };
            var result = await _mediator.Send(createPerson);

            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(PersonDTO personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            var updatePerson = new UpdatePerson {  updatePerson = person };
            var result = await _mediator.Send(updatePerson);

            return Ok(person);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePerson = new DeletePerson {  personId = id };
            var result = await _mediator.Send(deletePerson);

            return Ok(result);
        }
    }
}
