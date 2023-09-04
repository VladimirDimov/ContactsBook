using System.Text;
using FluentValidation;
using static ContactsBook.Domain.Common.DomainConstants;

namespace ContactsBook.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {

        public CreateContactCommandValidator()
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

                    return ValidateIban(iban);
                })
                .WithMessage("Invalid IBAN format.");
        }

        private bool ValidateIban(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper();

            if (string.IsNullOrEmpty(bankAccount))
                return false;

            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", string.Empty);
                var bank = bankAccount[4..] + bankAccount[..4];
                var asciiShift = 55;
                var sb = new StringBuilder();

                foreach (char c in bank)
                {
                    int v;

                    if (char.IsLetter(c))
                        v = c - asciiShift;
                    else
                        v = int.Parse(c.ToString());

                    sb.Append(v);
                }

                var checkSumString = sb.ToString();
                var checksum = int.Parse(checkSumString[..1]);

                for (int i = 1; i < checkSumString.Length; i++)
                {
                    var v = int.Parse(checkSumString.Substring(i, 1));

                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }

                return checksum == 1;
            }
            else
                return false;
        }
    }
}
