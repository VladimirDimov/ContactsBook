using MediatR;

namespace ContactsBook.Application.Features.Person.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
