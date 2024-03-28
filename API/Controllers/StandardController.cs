using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using Responses;
using DomainModels.Request.Standard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.LoggerService;
using EntityModels;
using DomainModels.Request.Institute;
using Data.Migrations;
using Utility;

namespace API.Controllers
{
    [Route("Standard")]
    [ApiController]
    public class StandardController : ControllerBase
    {
        private readonly IStandard _standard;
        private readonly ILoggerManager _logger;
        public StandardController (IStandard standard, ILoggerManager logger)
        {
            _standard = standard;   
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStandard([FromBody] StandardRequest request)
        {

            var response = new ApiResponse<bool>();
            try
            {
                var result = _standard.CreateStandard(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "standard");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllStandards(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<StandardRequest>>();
            try
            {
                var allReports = _standard.GetAllStandards();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<StandardRequest>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
         
           
        }
        [HttpGet("ById")]

        public async Task<IActionResult> GetStandard(int StandardId)
        {

            var response = new ApiResponse<StandardDomainModel>();
            try
            {
                var result = _standard.GetStandard(StandardId);
                response = Responses.Responses.GetApiResponce<StandardDomainModel>(result.Result, "Standard");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<StandardDomainModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(StandardRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _standard.UpdateStandard(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Standard");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }
        [HttpPut("{Id}")]

        public async Task<IActionResult> DeleteStandard(int Id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _standard.DeleteStandard(Id);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "Standard");
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
