namespace AmtDirectCalculator.SharedKernel.Interfaces
{
    public interface IDataAccessConfiguration
    {
         string BaseUrl { get; set; }
         string BaseService { get; set; }
         string GetFASBClientSelectionsByClientID { get; set; }
    }
}
