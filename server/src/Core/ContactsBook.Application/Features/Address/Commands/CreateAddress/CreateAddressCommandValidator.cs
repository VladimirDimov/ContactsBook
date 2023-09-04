using ContactsBook.Application.Features.Address.Commands.CreateAddress;
using ContactsBook.Domain.Common;
using FluentValidation;

using static ContactsBook.Domain.Common.DomainConstants;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(m => m.ContactId)
                .NotEqual(0)
                .WithMessage($"{nameof(CreateAddressCommand.ContactId)} is required");

            RuleFor(m => m.Title)
                .NotEmpty()
                .MaximumLength(AddressValidationConstants.AddressTitleMaxLength);

            RuleFor(m => m.Country)
                .NotEmpty()
                .MaximumLength(AddressValidationConstants.CountryMaxLength);

            RuleFor(m => m.City)
                .NotEmpty()
                .MaximumLength(AddressValidationConstants.CityMaxLength);

            RuleFor(m => m.Street)
                .NotEmpty()
                .MaximumLength(AddressValidationConstants.StreetLength);

            RuleFor(m => m.Number)
                .MaximumLength(AddressValidationConstants.NumberLength);
        }
    }
}
