using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonHandler.Commands
{
    public class UpdatePerson : IRequest<Person>
    {
        public Person updatePerson { get; set; }
    };
}
