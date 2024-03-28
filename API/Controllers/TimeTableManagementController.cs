using Contracts.DomainContracts;
using DomainModels.Request.User;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Utility.LoggerService;
using EntityModels;
using DomainModels.Request.TimeTableManagement;
using Responses;
using DomainModels.Request.Subject;
using Data.Migrations;
using DomainModels.Request.Student;
using Utility;
using Azure;

namespace API.Controllers
{
    [Route("TimetableManagement")]
    [ApiController]
    public class TimeTableManagementController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ITimeTableManagement _timeTableManagement;

        public TimeTableManagementController(ILoggerManager logger, ITimeTableManagement timeTableManagement)
        {
            _logger = logger;
            _timeTableManagement = timeTableManagement;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimeTableManagement([FromBody] TimeTableManagementRequest request)
        {
            var response = new Responses.ApiResponse<TimeTableManagementDomainModel>();
            try
            {
                var result = await _timeTableManagement.CreateTimeTableManagement(request);
                response = Responses.Responses.CreateResponse(result, "TimeTableManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<TimeTableManagementDomainModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllTimeTableManagement(int page=1, int pageSize=200)
        {
            var response= new CommonResponses.ApiListResponse<IEnumerable<TimeTableManagementViewModel>>();
            try
            {
                var reports = _timeTableManagement.GetAllTimeTableManagement();
                //response = Responses.Responses.CreateResponse(reports, "TimeTableManagement");
                response = CommonResponses.GetPaginatedApiResponse(reports,reports.Count(),page,pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<TimeTableManagementViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateTimeTableManagement(TimeTableManagementRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _timeTableManagement.UpdateTimeTableManagement(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "TimeTableManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetUserById(long Id)
        {
            var response = new ApiResponse<TimeTableManagementViewModel>();
            try
            {
                var result = await _timeTableManagement.GetTimeTableManagementById(Id);
                response = Responses.Responses.GetApiResponce<TimeTableManagementViewModel>(result, "TimeTableManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<TimeTableManagementViewModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("TimeTableManagement")]
        public async Task<IActionResult> DeleteTimeTableManagement(int TimeTableManagementId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _timeTableManagement.DeleteTimeTableManagement(TimeTableManagementId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "TimeTableManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response);
        }




    }
    
}
