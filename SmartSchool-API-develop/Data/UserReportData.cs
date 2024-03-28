using Contracts.DataContracts;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserReportData : IUserReportData
    {
        private readonly ApplicationDbContext _context;
        public UserReportData(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<UserReportDomainModel> GetUserReportData()
        {
            var query = (from student in _context.Students
                        join division in _context.Divisions on student.Id equals division.Id
                        join standard in _context.Standards on student.Id equals standard.Id
                        join user in _context.Users on student.Id equals user.Id
                        where user.RoleId == 2
                        group new { UserName = user.UserName, StudentName = student.FirstName, DivisionName = division.Name, StandardName = standard.Name }
                        by new { user.UserName, standard.Name  } into groupedData
                        select new UserReportDomainModel
                        {
                            TeacherNames = groupedData.Key.UserName,
                            StudentNames = groupedData.Select(g => g.StudentName).FirstOrDefault(),
                            DivisionNames = groupedData.Select(g => g.DivisionName).FirstOrDefault(),
                            StandardNames = groupedData.Key.Name
                        }).ToList();
            return query;            
        }
    }
}
