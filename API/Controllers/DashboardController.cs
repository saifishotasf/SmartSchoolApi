using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Division;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("Dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;
        private readonly ILoggerManager _logger;

        public DashboardController(IDashboard dashboard, ILoggerManager logger)
        {
            _dashboard = dashboard;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllDashboard()
        {
            var response = new Responses.ApiResponse<DashboardDomainModel.Dashboard>();
            try
            {
                var allReports = _dashboard.GetAllRecords();
                response = Responses.Responses.GetApiResponce<DashboardDomainModel.Dashboard>(allReports,"Dashboard");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<DashboardDomainModel.Dashboard>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

    }
}
