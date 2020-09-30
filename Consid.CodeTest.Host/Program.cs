using System;
using Consid.CodeTest.Application.Services;

namespace Consid.CodeTest.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var ordinalNumbersService = new OrdinalNumbersService();
            var ordinalRepresentation = ordinalNumbersService.GetOrdinalRepresentation(21);

            Console.WriteLine($"Calculated ordinal representation of 21 is {ordinalRepresentation}. Expected was 21st");
            
            var creditMaskingService = new CreditCardService();
            var maskedCreditCardNumber = creditMaskingService.Maskify("5512-4543-4434-2333");
            Console.WriteLine($"Calculated masked credit number of 5512-4543-4434-2333 is {maskedCreditCardNumber}. Expected was 5###-####-####-2333");
        }
    }
}