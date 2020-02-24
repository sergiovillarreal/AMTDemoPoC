using AmtDirectCalculator.Core.Models;
using AmtDirectCalculator.Core.Services;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using NUnit.Framework;

namespace AmtDirectCalculatorCore.Tests
{
    public class CalculateThirdPartyGRVSTL13
    {
        private IBaseCalculatorService _baseCalculatorService;
        private IThirdPartyGrv _thirdPartyGrv;
        private IThirdPartyGrvResult _thirdPartyGrvResult;
        private IThirdPartyGrvResult _thirdPartyGrvExpected;

        [SetUp]
        public void Setup()
        {
            _baseCalculatorService = new BaseCalculatorService();
            _thirdPartyGrv = new ThirdPartyGrv();
            _thirdPartyGrvResult = new ThirdPartyGrvResult();
            _thirdPartyGrvExpected = new ThirdPartyGrvResult();
        }

        [Test]
        public void Success()
        {
            _thirdPartyGrv.PVofGuaranteedRV = 1012.2323M;
            _thirdPartyGrv.RateImplicit = 2.4332M;
            _thirdPartyGrv.NetInvLeaseSTL = 983.234M;
            _thirdPartyGrv.CuUnearnedIntThirdPartyGrvStl = 183M;

            _thirdPartyGrvExpected.ThirdPartyGrvStl = 1012.23M;
            _thirdPartyGrvExpected.NetThirdPartyGrvStl = 1014.13M;
            _thirdPartyGrvExpected.UnearnedIntThirdPartyGrvStl = 184.89M;
            _thirdPartyGrvExpected.NetInvestmentInLeaseStl = 983.23M;

            _thirdPartyGrvResult = _baseCalculatorService.CalculateThirdPartyGRVSTL13(_thirdPartyGrv);
            Assert.That(_thirdPartyGrvResult.ThirdPartyGrvStl, Is.EqualTo(_thirdPartyGrvExpected.ThirdPartyGrvStl));
            Assert.That(_thirdPartyGrvResult.NetThirdPartyGrvStl, Is.EqualTo(_thirdPartyGrvExpected.NetThirdPartyGrvStl));
            Assert.That(_thirdPartyGrvResult.UnearnedIntThirdPartyGrvStl, Is.EqualTo(_thirdPartyGrvExpected.UnearnedIntThirdPartyGrvStl));
            Assert.That(_thirdPartyGrvResult.NetInvestmentInLeaseStl, Is.EqualTo(_thirdPartyGrvExpected.NetInvestmentInLeaseStl));

        }
    }
}
