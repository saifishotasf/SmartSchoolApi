using Contracts.DomainContracts;
using DomainModels.Request.User;
using DomainModels;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Utility.LoggerService;
using DomainModels.Request.FeesManagement;
using Responses;
using Utility;

namespace API.Controllers
{
    [Route("FeesManagement")]
    [ApiController]
    public class FeesManagementController: ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IFeesManagement _feesManagement;

        public FeesManagementController(ILoggerManager logger, IFeesManagement feesManagement)
        {
            _feesManagement = feesManagement;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeesManagement([FromBody] FeesManagementRequest request)
        {
            var response = new ApiResponse<FeesManagementModel>();
            try
            {
                var result = await _feesManagement.CreateFeesManagement(request);
                response = Responses.Responses.CreateResponse<FeesManagementModel>(result, "FeesManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<FeesManagementModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllFeesManagement(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<FeesManagementViewModel>>();
            try
            {
                var reports = _feesManagement.GetAllFeesManagement();
                response = CommonResponses.GetPaginatedApiResponse(reports, reports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<FeesManagementViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeesManagement(FeesManagementRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _feesManagement.UpdateFeesManagement(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "FeesManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetFeesManagementById(int StudentId)
        {
            var response = new ApiResponse<FeesManagementViewModel>();
            try
            {
                var result = await _feesManagement.GetFeesManagementById(StudentId);
                response = Responses.Responses.GetApiResponce<FeesManagementViewModel>(result, "FeesManagement");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<FeesManagementViewModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("{StudentId}")]
        public async Task<IActionResult> DeleteFeesManagement(int StudentId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _feesManagement.DeleteFeesManagement(StudentId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "FeesManagement");
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
