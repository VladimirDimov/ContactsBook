﻿namespace ContactsBook.Domain.Exceptions
{
    public class InvalidAddressException : BaseDomainException
    {
        public InvalidAddressException()
        {
        }

        public InvalidAddressException(string error)
        {
            Error = error;
        }
    }
}
