using DomainModels;
using DomainModels.Request.FeesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IDashboardData
    {
        DashboardDomainModel.Dashboard GetAllRecords();
    }
}
