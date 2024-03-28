using Contracts.DataContracts;
using Data.Migrations;
using DomainModels;
using DomainModels.Request.StudentAttendanceRequest;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data
{
    public class StudentAttendanceData : IStudentAttendanceData
    {
        ApplicationDbContext _context;

        public StudentAttendanceData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAttandance(StudentAttendanceDomainModel request)
        {
            var attandance = _context.StudentAttendances.Add(new EntityModels.StudentAttendance
            {
                Id = request.Id,
                StudentId = request.StudentId,
                StandardId = request.StandardId,
                DivisionId = request.DivisionId,
                UserId = request.UserId,
                Date = request.Date,
                IsPresent = request.IsPresent
            });
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<AttendanceViewModel> GetAllAttendances()
        {  

            var result = (from STA in _context.StudentAttendances
                         join u in _context.Users on STA.UserId equals u.Id
                         join s in _context.Standards on STA.StandardId equals s.Id
                         join d in _context.Divisions on STA.DivisionId equals d.Id
                         join st in _context.Students on STA.StudentId equals st.Id
                         select new AttendanceViewModel 
                         {

                             Student = new StudentViewModel
                             {
                                 Id = st.Id,
                                 Name = st.FirstName
                             },
                             Division = new DivisionViewModel
                             {
                                Id= d.Id,
                                Name= d.Name
                             },
                             Standard = new StandardViewModel
                             {
                                Id = s.Id,
                                Name= s.Name
                             },
                             User = new UserViewModel
                             {
                                Id = u.Id,
                                Name = u.FirstName,
                             },
                          AttendanceDate = STA.Date,
                          IsPresent = STA.IsPresent,
                         }).ToList();
       
            return result;
        }

        public async Task<AttendanceViewModel> GetAttendance(AttendanceViewModel request)
        {
            
            var result = (from STA in _context.StudentAttendances
                         join u in _context.Users on STA.UserId equals u.Id
                         join s in _context.Standards on STA.StandardId equals s.Id
                         join d in _context.Divisions on STA.DivisionId equals d.Id
                         join st in _context.Students on STA.StudentId equals st.Id
                         where STA.StudentId == request.Student.Id && STA.Date==request.AttendanceDate
                         select new AttendanceViewModel
                         {

                             Student = new StudentViewModel
                             {
                                 Id = st.Id,
                                 Name = st.FirstName
                             },
                             Division = new DivisionViewModel
                             {
                                 Id = d.Id,
                                 Name = d.Name
                             },
                             Standard = new StandardViewModel
                             {
                                 Id = s.Id,
                                 Name = s.Name
                             },
                             User = new UserViewModel
                             {
                                 Id = u.Id,
                                 Name = u.FirstName,
                             },
                             AttendanceDate = STA.Date,
                             IsPresent = STA.IsPresent,
                         }).FirstOrDefault();

            return result;
        }

         public async Task<bool> UpdateStudentAttendance(StudentAttendanceDomainModel request)
        {
            var attendance = _context.StudentAttendances.FirstOrDefault(x => x.StudentId == request.StudentId && x.StandardId == request.StandardId && x.DivisionId == request.DivisionId && x.Date == request.Date && x.UserId == request.UserId);
            if (attendance != null)
            {
                attendance.IsPresent = request.IsPresent;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
