using MediatR;

namespace ContactsBook.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public int ContactId { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string? Number { get; set; }
    }
}
