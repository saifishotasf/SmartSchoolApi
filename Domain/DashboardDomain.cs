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
    public class DashboardDomain : IDashboard
    {
        private readonly IDashboardData _dashboardData;

        public DashboardDomain(IDashboardData dashboardData)
        {
            _dashboardData = dashboardData;
        }

        public DashboardDomainModel.Dashboard GetAllRecords()
        {
            return _dashboardData.GetAllRecords();
        }
    }
}

