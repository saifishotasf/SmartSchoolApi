using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserReportDomain : IUserReport
    {
        private readonly IUserReportData _userReportData;
        public UserReportDomain(IUserReportData userReportData)
        {
            _userReportData = userReportData;
        }
       public IEnumerable<UserReportDomainModel> GetUserReportData()
        {
            return _userReportData.GetUserReportData();
        }
    }
}
