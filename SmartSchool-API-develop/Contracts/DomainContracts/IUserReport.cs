using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IUserReport
    {
        IEnumerable<UserReportDomainModel> GetUserReportData();
    }
}
