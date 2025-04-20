
using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonDbContext _context;

    public PersonRepository(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Person> AddPerson(Person personToCreate)
    {
       var personCreated=  _context.Person.Add(personToCreate);
        int result= await _context.SaveChangesAsync();
        if (result > 0)
            return personCreated.Entity;
        else
            return null;
    }

    public async Task<int> DeletePerson(int personId)
    {
        var person = _context.Person
            .FirstOrDefault(p => p.Id == personId);

        if (person is null) return -1;

        _context.Person.Remove(person);

       return await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Person>> GetAll()
    {
        return await _context.Person.ToListAsync();
    }

    public async Task<Person> GetPersonById(int personId)
    {
        return await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
    }

    public async Task<Person> UpdatePerson(Person person)
    {
       var updatePerson=  _context.Update(person);
       int result= await _context.SaveChangesAsync();
        if(result> 0)
           return person;
        else
           return null;
    }
};