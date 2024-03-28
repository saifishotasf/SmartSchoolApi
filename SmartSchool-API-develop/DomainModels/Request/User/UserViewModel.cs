﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Aadhar { get; set; }
        public string Pan { get; set; }
        public RoleViewModel Role { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime LastWorkimg { get; set; }
        public bool IsActive { get; set; }
        public byte[] Photo { get; set; }
    }
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
