using Azure.Core;
using Contracts.DataContracts;
using DomainModels;
using DomainModels.Request.FeesManagement;
using DomainModels.Request.StaffAttendance;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using System.Threading.Tasks;


namespace Data
{
    public class StaffAttendanceData : IStaffAttendanceData
    {
        ApplicationDbContext _context;

        public StaffAttendanceData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStaffAttendance(StaffAttendanceDomainModel request)
        {
            var attandance = _context.StaffAttendance.Add(new EntityModels.StaffAttendance
            {
                StaffId = request.StaffId,
                AttendanceTakenBy = request.AttendanceTakenBy,
                Date =request.Date,
                RoleId = request.RoleId,
                Day=request.Day,
                isPresent=request.isPresent
            });
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<StaffAttendanceViewModel> GetAllStaffAttendance()
        {

            var loggedInUser = new AttendanceTakenByViewModel
            {
                Id = LoggedInUserDetails.Id,
                UserName = LoggedInUserDetails.UserName
            };

            var attendance = (from stf in _context.StaffAttendance
                              join u in _context.Users on stf.StaffId equals u.Id
                              join r in _context.Role on stf.RoleId equals r.Id
                              select new StaffAttendanceViewModel
                              {
                                  Date = stf.Date,
                                  Day = stf.Day,
                                  isPresent = stf.isPresent,

                                  Staff = new StaffViewModel
                                  {
                                      Id = u.Id,
                                      FirstName = u.FirstName
                                  },

                                  Role = new RoleViewModel
                                  {
                                      Id = r.Id,
                                      Name = r.Name
                                  },
                                  AttendanceTakenBy = loggedInUser
                              }).ToList();

            return attendance;
        }

        public async Task<StaffAttendanceViewModel> GetStaffById(int StaffId)
        {

            var loggedInUser = new AttendanceTakenByViewModel
            {
                Id = LoggedInUserDetails.Id,
                UserName = LoggedInUserDetails.UserName
            };

            var result = (from stf in _context.StaffAttendance
                              join u in _context.Users on stf.StaffId equals u.Id
                              join r in _context.Role on stf.RoleId equals r.Id
                              where stf.StaffId==StaffId
                              select new StaffAttendanceViewModel
                          {
                                  Date = stf.Date,
                                  Day = stf.Day,
                                  isPresent = stf.isPresent,

                                  Staff = new StaffViewModel
                                  {
                                      Id = u.Id,
                                      FirstName = u.FirstName
                                  },

                                  Role = new RoleViewModel
                                  {
                                      Id = r.Id,
                                      Name = r.Name
                                  },
                                  AttendanceTakenBy = loggedInUser
                              }).FirstOrDefault(); 

            return result;
        }

        public async Task<bool> UpdateStaffAttendance(StaffAttendanceDomainModel request)
        {
            var attendance = _context.StaffAttendance.FirstOrDefault(x => x.StaffId == request.StaffId);
            if (attendance != null)
            {
                attendance.StaffId = request.StaffId;
                attendance.AttendanceTakenBy = request.AttendanceTakenBy;
                attendance.Date = request.Date;
                attendance.RoleId=request.RoleId;
                attendance.Day = request.Day;
                attendance.isPresent = request.isPresent;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
    }
    
    

