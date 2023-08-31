using MediatR;

namespace ContactsBook.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<Unit>
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
