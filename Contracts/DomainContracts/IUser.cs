using DomainModels;
using DomainModels.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IUser
    {
        Task<UserDomainModel> CreateUser(UserRequest request);
        Task<UserViewModel> GetUserById(int Id);
        Task<bool> UpdateUser(UserRequest request);
        Task<UserDomainModel> GetUser(string userName, string password);
        IEnumerable<UserViewModel> GetAllUsers();
        Task<bool> ChangePassword(ChangePasswordRequest request);
        Task<bool> DeleteUser(int UserId);
        Task<ForgotPassworDomainModel> ForgotPassword(string UserName);
    }
}
