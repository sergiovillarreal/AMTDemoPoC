using System;
namespace AmtDirectCalculator.SharedKernel.Interfaces.Models
{
    public interface IThirdPartyGrv
    {
        decimal PVofGuaranteedRV { get; set; }
        decimal RateImplicit { get; set; }
        decimal NetInvLeaseSTL { get; set; }
        decimal CuUnearnedIntThirdPartyGrvStl { get; set; }
    }
}
