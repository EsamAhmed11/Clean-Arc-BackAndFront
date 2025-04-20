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

public class DeletePersonHandler : IRequestHandler<DeletePerson,int>
{
    private readonly IPersonRepository _personRepository;


    public DeletePersonHandler(IPersonRepository _personRepository)
    {
        this._personRepository = _personRepository;
    }


    public async Task<int> Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        return await _personRepository.DeletePerson(request.personId);
    }

};
