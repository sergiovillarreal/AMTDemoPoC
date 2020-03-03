using System.Diagnostics.CodeAnalysis;
using AmtDirectCalculator.SharedKernel.Interfaces;

namespace AmtDirectCalculator.Core.Entities
{
    [ExcludeFromCodeCoverage]
    public class DataAccessConfiguration: IDataAccessConfiguration
    {
        public string BaseUrl { get; set; }
        public string BaseService { get; set; }
        public string GetFASBClientSelectionsByClientID { get; set; }
    }
}
