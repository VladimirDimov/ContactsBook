using System.Text;
using ContactsBook.Application.Common.Helpers;
using ContactsBook.Application.Contracts.Helpers;
using ContactsBook.Application.Features.Contact.Commands.CreateContact;
using FluentValidation;

using static ContactsBook.Domain.Common.DomainConstants;

namespace ContactsBook.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {

        public UpdateContactCommandValidator(IIbanHelper ibanHelper)
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MinimumLength(ContactValidationConstants.FirstNameMinLength)
                .MaximumLength(ContactValidationConstants.FirstNameMaxLength);

            RuleFor(m => m.LastName)
                .NotEmpty()
                .MinimumLength(ContactValidationConstants.LastNameMinLength)
                .MaximumLength(ContactValidationConstants.LastNameMaxLength);

            RuleFor(m => m.PhoneNumber)
                .NotEmpty()
                .MaximumLength(ContactValidationConstants.PhoneNumberMaxLength);

            RuleFor(m => m.Iban)
                .MaximumLength(ContactValidationConstants.IbanMaxLength);

            RuleFor(m => m.Iban)
                .MinimumLength(ContactValidationConstants.IbanMinLength)
                .Must(iban =>
                {
                    if (string.IsNullOrEmpty(iban))
                        return true;

                    return ibanHelper.IsValidIban(iban);
                })
                .WithMessage("Invalid IBAN format.");
        }
    }
}
