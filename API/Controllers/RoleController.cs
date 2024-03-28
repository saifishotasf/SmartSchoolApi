using Contracts.DomainContracts;
using Data.Migrations;
using DomainModels;
using DomainModels.Request.Institute;
using DomainModels.Request.Roles;
using EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;


namespace API.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        private readonly ILoggerManager _logger;
        public RoleController(IRole role, ILoggerManager logger)
        {
            _role = role;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllRoles(int page = 1, int pageSize = 200)
        {

            var response = new CommonResponses.ApiListResponse<IEnumerable<RoleDomainModels>>();
            try
            {
                var allReports = _role.GetAllRoles();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);

            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<RoleDomainModels>(ex);
                _logger.LogError(ex.Message);
            }

            return Ok(response);
        }
    }
}
