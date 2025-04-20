using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonHandler.Commands
{
    public class DeletePerson : IRequest<int>
    {
        public int personId { get; set; }
    };
}
