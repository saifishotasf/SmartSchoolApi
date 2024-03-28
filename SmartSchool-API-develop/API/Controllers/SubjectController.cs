using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("Subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subject;
        private readonly ILoggerManager _logger;
        public SubjectController(ISubject subject, ILoggerManager logger)
        {
            _subject = subject;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectRequest request)
        {

            var response = new ApiResponse<bool>();
            try
            {
                var result = _subject.CreateSubject(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Subject");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllSubjects(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<SubjectRequest>>();
            try
            {
                var allReports = _subject.GetAllSubjects();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<SubjectRequest>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }


        [HttpGet("ById")]
        public async Task<IActionResult> GetSubject(int SubjectId)
        {

            var response = new ApiResponse<SubjectDomainModel>();
            try
            {
                var result = _subject.GetSubject(SubjectId);
                response = Responses.Responses.GetApiResponce<SubjectDomainModel>(result.Result, "Subject");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<SubjectDomainModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject(SubjectRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _subject.UpdateSubject(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Subject");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpPut("{SubjectId}")]
        public async Task<IActionResult> DeleteSubject(int SubjectId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _subject.DeleteSubject(SubjectId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "subject");
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
