using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Student;
using DomainModels.Request.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly ILoggerManager _logger;
        public StudentController(IStudent student, ILoggerManager logger)
        {
            _student = student;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {

            var response = new ApiResponse<bool>();
            try
            {
                var result = _student.CreateStudent(request);
                response = Responses.Responses.CreateResponseBool<bool>(result.Result, "Student");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllStudents(int page = 1, int pageSize = 200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<StudentViewModel>>();
            try
            {
                var allReports = _student.GetAllStudents();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<StudentViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetStudent(int StudentId)
        {

            var response = new ApiResponse<StudentViewModel>();
            try
            {
                var result = _student.GetStudent(StudentId);
                response = Responses.Responses.GetApiResponce<StudentViewModel>(result.Result, "Student");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<StudentViewModel>(ex);
                _logger.LogInfo(ex.Message);

            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _student.UpdateStudent(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Student");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);

            }
            return Ok(response);
        }

        [HttpPut("{StudentId}")]
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _student.DeleteStudent(StudentId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "Student");
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
