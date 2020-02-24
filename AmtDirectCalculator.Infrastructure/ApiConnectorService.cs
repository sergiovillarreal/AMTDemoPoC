using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel;
using AmtDirectCalculator.SharedKernel.Interfaces;

namespace AmtDirectCalculator.Infrastructure
{
    public class ApiConnectorService
    {
        private HttpClient _httpClient;
        private IDataAccessConfiguration _dataAccessConfiguration;

        public ApiConnectorService(IDataAccessConfiguration dataAccessConfiguration)
        {
            _httpClient = new HttpClient();
            _dataAccessConfiguration = dataAccessConfiguration;
        }

        public IEnumerable<IFASBClientSelections> GetFASBClientSelectionsByClientID(int clientId)
        {
           try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                EndpointAddress endpoint = new EndpointAddress(
                        new Uri(_dataAccessConfiguration.BaseUrl
                            + _dataAccessConfiguration.BaseService));
                ChannelFactory<IDataAccessService> channelFactory = new System.ServiceModel.ChannelFactory<IDataAccessService>(binding, endpoint);
                var serviceClient = channelFactory.CreateChannel();
                var fASBClientSelections = serviceClient.GetFASBClientSelectionsByClientID(clientId);
                //IEnumerable<IFASBClientSelections> fASBClientSelections = serviceClient.GetFASBClientSelectionsByClientID(clientId);
                channelFactory.Close();
                return fASBClientSelections;
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                Console.Read();
                throw new TimeoutException();
            }
            //catch (FaultException fault)
            //{
            //    Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage);
            //    Console.Read();
            //}
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
                throw new CommunicationException();
            }
            //finally
            //{
            //    channelFactory.Close();
            //}
        }

        //public IJournalEntry TestIntegration(IJournalEntry journalEntry)
        //{
        //    try
        //    {
        //        BasicHttpBinding binding = new BasicHttpBinding();
        //        EndpointAddress endpoint = new EndpointAddress(
        //                new Uri(_dataAccessConfiguration.BaseUrl
        //                    + _dataAccessConfiguration.BaseService));
        //        ChannelFactory<IExecuteJournalEntryValidation> channelFactory = new System.ServiceModel.ChannelFactory<IExecuteJournalEntryValidation>(binding, endpoint);
        //        var serviceClient = channelFactory.CreateChannel();
        //        var journalEntryResult = serviceClient.TestCustomModel(journalEntry);
        //        //IEnumerable<IFASBClientSelections> fASBClientSelections = serviceClient.GetFASBClientSelectionsByClientID(clientId);
        //        channelFactory.Close();
        //        return journalEntryResult;
        //    }
        //    catch (TimeoutException timeProblem)
        //    {
        //        Console.WriteLine("The service operation timed out. " + timeProblem.Message);
        //        Console.Read();
        //        throw new TimeoutException();
        //    }
        //    //catch (FaultException fault)
        //    //{
        //    //    Console.WriteLine("SampleFault fault occurred: {0}", fault.Detail.FaultMessage);
        //    //    Console.Read();
        //    //}
        //    catch (CommunicationException commProblem)
        //    {
        //        Console.WriteLine("There was a communication problem. " + commProblem.Message);
        //        Console.Read();
        //        throw new CommunicationException();
        //    }
        //    //finally
        //    //{
        //    //    channelFactory.Close();
        //    //}
        //}
    }
}
    