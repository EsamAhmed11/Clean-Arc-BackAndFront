using Domain.Entities;
using MediatR;
using System;

namespace Application.PersonHandler.Commands;

public class CreatePerson : IRequest<Domain.Entities.Person>
{
    public Person person { get; set; }
};