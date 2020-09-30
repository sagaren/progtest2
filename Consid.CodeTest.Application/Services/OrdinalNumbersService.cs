using System;
using System.Collections.Generic;
namespace Consid.CodeTest.Application.Services
{
    public class OrdinalNumbersService
    {
        public string GetOrdinalRepresentation(int number)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            if (lastTwoDigits == 11 || lastTwoDigits == 12 || lastTwoDigits == 13)
            {
                return number + "th";
            }

            return lastDigit switch
            {
                1 => number + "st",
                2 => number + "nd",
                3 => number + "rd",
                _ => number + "th",
            };
        }
    }
}