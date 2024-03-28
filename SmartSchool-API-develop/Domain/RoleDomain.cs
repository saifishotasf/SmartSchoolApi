using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoleDomain : IRole
    {
        private readonly IRoleData _RoleData;

        public RoleDomain(IRoleData roleData)
        {
            _RoleData = roleData;
        }
        public IEnumerable<RoleDomainModels> GetAllRoles()
        {
            return _RoleData.GetAllRoles();
        }
    }
}
