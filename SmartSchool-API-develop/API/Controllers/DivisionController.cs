using Contracts.DomainContracts;
using Responses;
using DomainModels.Request.Division;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.LoggerService;
using DomainModels;
using Utility;

namespace API.Controllers
{
    [Route("Division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivision _division;
        private readonly ILoggerManager _logger;
        public DivisionController(IDivision division, ILoggerManager logger)
        {
            _division = division;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDivision([FromBody] DivisionRequest request)
        {

            var response = new ApiResponse<bool>();
            try
            {
                var result = _division.CreateDivision(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Division");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllDivisions(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<DivisionRequest>>();
            try
            {
                var allReports = _division.GetAllDivisions();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<DivisionRequest>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("ById")]

        public async Task<IActionResult> GetDivision(int DivId)
        {

            var response = new ApiResponse<DivisionDomainModel>();
            try
            {
                var result = _division.GetDivision(DivId);
                response = Responses.Responses.GetApiResponce<DivisionDomainModel>(result.Result, "Divsion");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<DivisionDomainModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DivisionRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _division.UpdateDivision(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Division");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpPut("{DivId}")]
        public async Task<IActionResult> DeleteDivioson(int DivId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _division.DeleteDivioson(DivId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "Division");
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
