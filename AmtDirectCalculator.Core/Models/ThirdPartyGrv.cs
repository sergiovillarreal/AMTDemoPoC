using System;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;

namespace AmtDirectCalculator.Core.Models
{
    public class ThirdPartyGrv: IThirdPartyGrv
    {
        public ThirdPartyGrv()
        {
        }

        public decimal PVofGuaranteedRV { get; set; }
        public decimal RateImplicit { get; set; }
        public decimal NetInvLeaseSTL { get; set; }
        public decimal CuUnearnedIntThirdPartyGrvStl { get; set; }
    }
}
