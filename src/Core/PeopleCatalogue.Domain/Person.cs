namespace PeopleCatalogue.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Iban { get; set; }
    }
}
