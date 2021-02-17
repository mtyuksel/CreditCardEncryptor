using System;

namespace CreditCardEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            bool work = true;
            while (work)
            {
                Console.WriteLine("Enter your card number: ");
                var cardNumber = Console.ReadLine();

                try
                {
                    string encryptedCardNumber = CreditCardEncrypt.RunProcess(cardNumber);
                    Console.WriteLine("Your encrypted card number: " + encryptedCardNumber);
                    Console.ReadKey();
                    work = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }
            }
        }
    }   
}
