using AmtDirectCalculator.SharedKernel.Interfaces.Models;

namespace AmtDirectCalculator.Core.Models
{
    public class ThirdPartyGrvResult: IThirdPartyGrvResult
    {
        public ThirdPartyGrvResult()
        {
        }

        public decimal ThirdPartyGrvStl { get; set; }
        public decimal NetThirdPartyGrvStl { get; set; }
        public decimal UnearnedIntThirdPartyGrvStl { get; set; }
        public decimal NetInvestmentInLeaseStl { get; set; }
    }
}
