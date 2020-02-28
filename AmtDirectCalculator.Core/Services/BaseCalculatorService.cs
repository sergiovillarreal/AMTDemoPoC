using System;
using AmtDirect.Core.Models;
using AmtDirectCalculator.Core.Models;
using AmtDirectCalculator.SharedKernel.Helpers;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;

namespace AmtDirectCalculator.Core.Services
{
    public class BaseCalculatorService : IBaseCalculatorService
    {
        public BaseCalculatorService()
        {
        }

        public ICalendarPeriod DeriveCalendarPeriod(ICalendarPeriod calendarPeriod)
        {
            try
            {
                string delimiter = "/";
                string[] splitMonthYearString = calendarPeriod.Period.Split(delimiter);
                string month = splitMonthYearString[0];
                string year = splitMonthYearString[1];

                if (month.Length > 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(calendarPeriod.Period),
                        $"You are passing more than two characters for the month value your date string is: {calendarPeriod.Period}");
                }
                if (year.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(calendarPeriod.Period),
                        $"You are passing wrong number of characters for the year value your date string is: {calendarPeriod.Period}");
                }

                if (month.StartsWith('0') == true)
                {
                    month = month.Substring(1, 1);
                }

                return new CalendarPeriod { Period = $"{month}{delimiter}{year}" };
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(calendarPeriod.Period);
            }
        }

        public IThirdPartyGrvResult CalculateThirdPartyGRVSTL13(IThirdPartyGrv thirdPartyGrv)
        {
            if (thirdPartyGrv == null) { throw new NullReferenceException($"thirdPartyGrv is null"); }

            IThirdPartyGrvResult thirdPartyGrvResult = new ThirdPartyGrvResult();

            decimal period = 1300;
            int precision = 2;
            var test = (thirdPartyGrv.RateImplicit / period) * thirdPartyGrv.PVofGuaranteedRV;
            var test2 = test + thirdPartyGrv.CuUnearnedIntThirdPartyGrvStl;

            thirdPartyGrvResult.ThirdPartyGrvStl = MathHelper.SetPrecision(thirdPartyGrv.PVofGuaranteedRV, precision);
            thirdPartyGrvResult.NetThirdPartyGrvStl = MathHelper.SetPrecision((thirdPartyGrv.PVofGuaranteedRV + test), precision);
            thirdPartyGrvResult.UnearnedIntThirdPartyGrvStl = MathHelper.SetPrecision(test2, precision);
            thirdPartyGrvResult.NetInvestmentInLeaseStl = MathHelper.SetPrecision(thirdPartyGrv.NetInvLeaseSTL, precision);

            return thirdPartyGrvResult;
        }
    }
}
