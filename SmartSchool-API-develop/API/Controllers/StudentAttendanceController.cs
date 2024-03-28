using Contracts.DomainContracts;
using DomainModels.Request.StudentAttendanceRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("StudentAttendances")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IStudentAttendance _studentAttendance;

        public StudentAttendanceController(ILoggerManager logger, IStudentAttendance studentAttendance)
        {
            _logger = logger;
            _studentAttendance = studentAttendance;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] StudentAttendanceRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _studentAttendance.CreateAttandance(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Student Attentance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendance(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<AttendanceViewModel>>();
            try
            {
                var allReports = _studentAttendance.GetAllAttendances();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<AttendanceViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("GetAttendance")]
        public async Task<IActionResult> GetAttendance([FromQuery] GetAttendanceById request) 
        {
            var response = new ApiResponse<AttendanceViewModel>();
            try
            {
                var result = _studentAttendance.GetAttendance(request);
                response = Responses.Responses.GetApiResponce<AttendanceViewModel>(result.Result, "Student Attentance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<AttendanceViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAttendance(UpdateAttendanceRequest request)
        {
            
            var response = new ApiResponse<bool>();
            try
            {
                var result = _studentAttendance.UpdateStudentAttendance(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Student Attentance");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }
    }
}
