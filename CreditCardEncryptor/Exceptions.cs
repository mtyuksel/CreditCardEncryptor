using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardEncryptor
{
    public class Exceptions
    {
        public class CreditCardNotValidException : Exception
        {
            public override string Message => "The card number is incorrect!";
        }

        public class CreditCardMissingNumbersException : Exception
        {
            public override string Message => "Card number must be 16 to 20 characters.";
        }
    }
}
