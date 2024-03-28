using Contracts.DomainContracts;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility.LoggerService;
using Utility;
using DomainModels;

namespace API.Controllers
{
    [Route("StaffReport")]
    [ApiController]
    public class StaffReportController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IUserReport _userReport;
 

        public StaffReportController(ILoggerManager logger, IUserReport userReport)
        {
            this._logger = logger;
            _userReport = userReport;
        }

        [HttpGet]
        public IActionResult GetAllReport(int page = 1,int pageSize=200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<UserReportDomainModel>>();
            try
            {
                var allReports = _userReport.GetUserReportData();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<UserReportDomainModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }
    }
}
