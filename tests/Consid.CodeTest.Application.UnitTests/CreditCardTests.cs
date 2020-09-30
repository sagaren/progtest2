using Consid.CodeTest.Application.Services;
using NUnit.Framework;

namespace Consid.CodeTest.Application.UnitTests
{
    public class CreditCardTests
    {
        private CreditCardService _creditCardService;
        
        [SetUp]
        public void Setup()
        {
            _creditCardService = new CreditCardService();
        }

        [Test]
        public void Maskify_ForEmptyString_ShouldReturnEmptyString()
        {
            // Arrange
            var creditCardNumber = "";
            
            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);
            
            // Assert
            Assert.AreEqual("", maskifiedString);
        }
        
        
        [Test]
        public void Maskify_ForShortCreditCards_ShouldNotMask()
        {
            // Arrange
            var creditCardNumber = "54321";
            
            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);
            
            // Assert
            Assert.AreEqual("54321", maskifiedString);
        }
        
        [Test]
        public void Maskify_ForStandardCreditCards_ShouldMaskFirstAndLastFourDigits()
        {
            // Arrange
            var creditCardNumber = "5512103073210694";
            
            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);
            
            // Assert
            Assert.AreEqual("5###########0694", maskifiedString);
        }
        
        [Test]
        public void Maskify_ForCreditCardsWithLetters_ShouldNotMask()
        {
            // Arrange
            var creditCardNumber = "ABCD-EFGH-IJKLM-NOPQ";
            
            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);
            
            // Assert
            Assert.AreEqual("ABCD-EFGH-IJKLM-NOPQ", maskifiedString);
        }

        [Test]
        public void Maskify_ForStandardCreditCardsWithDashes_ShouldNotMaskifyDashes()
        {
            // Arrange
            var creditCardNumber = "4556-3646-0793-5616";

            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);

            // Assert
            Assert.AreEqual("4###-####-####-5616", maskifiedString);
        }

        [Test]
        public void Maskify_ForShortCreditCardsWithDashes_ShouldNotMaskifyDashes()
        {
            // Arrange
            var creditCardNumber = "5512-4543-4434";

            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);

            // Assert
            Assert.AreEqual("5###-####-4434", maskifiedString);
        }

        public void Maskify_ForShortCreditCards_ShouldMaskFirstAndLastFourDigits()
        {
            // Arrange
            var creditCardNumber = "55121030";

            // Act
            var maskifiedString = _creditCardService.Maskify(creditCardNumber);

            // Assert
            Assert.AreEqual("5###1030", maskifiedString);
        }
    }
}