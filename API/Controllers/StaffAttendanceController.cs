using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.FeesManagement;
using DomainModels.Request.StaffAttendance;
using DomainModels.Request.StudentAttendanceRequest;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("StaffAttendance")]
    [ApiController]
    public class StaffAttendanceController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IStaffAttendance _staffAttendance;

        public StaffAttendanceController(ILoggerManager logger, IStaffAttendance staffAttendance)
        {
            _logger = logger;
            _staffAttendance = staffAttendance;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffAttendance([FromBody] StaffAttendanceRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _staffAttendance.CreateStaffAttendance(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Staff Attentance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffAttendance(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<StaffAttendanceViewModel>>();
            try
            {
                var allReports = _staffAttendance.GetAllStaffAttendance();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<StaffAttendanceViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("StaffAttendanceById")]
        public async Task<IActionResult> GetStaffById( int StaffId)
        {
            var response = new ApiResponse<StaffAttendanceViewModel>();
            try
            {
                var result = _staffAttendance.GetStaffById(StaffId);
                response = Responses.Responses.GetApiResponce<StaffAttendanceViewModel>(result.Result, "StaffAttendance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<StaffAttendanceViewModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaffAttendance(StaffAttendanceRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _staffAttendance.UpdateStaffAttendance(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "StaffAttendance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }


    }
}
