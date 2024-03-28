using Azure;
using Azure.Core;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Institute;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("institutes")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IInstitute _institute;
        private readonly ILoggerManager _logger;

        public InstituteController(IInstitute institute, ILoggerManager logger)
        {
            _institute = institute;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAllInstitutes(int page = 1, int pageSize = 200)
        {
            var result = _institute.GetAllInstitutes();
            {
                var response = new CommonResponses.ApiListResponse<IEnumerable<InstituteRequest>>();
                try
                {
                    var allReports = _institute.GetAllInstitutes();
                    response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);

                }
                catch (Exception ex)
                {
                    response = CommonResponses.CacheExceptionListResponse<InstituteRequest> (ex);
                    _logger.LogError(ex.Message);
                }

                return Ok(response);
            }
          
        }
        [HttpGet("ById")]

        public async Task<IActionResult> GetInstitute(long InstituteId)
        {

            var response = new ApiResponse<InstituteDomainModel>();
            try
            {
                var result = _institute.GetInstitute(InstituteId);
                response = Responses.Responses.GetApiResponce<InstituteDomainModel>(result.Result, "Institure");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<InstituteDomainModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InstituteRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _institute.CreateInstitute(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Institure");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(InstituteUpdateRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _institute.UpdateInstitute(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Institure");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }
        [HttpPut("{Id}")]
        
        public async Task<IActionResult> DeleteInstitute(long Id )
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _institute.DeleteInstitute(Id);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "Institute");
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

