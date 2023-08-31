using MediatR;

namespace PeopleCatalogue.Application.Features.Person.Queries.GetAllPeople
{
    public record GetPersonDetailsQuery(int Id) : IRequest<PersonDetailsDto>;
}
