namespace AmtDirectCalculator.SharedKernel.Interfaces.Models
{
    public interface IJournalEntry
    {
         int UserId { get; set; }
         int ReportID { get; set; }
         bool IsPosted { get; set; }
         int ClientId { get; set; }
         int BatchId { get; set; }
         int RecoveryId { get; set; }
         int ManualJeId { get; set; }
         string Period { get; set; }
         int QueueBatchId { get; set; }
         int QueueBatchRecoveryId { get; set; }
    }
}
