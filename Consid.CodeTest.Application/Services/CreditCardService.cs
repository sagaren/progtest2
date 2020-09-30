using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Consid.CodeTest.Application.Services
{
    public class CreditCardService
    {
        /// <summary>
        /// Ta in ett kreditkortsnummer och maskerat de enligt reglerna men inte maskera bindestreck. Inte maskera om det finns bokstäver.  
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns>Maskerat kreditkortsnummer</returns>
        public string Maskify(string creditCardNumber)
        {
            if (creditCardNumber.Any(x => char.IsLetter(x)))
            {
                return creditCardNumber;
            }

            else if (creditCardNumber == "")
            {
                return string.Empty;
            }

            else if (creditCardNumber.Length < 6)
            {
                return creditCardNumber;
            }

                if (creditCardNumber.Contains('-'))
                {
                    StringBuilder numbersHyphen = new StringBuilder(creditCardNumber);
                    numbersHyphen.Replace("-", "");

                    var maskedNoHyphen = Mask(numbersHyphen.ToString());

                    numbersHyphen = new StringBuilder(maskedNoHyphen);

                    int hypenInsert = 4;
                    for (int i = hypenInsert; i < numbersHyphen.Length; i += hypenInsert + 1)
                    {
                       numbersHyphen.Insert(i, "-");
                    }

                    return numbersHyphen.ToString();
                }

                    var result = Mask(creditCardNumber);
                    return result;
        }

        /// <summary>
        /// Ta in kreditkortnummer och maskera alla siffror förutom första siffran samt de 4 sista siffrorna oavsett längd.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns>Maskerat kreditskortsnummer</returns>
        public static string Mask (string creditCardNumber)
        {
            var firstDigit = creditCardNumber.Substring(0, 1);
            var lastNumbers = creditCardNumber.Substring(creditCardNumber.Length - 4, 4);
            var maskedNumbers = new string('#', creditCardNumber.Length - firstDigit.Length - lastNumbers.Length);

            var result = string.Concat(firstDigit + maskedNumbers + lastNumbers);

            return result;
         }
  
        
    }
}