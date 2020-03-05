using AmtDirectCalculator.Core.Services;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using NUnit.Framework;

namespace AmtDirectCalculatorCore.Tests
{
    public class SumTwoNumbers
    {
        private IBaseCalculatorService _baseCalculatorService;

        [SetUp]
        public void Setup()
        {
            _baseCalculatorService = new BaseCalculatorService();
        }

        [Test]
        public void SumTwoNumbersSuccess()
        {
            int number1 = 4;
            int number2 = 5;
            int expected = 9;
            int sumResult = _baseCalculatorService.SumTwoNumbers(number1, number2);
            Assert.That(sumResult, Is.EqualTo(expected));
        }
    }
}