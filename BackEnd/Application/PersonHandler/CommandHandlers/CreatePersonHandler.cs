
using Application.IRepository;
using Application.PersonHandler.Commands;
using Domain.Entities;
using MediatR;

namespace Application.PersonHandler.CommandHandlers;

public class CreatePersonHandler : IRequestHandler<CreatePerson, Person>
{
    private readonly IPersonRepository _personRepository;


    public CreatePersonHandler(IPersonRepository _personRepository)
    {
        this._personRepository = _personRepository;
    }


    public async Task<Person> Handle(CreatePerson request, CancellationToken cancellationToken)
    {
        return await _personRepository.AddPerson(request.person);
    }
};