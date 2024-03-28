using Azure.Core;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.User;
using EntityModels;
using Microsoft.AspNetCore.Mvc;
using Responses;
using Utility;
using Utility.LoggerService;

namespace API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IUser _user;


        public UserController(ILoggerManager logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest request)
        {
            var response = new ApiResponse<UserDomainModel>();
            try
            {
                var result = await _user.CreateUser(request);
                response = Responses.Responses.CreateResponse<UserDomainModel>(result, "User");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<UserDomainModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            var response = new ApiResponse<UserViewModel>();
            try {
                var result = await _user.GetUserById(Id);
                response = Responses.Responses.GetApiResponce<UserViewModel>(result, "User");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<UserViewModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUsers(int page = 1,int pageSize=200)
        {
            var response = new CommonResponses.ApiListResponse<IEnumerable<UserViewModel>>();
            try
            {
                var allReports = _user.GetAllUsers();
                response = CommonResponses.GetPaginatedApiResponse(allReports, allReports.Count(), page, pageSize);
            }
            catch (Exception ex)
            {
                response = CommonResponses.CacheExceptionListResponse<UserViewModel>(ex);
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _user.ChangePassword(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Password Change");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = await _user.DeleteUser(UserId);
                response = Responses.Responses.DeleteResponseMapper<bool>(result, "User");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<bool>(ex);
                _logger.LogError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string UserName)
        {
            var response = new ApiResponse<ForgotPassworDomainModel>();
            try
            {
                var result = await _user.ForgotPassword(UserName);
                response = Responses.Responses.GetApiResponce<ForgotPassworDomainModel>(result, "Password");
            }
            catch (Exception ex)
            {
                response = Responses.Responses.CacheExceptionResponse<ForgotPassworDomainModel>(ex);
                _logger.LogInfo(ex.Message);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserRequest request)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var result = _user.UpdateUser(request);
                response = Responses.Responses.UpdateResponse<bool>(result.Result, "Users");
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
       
   

          
        

       
    


    
