using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Institute;
using DomainModels.Request.Token;
using DomainModels.Request.User;
using System.Web;
using Utility;

namespace Domain
{
    public class UserDomain : IUser
    {
        private readonly IUserData _userData;

        public UserDomain(IUserData userData)
        {
                _userData = userData;
        }

        public async Task<UserDomainModel> CreateUser(UserRequest request)
        {
            var dominModel = new UserDomainModel
            {
                FirstName = request.FirstName,
                LastName  = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Contact = request.Contact,
                Email = request.Email,
                Address = request.Address,
                Aadhar = request.Aadhar,
                Pan = request.Pan,
                RoleId = request.RoleId,
                DateOfJoining = request.DateOfJoining,
                LastWorkimg = request.LastWorkimg,
                IsActive = request.IsActive,
                Photo = request.Photo
            };

            return await _userData.CreateUser(dominModel);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return _userData.GetAllUsers();

        }

        public Task<UserDomainModel> GetUser(string userName, string password)
        {
            return _userData.GetUser(userName, password);
        }
        public async Task<UserViewModel> GetUserById(int Id)
        {
            return await _userData.GetUserById(Id);
        }
        public  Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            return _userData.ChangePassword(request);
        }

        public async Task<bool> UpdateUser(UserRequest request)
        {
            var dominModel = new UserDomainModel
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Password = request.Password,
                Contact = request.Contact,
                Email = request.Email,
                Address = request.Address,
                Aadhar = request.Aadhar,
                Pan = request.Pan,
                RoleId = request.RoleId,
                DateOfJoining = request.DateOfJoining,
                LastWorkimg = request.LastWorkimg,
                Photo = request.Photo
            };

            return await _userData.UpdateUser(dominModel);
        }
        public async Task<bool> DeleteUser(int UserId)
        {

            return await _userData.DeleteUser(UserId);
        }
        public async Task<ForgotPassworDomainModel> ForgotPassword(string UserName)
        {
            var user = await _userData.GetByUserName(UserName);
            if (user != null)
            {
                user.Password = Utility.RandomPasswordGenerate.PasswordGenerator();
                var userResponse = await _userData.UpdateUser(user);
            }

            return new ForgotPassworDomainModel
            {
                UserName = user.UserName,
                Password = user.Password,
            };
        }
    }
}
