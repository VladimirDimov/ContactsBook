namespace ContactsBook.Application.Contracts.Helpers
{
    public interface IIbanHelper
    {
        bool IsValidIban(string bankAccount);
    }
}