using AmtDirect.Core.Models;
using AmtDirectCalculator.Core.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;

namespace AmtDirectCalculator.Specs.Steps
{
    [Binding]
    public class DeriveCalendarPeriodSteps
    {
        private string _baseUrl;
        private string _endPointService;
        private ICalendarPeriod _calendarPeriod;
        private ICalendarPeriod _calendarResult;
        private AMTErrorMessage _amtErrorMessage;

        public DeriveCalendarPeriodSteps()
        {
            _baseUrl = "https://amtcalculator.azurewebsites.net/";
            _endPointService = "api/GasbCalculator/DeriveCalendarPeriod";
            _calendarPeriod = new CalendarPeriod();
            _calendarResult = new CalendarPeriod();
            _amtErrorMessage = new AMTErrorMessage();
        }



        [Given(@"I have entered (.*) into the DeriveCalendarPeriod API end point")]
        public void GivenIHaveEnteredIntoTheDeriveCalendarPeriodAPIEndPoint(string period)
        {
            _calendarPeriod.Period = period != "null" ? period : null;
        }
        
        [When(@"I post the data to API")]
        public async System.Threading.Tasks.Task WhenIPostTheDataToAPIAsync()
        {
            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(_calendarPeriod), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(_baseUrl + _endPointService, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode)
            {
                _calendarResult = JsonConvert.DeserializeObject<CalendarPeriod>(apiResponse);
            }
            else
            {
                _amtErrorMessage = JsonConvert.DeserializeObject<AMTErrorMessage>(apiResponse);
            }
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string expectedPeriod)
        {
            Assert.That(_calendarResult.Period, Is.EqualTo(expectedPeriod));
        }

        [Then(@"the exception message should be (.*) on the result")]
        public void ThenTheExceptionMessageShouldBeExceptionOfTypeWasThrown_OnTheResult(string exceptionMessage)
        {
            Assert.That(_amtErrorMessage.Message, Is.EqualTo(exceptionMessage));
        }
    }
}
