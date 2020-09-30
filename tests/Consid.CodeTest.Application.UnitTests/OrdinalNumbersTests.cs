using Consid.CodeTest.Application.Services;
using NUnit.Framework;

namespace Consid.CodeTest.Application.UnitTests
{
    public class OrdinalNumberServiceTests
    {
        private OrdinalNumbersService _ordinalNumbersService;
        
        [SetUp]
        public void Setup()
        {
            _ordinalNumbersService = new OrdinalNumbersService();
        }

        [Test]
        [TestCase(1, "1st")]
        [TestCase(2, "2nd")]
        [TestCase(3, "3rd")]
        [TestCase(5, "5th")]
        [TestCase(11, "11th")]
        [TestCase(12, "12th")]
        [TestCase(13, "13th")]
        [TestCase(101, "101st")]
        public void GetOrdinalRepresentation_ForSingleDigit_ShouldSetCorrectSuffix(int inputNumber, string expected)
        {
            // Act
            var ordinalRepresentation = _ordinalNumbersService.GetOrdinalRepresentation(inputNumber);
            
            // Assert
            Assert.AreEqual(expected, ordinalRepresentation);
        }
    }
}