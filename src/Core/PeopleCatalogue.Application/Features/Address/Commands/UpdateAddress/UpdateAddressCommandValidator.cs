using ContactsBook.Application.Features.Address.Commands.CreateAddress;
using FluentValidation;

namespace ContactsBook.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(m => m.ContactId)
                .NotEqual(0)
                .WithMessage($"{nameof(UpdateAddressCommand.ContactId)} is required");

            RuleFor(m => m.Title)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(m => m.Country)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(m => m.City)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(m => m.Street)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(m => m.Number)
                .MaximumLength(20);
        }
    }
}
