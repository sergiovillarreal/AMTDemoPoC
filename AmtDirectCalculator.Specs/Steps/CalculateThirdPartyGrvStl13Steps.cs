using AmtDirectCalculator.Core.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AmtDirectCalculator.Specs.Steps
{
    [Binding]
    public class CalculateThirdPartyGrvStl13Steps
    {
        private string _baseUrl;
        private string _endPointService;
        private IThirdPartyGrv _thirdPartyGrv;
        private IThirdPartyGrvResult _thirdPartyGrvResult;
        private AMTErrorMessage _amtErrorMessage;

        public CalculateThirdPartyGrvStl13Steps()
        {
            _baseUrl = "https://amtcalculator.azurewebsites.net/";
            _endPointService = "api/GasbCalculator/CalculateThirdPartyGrvStl13";
            _thirdPartyGrvResult = new ThirdPartyGrvResult();
            _thirdPartyGrv = new ThirdPartyGrv();
            _amtErrorMessage = new AMTErrorMessage();
        }

        [Given(@"I have entered the following values to the API endpoint")]
        public void GivenIHaveEnteredTheFollowingValuesToTheAPIEndPoint(Table thirdPartyGrvObject)
        {
            _thirdPartyGrv = thirdPartyGrvObject.CreateInstance<ThirdPartyGrv>();
        }
        
        [When(@"I post the data to CalculateThirdPartyGrvStl13 endPoint")]
        public async Task WhenIpostthedatatoCalculateThirdPartyGrvStl13EndPointAsync()
        {
            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(_thirdPartyGrv), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(_baseUrl + _endPointService, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode)
            {
                _thirdPartyGrvResult = JsonConvert.DeserializeObject<ThirdPartyGrvResult>(apiResponse);
            }
            else
            {
                _amtErrorMessage = JsonConvert.DeserializeObject<AMTErrorMessage>(apiResponse);
            }
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBeOnTheScreen(Table expectedPeriod)
        {
            var thirdPartyGrvExpectedResult = expectedPeriod.CreateInstance<ThirdPartyGrvResult>();
            Assert.That(_thirdPartyGrvResult.NetInvestmentInLeaseStl, Is.EqualTo(thirdPartyGrvExpectedResult.NetInvestmentInLeaseStl));
        }

        [Given(@"I have entered null object into the CalculateThirdPartyGrvStl13 API endpoint")]
        public void IHaveEnteredNullObjectIntoTheCalculateThirdPartyGrvStl13APIEndPoint()
        {
            _thirdPartyGrv = new ThirdPartyGrv();
        }
    }
}
