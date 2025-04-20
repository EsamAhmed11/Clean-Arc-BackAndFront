using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Person { get; set; }
};