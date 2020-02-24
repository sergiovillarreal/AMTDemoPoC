using System;
using AmtDirect.Core.Models;
using AmtDirectCalculator.Core.Services;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using NUnit.Framework;

namespace AmtDirectCalculatorCore.Tests
{
    public class DeriveCalendarPeriod
    {
        private IBaseCalculatorService _baseCalculatorService;
        private ICalendarPeriod _calendarPeriod;

        [SetUp]
        public void Setup()
        {
            _baseCalculatorService = new BaseCalculatorService();
            _calendarPeriod = new CalendarPeriod();
        }

        [Test]
        public void PassingNullCalendarPeriodValue()
        {
            _calendarPeriod.Period = null;
            var ex = Assert.Throws<NullReferenceException>(() => _baseCalculatorService.DeriveCalendarPeriod(_calendarPeriod));
            Assert.That(ex.Message, Is.EqualTo("Exception of type 'System.NullReferenceException' was thrown."));
        }

        [Test]
        public void PassingBadMonthFormatPeriodValue()
        {
            _calendarPeriod.Period = "2020/02";
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _baseCalculatorService.DeriveCalendarPeriod(_calendarPeriod));

            Assert.That(ex.ParamName, Is.EqualTo(nameof(_calendarPeriod.Period)));
            Assert.That(ex.Message, Is.EqualTo($"You are passing more than two characters for the month value your date string is: {_calendarPeriod.Period} (Parameter '{nameof(_calendarPeriod.Period)}')"));
        }

        [Test]
        public void PassingBadYearFormatPeriodValue()
        {
            _calendarPeriod.Period = "02/19";
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _baseCalculatorService.DeriveCalendarPeriod(_calendarPeriod));

            Assert.That(ex.ParamName, Is.EqualTo(nameof(_calendarPeriod.Period)));
            Assert.That(ex.Message, Is.EqualTo($"You are passing wrong number of characters for the year value your date string is: {_calendarPeriod.Period} (Parameter '{nameof(_calendarPeriod.Period)}')"));
        }

        [Test]
        public void PassingValidFormatPeriodValue()
        {
            _calendarPeriod.Period = "02/2020";
            var result = _baseCalculatorService.DeriveCalendarPeriod(_calendarPeriod);
            string expectedResult = "2/2020";

            Assert.That(result.Period, Is.EqualTo(expectedResult));
        }
    }
}
