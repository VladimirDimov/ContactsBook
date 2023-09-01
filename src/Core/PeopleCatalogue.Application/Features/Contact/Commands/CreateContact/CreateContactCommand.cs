using MediatR;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Iban { get; set; }
    }
}
