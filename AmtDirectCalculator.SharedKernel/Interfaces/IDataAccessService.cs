using System.Collections.Generic;
using System.ServiceModel;

namespace AmtDirectCalculator.SharedKernel.Interfaces
{
    [ServiceContract]
    public interface IDataAccessService
    {
        List<IFASBClientSelections> GetFASBClientSelectionsByClientID(int clientId);
    }
}
