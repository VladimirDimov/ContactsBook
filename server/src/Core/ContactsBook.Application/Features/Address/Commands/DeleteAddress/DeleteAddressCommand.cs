using MediatR;

namespace ContactsBook.Application.Features.Address.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<Unit>
    {
        public DeleteAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
