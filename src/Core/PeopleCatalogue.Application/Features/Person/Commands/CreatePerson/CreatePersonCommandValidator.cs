﻿using System.Text;
using FluentValidation;

namespace PeopleCatalogue.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(m => m.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(m => m.PhoneNumber)
                .MaximumLength(20);

            RuleFor(m => m.Address)
                .MaximumLength(200);

            RuleFor(m => m.Iban)
                .MaximumLength(34);

            RuleFor(m => m.Iban)
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

            if (String.IsNullOrEmpty(bankAccount))
                return false;

            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();

                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c))
                        v = c - asciiShift;
                    else
                        v = int.Parse(c.ToString());
                    sb.Append(v);
                }

                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));

                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
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
