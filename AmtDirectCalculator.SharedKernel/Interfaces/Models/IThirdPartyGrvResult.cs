namespace AmtDirectCalculator.SharedKernel.Interfaces.Models
{
    public interface IThirdPartyGrvResult
    {
        decimal ThirdPartyGrvStl {get;set;}
        decimal NetThirdPartyGrvStl { get; set; }
        decimal UnearnedIntThirdPartyGrvStl { get; set; }
        decimal NetInvestmentInLeaseStl { get; set; }            
    }
}
