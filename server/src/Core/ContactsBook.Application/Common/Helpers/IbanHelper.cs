using System.Text;
using ContactsBook.Application.Contracts.Helpers;

namespace ContactsBook.Application.Common.Helpers
{
    public class IbanHelper : IIbanHelper
    {
        public bool IsValidIban(string bankAccount)
        {
            if (string.IsNullOrEmpty(bankAccount) || bankAccount.Length < 4)
                return false;

            bankAccount = bankAccount.ToUpper();

            if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                if (bankAccount.Length < 4)
                    return false;

                bankAccount = bankAccount.Replace(" ", string.Empty);
                var bank = bankAccount[4..] + bankAccount[..4];
                var asciiShift = 55;
                var sb = new StringBuilder();

                foreach (var c in bank)
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

                for (var i = 1; i < checkSumString.Length; i++)
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
