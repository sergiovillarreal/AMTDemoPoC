using System.ServiceModel;

namespace AmtDirect.SharedKernel.Interfaces
{
    [ServiceContract]
    public interface IExecuteJournalEntryValidation
    {
        [OperationContract]
        string Test(string s);

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);

        [OperationContract]
        IJournalEntry TestCustomModel(IJournalEntry inputModel);
    }
}
