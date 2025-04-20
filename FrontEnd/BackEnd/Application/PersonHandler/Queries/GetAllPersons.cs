using MediatR;
using Domain.Entities; // Or wherever Person is defined
using System.Collections.Generic;

namespace Application.PersonHandler.Queries
{
    public class GetAllPersons : IRequest<ICollection<Person>>
    {
    }
}
