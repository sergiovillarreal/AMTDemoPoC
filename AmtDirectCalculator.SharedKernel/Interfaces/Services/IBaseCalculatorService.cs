using AmtDirectCalculator.SharedKernel.Interfaces.Models;

namespace AmtDirectCalculator.SharedKernel.Interfaces.Services
{
    public interface IBaseCalculatorService
    {
        ICalendarPeriod DeriveCalendarPeriod(ICalendarPeriod period);
        IThirdPartyGrvResult CalculateThirdPartyGrvStl13(IThirdPartyGrv thirdPartyGrv);
    }
}
