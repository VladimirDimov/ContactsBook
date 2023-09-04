namespace ContactsBook.Domain.Exceptions
{
    public class InvalidContactException : BaseDomainException
    {
        public InvalidContactException()
        {
        }

        public InvalidContactException(string error)
        {
            Error = error;
        }
    }
}
