using DomainModels;
using DomainModels.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IUserData
    {
        Task<UserDomainModel> CreateUser(UserDomainModel request);
        Task<UserViewModel> GetUserById(int Id);
        IEnumerable<UserViewModel> GetAllUsers();
        Task<bool> UpdateUser(UserDomainModel request);
        Task<UserDomainModel> GetUser(string userName, string password);
        Task<bool> ChangePassword(ChangePasswordRequest request);
        Task<bool> DeleteUser(int UserId);
        Task<UserDomainModel> GetByUserName(string UserName);

    }
}
