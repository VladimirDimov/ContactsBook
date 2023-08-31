namespace PeopleCatalogue.Application.Features.Person.Queries.GetAllPeople
{
    public class PersonDetailsDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Iban { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
