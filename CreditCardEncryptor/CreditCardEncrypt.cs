using System;
using System.Text;
using System.Text.RegularExpressions;
using static CreditCardEncryptor.Exceptions;

namespace CreditCardEncryptor
{
    class CreditCardEncrypt
    {
        public static string RunProcess(string cardNumber)
        {
            cardNumber = Cleaner(cardNumber);

            if (!Validator(cardNumber))
            {
                throw new CreditCardNotValidException();
            }

            return Encryptor(cardNumber);
        }

        private static bool Validator(string cardNumber)
        {
            if (cardNumber.Length < 16 || cardNumber.Length > 20)
            {
                throw new CreditCardMissingNumbersException();
            }

            string regex = @"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$";

            return Regex.Match(cardNumber, regex).Success;
        }

        private static string Cleaner(string cardNumber)
        {
            return cardNumber.Replace(" ", "").Replace("-", "").Replace(".", "").Replace("/", "");
        }

        private static string Encryptor(string cardNumber)
        {
            StringBuilder stringBuilder = new StringBuilder(cardNumber);
            stringBuilder.Remove(0, 4).Insert(0, "XXXX");
            stringBuilder.Remove(cardNumber.Length - 4, 4).Insert(cardNumber.Length - 4, "XXXX");

            return stringBuilder.ToString();
        }
    }
}
