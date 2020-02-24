namespace AmtDirectCalculator.SharedKernel.Interfaces
{
     public interface IFASBClientSelections
    {
         int Fasb_Client_Setup_ID { get; set; }
         int Client_ID { get; set; }
         int Fasb_Prorate_Month_ID { get; set; }
         int Fasb_Prorate_Option_ID { get; set; }
         int Fasb2016_Prorate_Option_ID { get; set; }
         bool? Include_13Period_Accounting { get; set; }
         bool? Fasb2016_Include_13Period_Accounting { get; set; }
         string Fasb_Year_Option { get; set; }
         string Fasb2016_Fasb_Year_Option { get; set; }
         bool Is_Parallel_Reporting { get; set; }
         bool? Fasb2016_NPVIR_Override { get; set; }
         string Fasb2016_NPV_Cash_Flows_at_Period { get; set; }
         string NPVPropertyGroupingName { get; set; }
         string NPVLeaseGroupingName { get; set; }
         int? NPVPropertyGroupingID { get; set; }
         int? NPVLeaseGroupingID { get; set; }
         bool? IsClientCalendar { get; set; }
         string FASBImplementationDate { get; set; }
         bool? Fasb_Reverse_Expense_Initial_Period { get; set; }
         decimal? Fasb_Debit_Threshold { get; set; }
         decimal? Fasb_Credit_Threshold { get; set; }
         int? Modified_By { get; set; }
         bool Fasb2016_Reverse_Expense_Initial_Period { get; set; }
         decimal? Fasb2016_Debit_Threshold { get; set; }
         decimal? Fasb2016_Credit_Threshold { get; set; }
         int FASB2016_Classification { get; set; }
         bool FASB2016_NPVCashFlowsatPeriodOverrideatLease { get; set; }
         decimal? FASB2016_FMV_Of_Lease { get; set; }
         decimal? FASB2016_Useful_Life { get; set; }
         bool? IsClientCalendarEnable { get; set; }
         decimal? FASB_Liability_Capitalization_Threshold { get; set; }
         decimal? FASB_ROU_Asset_Capitalization_Threshold { get; set; }
         decimal? IASB_Liability_Capitalization_Threshold { get; set; }
         decimal? IASB_ROU_Asset_Capitalization_Threshold { get; set; }
         bool? IsDualReporting { get; set; }
         string IASBImplementationDate { get; set; }
         string IASBPostingDate { get; set; }
         bool FullRetroAdoption { get; set; }
         int? ToggleChoice { get; set; }
    }
}
