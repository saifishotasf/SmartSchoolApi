using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StudentAttendanceDomain : IStudentAttendance
    {
        private readonly IStudentAttendanceData _studentAttendanceData;

        public StudentAttendanceDomain(IStudentAttendanceData studentAttendanceData)
        {
            _studentAttendanceData = studentAttendanceData;
        }

        public  Task<bool> CreateAttandance(StudentAttendanceRequest request)
        {
               
            var domainModel = new StudentAttendanceDomainModel
            {
                Id = request.Id,
                StudentId = request.StudentId,
                StandardId = request.StandarId,
                DivisionId = request.DivisionId,
                UserId = request.UserId,
                Date = request.Date,
                IsPresent= request.IsPresent

            };
            return _studentAttendanceData.CreateAttandance(domainModel);
        }

       public  IEnumerable<AttendanceViewModel> GetAllAttendances()
        {
            return  _studentAttendanceData.GetAllAttendances();
        }
        public Task<AttendanceViewModel> GetAttendance(GetAttendanceById request)
        {
            var domainModel = new AttendanceViewModel
            {
                Student = new StudentViewModel
                {
                    Id = request.StudentId
                },
                AttendanceDate = request.AttendanceDate,
            };
            return _studentAttendanceData.GetAttendance(domainModel);
        }

        public Task<bool> UpdateStudentAttendance(UpdateAttendanceRequest request)
        {
            var domainModel = new StudentAttendanceDomainModel
            {
                 StudentId= request.StudentId,
                 StandardId = request.StandardId,
                 DivisionId= request.DivisionId,
                 UserId = request.UserId,
                 Date = DateTime.Parse(request.DateOfAttendance),
                IsPresent = request.IsPresent
            };
            return _studentAttendanceData.UpdateStudentAttendance(domainModel);
        }
    }
}
