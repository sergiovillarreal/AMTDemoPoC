using System;
using System.Net;
using AmtDirect.Core.Entities;
using AmtDirectCalculator.Core.Entities;
using AmtDirectCalculator.SharedKernel.Interfaces.Models;
using AmtDirectCalculator.SharedKernel.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AmtDirectCalculator.Api.Controllers.GASB
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationsController : BaseApiController
    {
        private IBaseCalculatorService _baseCalculatorService;

        public CalculationsController(IConfiguration configuration,
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
        /// <param name="period">string calendar period to derive example: 09/2020</param>
        [ProducesResponseType(typeof(CalendarPeriod), (int)HttpStatusCode.OK)]
        [HttpPost]
        [Route("DeriveCalendarPeriod")]
        public IActionResult DeriveCalendarPeriod([FromBody] ICalendarPeriod calendarPeriod)
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
    }
}
