using Contracts.DataContracts;
using DomainModels;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class AttendanceReportData : IAttendanceReportData
    {
        private readonly ApplicationDbContext _context;

        public AttendanceReportData(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AttendanceReportModel> GetAttendanceReportData()
        {   
            var result = from ar in _context.StudentAttendances
                         join s in _context.Students on ar.StudentId equals s.Id into studentJoin
                         from s in studentJoin.DefaultIfEmpty()
                         join st in _context.Standards on ar.StandardId equals st.Id into standardJoin
                         from st in standardJoin.DefaultIfEmpty()
                         join d in _context.Divisions on ar.DivisionId equals d.Id into divisionJoin
                         from d in divisionJoin.DefaultIfEmpty()
                         join u in _context.Users on ar.UserId equals u.Id into userJoin
                         from u in userJoin.DefaultIfEmpty()
                         join r in _context.Role on u.RoleId equals r.Id
                         where r != null && r.Name == "Teacher" && u.IsActive && s.isActive && st.isActive && d.isActive && ar.IsPresent==true
                         select new AttendanceReportModel
                         {
                             Id = ar.Id,
                             Date = ar.Date,
                             isPresent = ar.IsPresent,
                             StudentName = s != null ? s.FirstName : null,
                             ClassName = st != null ? st.Name : null,
                             DivisionName = d != null ? d.Name : null,
                             UsersName = u != null ? u.FirstName : null,
                             RoleId = r != null ? r.Id : default(int),
                             RoleName = r != null ? r.Name : null,
                         };
            return result;



        }
    }
}
