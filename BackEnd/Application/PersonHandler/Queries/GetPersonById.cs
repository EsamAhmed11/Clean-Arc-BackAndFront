using Domain.Entities;
using MediatR;

namespace Application.PersonHandler.Queries;

public class GetPersonById : IRequest<Person>
{
    public int Id { get; set; }
};