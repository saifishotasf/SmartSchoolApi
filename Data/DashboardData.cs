using Contracts.DataContracts;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DashboardData : IDashboardData
    {
        private readonly ApplicationDbContext _context;

        public DashboardData(ApplicationDbContext context)
        {
            _context = context;
        }

        public DashboardDomainModel.Dashboard GetAllRecords()
        {
            var dashboard = new DashboardDomainModel.Dashboard();

            // Total students
            dashboard.TotalStudents = _context.Students.Count();

            // Total teachers
            dashboard.TotalTeachers = _context.Users.Count(x => x.RoleId == 2);

            // Total earnings
            dashboard.TotalEarnings = _context.FeesManagement.Sum(s => s.PaidFees);

            // Students left
            dashboard.StudentsLeft = _context.Students.Count(s => !s.isActive);

            // Teachers left
            dashboard.TeachersLeft = _context.Users.Count(t => !t.IsActive && t.RoleId == 2);

            // Laboratory
            dashboard.HasLaboratory = true;

            // Monthly Overview
            var monthlyOverview = (
                from student in _context.StudentAttendances
                join staff in _context.StaffAttendance
                    on student.Date.Month equals staff.Date.Month into monthlyAttendances
                from attendance in monthlyAttendances.DefaultIfEmpty()
                group new { student, attendance } by student.Date.Month into monthlyGroup
                select new DashboardDomainModel.MonthlyAttendanceOverview
                {
                    Month = monthlyGroup.Key.ToString(),
                    CountOfStudents = monthlyGroup.Sum(g => g.student.IsPresent ? 1 : 0),
                    CountOfTeachers = monthlyGroup.Sum(g => g.attendance != null && g.attendance.isPresent ? 1 : 0)
                }
            ).ToList();

            dashboard.MonthlyOverview = monthlyOverview;

            // Yearly Overview
            var yearlyStudentOverview = (
                from student in _context.StudentAttendances
                group student by student.Date.Year into yearlyGroup
                select new DashboardDomainModel.YearlyAttendanceOverview
                {
                    Year = yearlyGroup.Key.ToString(), 
                    CountOfStudents = yearlyGroup.Sum(s => s.IsPresent ? 1 : 0),
                    CountOfTeachers = 0
                }
            ).FirstOrDefault();

            var yearlyStaffOverview = (
                from staff in _context.StaffAttendance
                group staff by staff.Date.Year into yearlyGroup
                select new DashboardDomainModel.YearlyAttendanceOverview
                {
                    Year = yearlyGroup.Key.ToString(),
                    CountOfStudents = 0,
                    CountOfTeachers = yearlyGroup.Sum(s => s.isPresent ? 1 : 0)
                }
            ).FirstOrDefault();

            var yearlyOverview = new DashboardDomainModel.YearlyAttendanceOverview
            {
                Year = DateTime.Now.Year.ToString(), 
                CountOfStudents = monthlyOverview.Sum(m => m.CountOfStudents),
                CountOfTeachers = monthlyOverview.Sum(m => m.CountOfTeachers)
            };
            dashboard.YearlyOverview = yearlyOverview;

            return dashboard;
        }
    }
}
