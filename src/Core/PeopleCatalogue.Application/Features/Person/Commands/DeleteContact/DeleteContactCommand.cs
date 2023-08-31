using MediatR;

namespace ContactsBook.Application.Features.Person.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public DeleteContactCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
