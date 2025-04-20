using Application.IRepository;
using Application.PersonHandler.Queries;
using Domain.Entities;
using MediatR;

namespace Application.PersonHandler.QueryHandlers
{
    public class GetAllPersonsHandler : IRequestHandler<GetAllPersons, ICollection<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ICollection<Person>> Handle(GetAllPersons request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetAll();
        }
    }
}
