
using Application.IRepository;
using Application.PersonHandler.Queries;
using Domain.Entities;
using MediatR;

namespace Application.PersonHandler.QueryHandlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Person>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
        return await _personRepository. GetPersonById(request.Id);
    }
};