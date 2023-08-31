using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace PeopleCatalogue.Application.Features.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Iban { get; set; }
    }
}
