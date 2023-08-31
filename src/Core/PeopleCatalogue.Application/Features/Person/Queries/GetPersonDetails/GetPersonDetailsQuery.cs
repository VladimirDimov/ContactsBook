using MediatR;

namespace PeopleCatalogue.Application.Features.Person.Queries.GetPersonDetails
{
    public record GetPersonDetailsQuery(int Id) : IRequest<PersonDetailsDto>;
}
