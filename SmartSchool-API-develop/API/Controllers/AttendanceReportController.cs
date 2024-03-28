using Contracts.DomainContracts;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("AttendanceReport")]
    [ApiController]
    public class AttendanceReportController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IAttendanceReport _attendanceReport;

        public AttendanceReportController(ILoggerManager logger, IAttendanceReport attendanceReport)
        {
            _logger = logger;
            _attendanceReport = attendanceReport;
        }

        [HttpGet]
        public IActionResult GetAllReport(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<AttendanceReportModel>>();
            try
            {
                var allReports = _attendanceReport.GetAttendanceReportData();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<AttendanceReportModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }
    }
}
