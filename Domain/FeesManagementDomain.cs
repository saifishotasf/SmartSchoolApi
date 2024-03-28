using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.FeesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FeesManagementDomain : IFeesManagement
    {
        private readonly IFeesManagementData _feesManagement;
        public FeesManagementDomain(IFeesManagementData FeesManagementData)
        {
            _feesManagement = FeesManagementData;
        }
        public async Task<FeesManagementModel> CreateFeesManagement(FeesManagementRequest request)
        {
            var dominModel = new FeesManagementModel
            {
                StudentId = request.StudentId,
                Fees = request.Fees,
                PendingFees = request.PendingFees,
                PaidFees = request.PaidFees,
                Date = request.Date,
                StandardId = request.StandardId,
                TeacherId = request.TeacherId,
                DevisionId = request.DevisionId,
                isActive = request.isActive
            };
            return await _feesManagement.CreateFeesManagement(dominModel);
        }

        public async Task<FeesManagementViewModel> GetFeesManagementById(int StudentId)
        {
            return await _feesManagement.GetFeesManagementById(StudentId);
        }

        public async Task<bool> UpdateFeesManagement(FeesManagementRequest request)
        {
            var feesdomainModel = new FeesManagementModel
            {
                StudentId = request.StudentId,
                Fees=request.Fees,
                PendingFees = request.PendingFees,
                PaidFees=request.PaidFees,
                Date = request.Date,
                StandardId = request.StandardId,
                TeacherId=request.TeacherId,
                DevisionId = request.DevisionId,
                isActive = request.isActive
            };
            return await _feesManagement.UpdateFeesManagement(feesdomainModel);
        }

        IEnumerable<FeesManagementViewModel> IFeesManagement.GetAllFeesManagement()
        {
            return _feesManagement.GetAllFeesManagement();
        }

        public async Task<bool> DeleteFeesManagement(int StudentId)
        {
            return await _feesManagement.DeleteFeesManagement(StudentId);
        }
    }
    }

