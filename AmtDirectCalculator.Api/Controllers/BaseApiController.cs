using AmtDirectCalculator.Core.Entities;
using AmtDirectCalculator.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AmtDirectCalculator.Api.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected IDataAccessConfiguration _dataAccessConfiguration;

        public BaseApiController(IConfiguration configuration)
        {
            _dataAccessConfiguration = new DataAccessConfiguration();
            configuration.GetSection("DataAccess").Bind(_dataAccessConfiguration);
        }
    }
}
