using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.TimeTableManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TimeTableManagementDomain : ITimeTableManagement
    {
        private readonly ITimeTableManagementData _timeTableManagement;
        public TimeTableManagementDomain(ITimeTableManagementData TimeTableManagementData)
        {
            _timeTableManagement= TimeTableManagementData;
        }
        public async Task<TimeTableManagementDomainModel> CreateTimeTableManagement(TimeTableManagementRequest request)
        {
            var dominModel = new TimeTableManagementDomainModel
            {
               // Id = request.Id,
                StandardId = request.StandardId,
                TeacherId = request.TeacherId,
                SubjectId = request.SubjectId,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                DurationOfLecture = request.DurationOfLecture,
                TimeTableName = request.TimeTableName,
                description = request.description,
                isActive = request.isActive,
                Day = request.Day
            };
            return await _timeTableManagement.CreateTimeTableManagement(dominModel);
        }

        public async Task<bool> DeleteTimeTableManagement(int TimeTableManagementId)
        {
            return await _timeTableManagement.DeleteTimeTableManagement(TimeTableManagementId);
        }

        public async Task<TimeTableManagementViewModel> GetTimeTableManagementById(long Id)
        {
            return await _timeTableManagement.GetTimeTableManagementById(Id);
        }

        public async Task<bool> UpdateTimeTableManagement(TimeTableManagementRequest request)
        {
            var timetabledomainModel = new TimeTableManagementDomainModel
            {
                Id = request.Id,
                StandardId = request.StandardId,
                TeacherId = request.TeacherId,
                SubjectId = request.SubjectId,
                FromTime = request.FromTime,
                ToTime = request.ToTime,
                DurationOfLecture = request.DurationOfLecture,
                TimeTableName = request.TimeTableName,
                description = request.description,
                isActive = request.isActive,
                Day = request.Day
            };
            return await _timeTableManagement.UpdateTimeTableManagement(timetabledomainModel);
        }

        IEnumerable<TimeTableManagementViewModel> ITimeTableManagement.GetAllTimeTableManagement()
        {
            return _timeTableManagement.GetAllTimeTableManagement();

            
        }
    }
}
