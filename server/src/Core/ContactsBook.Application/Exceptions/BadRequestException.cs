using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace ContactsBook.Application.Exceptions
{
    internal class BadRequestException : Exception
    {
        public BadRequestException(string message, ValidationResult validationResult)
            : base(message)
        {
            ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }

        public List<string> ValidationErrors { get; }
    }
}
