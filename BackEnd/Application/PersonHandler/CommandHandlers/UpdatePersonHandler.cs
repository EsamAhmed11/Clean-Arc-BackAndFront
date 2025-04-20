using Application.IRepository;
using Application.PersonHandler.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonHandler.CommandHandlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePerson, Person>
{
    private readonly IPersonRepository _personRepository;


    public UpdatePersonHandler(IPersonRepository _personRepository)
    {
        this._personRepository = _personRepository;
    }


    public async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        return await _personRepository.UpdatePerson(request.updatePerson);
    }

};