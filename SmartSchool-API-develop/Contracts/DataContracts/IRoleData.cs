using DomainModels;
using DomainModels.Request.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IRoleData
    {
        IEnumerable<RoleDomainModels> GetAllRoles();
    }
}
