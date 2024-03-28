using Contracts.DataContracts;
using DomainModels;
using DomainModels.Request.Institute;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDbContext _context;

        public RoleData(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<RoleDomainModels> GetAllRoles()
        {

            return _context.Role.Select(x => new RoleDomainModels
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();
        }
    }
}
