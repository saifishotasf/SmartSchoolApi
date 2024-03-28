using Azure.Core;
using Contracts.DataContracts;
using DomainModels;
using DomainModels.Request.User;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserData : IUserData
    {
        private readonly ApplicationDbContext _context;

        public UserData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDomainModel> CreateUser(UserDomainModel request)
        {
            var user = _context.Users.Add(new UserDomainModel
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
                IsActive = request.IsActive,
                Photo = request.Photo       
            });

            var result = _context.SaveChanges();
            return user.Entity;
        }

        public async Task<UserDomainModel> GetUser(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

        public async Task<UserViewModel> GetUserById(int Id)
        {
            var user = (from u in _context.Users
                        join r in _context.Role on u.RoleId equals r.Id
                        where u.IsActive && u.Id==Id
                        select new UserViewModel
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            UserName = u.UserName,
                            Password = u.Password,
                            Contact = u.Contact,
                            Email = u.Email,
                            Address = u.Address,
                            Aadhar = u.Aadhar,
                            Pan = u.Pan,
                            DateOfJoining = u.DateOfJoining,
                            LastWorkimg = u.LastWorkimg,
                            IsActive = u.IsActive,
                            Photo = u.Photo,
                             Role = new RoleViewModel
                             {
                                 Id = r.Id,
                                 RoleName = r.Name,
                             }
                        }).FirstOrDefault(); 
            return user;
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var user = (from u in _context.Users
                           join r in _context.Role on u.RoleId equals r.Id
                        where u.IsActive
                           select new UserViewModel
                           {
                             Id = u.Id,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                             UserName = u.UserName,
                             Password = u.Password,
                             Contact = u.Contact,
                             Email = u.Email,
                             Address = u.Address,
                             Aadhar = u.Aadhar,
                             Pan = u.Pan,
                             DateOfJoining = u.DateOfJoining,
                             LastWorkimg = u.LastWorkimg,
                             IsActive = u.IsActive,
                             Photo = u.Photo,
                             Role=new RoleViewModel
                             {
                                 Id=r.Id,
                                 RoleName=r.Name,
                             }
                         }).ToList();

            return user;
        }

           

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
           var user = _context.Users.FirstOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user != null)
            {

                user.Password = request.NewPassword;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteUser(int UserId)
        {
            var user = await _context.Users.Select(x => new UserDomainModel { Id = x.Id, UserName = x.UserName }).FirstOrDefaultAsync(f => f.Id == UserId);

            if (user != null)
            {
                user.IsActive = false;
            }
            _context.Users.Attach(user);
            _context.Entry(user).Property(X => X.IsActive).IsModified = true;

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
        public async Task<UserDomainModel> GetByUserName(string UserName)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == UserName && x.IsActive);
        }

        public async Task<bool> UpdateUser(UserDomainModel request)
        {
            var User = await _context.Users.FindAsync(request.Id);
            if (User!= null)
            { 
                
                User.Id = request.Id;
                User.FirstName = request.FirstName;
                User.LastName = request.LastName;
                User.UserName = request.UserName;
                User.Password = request.Password;
                User.Contact = request.Contact;
                User.Email = request.Email;
                User.Address = request.Address;
                User.Aadhar = request.Aadhar;
                User.Pan = request.Pan;
                User.RoleId = request.RoleId;
                User.DateOfJoining = request.DateOfJoining;
                User.LastWorkimg = request.LastWorkimg;
                User.Photo = request.Photo;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

