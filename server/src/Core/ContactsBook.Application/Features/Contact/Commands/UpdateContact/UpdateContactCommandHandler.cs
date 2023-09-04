using AutoMapper;
using MediatR;
using ContactsBook.Application.Contracts.Persistence;

namespace ContactsBook.Application.Features.Contact.Commands.UpdateContact
{
    internal class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(
            IMapper mapper,
            IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Domain.Contact>(request);

            await _contactRepository.UpdateAsync(contact);

            return Unit.Value;
        }
    }
}
