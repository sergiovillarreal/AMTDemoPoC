using System;
using System.Net;
using AmtDirect.Core.Models;
using AmtDirectCalculator.Core.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AmtDirectCalculator.Api.Controllers
{

    /// <summary>
    /// Gasb Calculator Controller
    /// </summary>
    /// <remarks>
    /// Gasb calculator api end point
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class GasbCalculatorController : BaseApiController
    {
        private IBaseCalculatorService _baseCalculatorService;

        public GasbCalculatorController(IConfiguration configuration,
            IBaseCalculatorService baseCalculatorService) : base(configuration)
        {
            _baseCalculatorService = baseCalculatorService;
        }

        /// <summary>
        /// Derive Calendar Period
        /// </summary>
        /// <remarks>
        /// Remove "0" character from month in calendar period string
        /// </remarks>
        /// <param name="calendarPeriod">string calendar period to derive example: 09/2020</param>
        /// <returns>string formated</returns>
        [HttpPost]
        [Route("DeriveCalendarPeriod")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CalendarPeriod), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(AMTErrorMessage), StatusCodes.Status400BadRequest)]
        public IActionResult DeriveCalendarPeriod([FromBody] CalendarPeriod calendarPeriod)
        {
            try
            {
                return Ok(_baseCalculatorService.DeriveCalendarPeriod(calendarPeriod));
            }
            catch (Exception ex)
            {
                AMTErrorMessage errorMessage = new AMTErrorMessage
                {
                    Message = ex.Message
                };
                return BadRequest(errorMessage);
            }
        }

        /// <summary>
        /// Calculate Third Party GRV STD 13
        /// </summary>
        /// <remarks>
        /// Detail Description here!
        /// </remarks>
        /// <param name="thirdPartyGrv">Third Party object values to calculate</param>
        /// <returns>ThirdPartyGrvResult object</returns>
        [HttpPost]
        [Route("CalculateThirdPartyGrvStl13")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ThirdPartyGrvResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(AMTErrorMessage), StatusCodes.Status400BadRequest)]
        public IActionResult CalculateThirdPartyGrvStl13([FromBody] ThirdPartyGrv thirdPartyGrv)
        {
            try
            {
                return Ok(_baseCalculatorService.CalculateThirdPartyGrvStl13(thirdPartyGrv));
            }
            catch (Exception ex)
            {
                AMTErrorMessage errorMessage = new AMTErrorMessage
                {
                    Message = ex.Message
                };
                return BadRequest(errorMessage);
            }
        }
    }
}
