using MediatR;

namespace PeopleCatalogue.Application.Features.Person.Queries.GetAllPeople
{
    public record GetPeopleQuery : IRequest<List<PersonDto>>;
}
