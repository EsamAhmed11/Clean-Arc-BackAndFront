using Domain.Entities;

namespace Application.IRepository
{
    public interface IPersonRepository
    {
        Task<ICollection<Person>> GetAll();

        Task<Person> GetPersonById(int personId);

        Task<Person> AddPerson(Person toCreate);

        Task<Person> UpdatePerson(Person person);

        Task<int> DeletePerson(int personId);
    };
}
