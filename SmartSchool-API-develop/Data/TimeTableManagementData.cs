    using Contracts.DataContracts;
using DomainModels;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contracts.DomainContracts;
using Azure.Core;
//using Contracts.DataContracts;
//using DomainModels;
using DomainModels.Request.User;
//using EntityModels;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.TimeTableManagement;
using Data.Migrations;



namespace Data
{
    public class TimeTableManagementData :  ITimeTableManagementData
    {
        private readonly ApplicationDbContext _context;

        public TimeTableManagementData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TimeTableManagementDomainModel> CreateTimeTableManagement(TimeTableManagementDomainModel request)
        {
            var timeTableManagement = _context.TimeTableManagement.Add(new TimeTableManagementDomainModel
            {
               // Id=request.Id,
                StandardId=request.StandardId,
                TeacherId=request.TeacherId,
                SubjectId=request.SubjectId,
                FromTime =request.FromTime,
                ToTime =request.ToTime,
                DurationOfLecture=request.DurationOfLecture,
                TimeTableName = request.TimeTableName,
                description = request.description,
                isActive = request.isActive,
                Day = request.Day
            });
             _context.SaveChanges();
            return timeTableManagement.Entity;
        }

        

        public IEnumerable<TimeTableManagementViewModel> GetAllTimeTableManagement()
        {

            var management = (from timetable in _context.TimeTableManagement
                              join standard in _context.Standards on timetable.StandardId equals standard.Id into standardGroup
                              from standard in standardGroup.DefaultIfEmpty()
                              join teacher in _context.Users on timetable.TeacherId equals teacher.Id into teacherGroup
                              from teacher in teacherGroup.DefaultIfEmpty()
                              join subject in _context.Subjects on timetable.SubjectId equals subject.Id into subjectGroup
                              from subject in subjectGroup.DefaultIfEmpty()
                              where timetable.isActive == true
                              select new TimeTableManagementViewModel
                              {
                                  Id = timetable.Id,
                                  FromTime = timetable.FromTime,
                                  ToTime = timetable.ToTime,
                                  DurationOfLecture = timetable.DurationOfLecture,
                                  TimeTableName = timetable.TimeTableName,
                                  description = timetable.description,
                                  isActive = timetable.isActive,
                                  Day = timetable.Day,

                                  Standard = (standard != null) ? new StandardView
                                  {
                                      Id = standard.Id,
                                      Name = standard.Name
                                  } : null,

                                  Teacher = (teacher != null) ? new TeacherView
                                  {
                                      Id = teacher.Id,
                                      Name = teacher.FirstName
                                  } : null,

                                  Subject = (subject != null) ? new SubjectView
                                  {
                                      Id = subject.Id,
                                      Name = subject.SubjectName
                                  } : null
                              }).ToList();

            return management;
        }

        public async Task<TimeTableManagementViewModel> GetTimeTableManagementById(long Id)
        {

            var result = (from timetable in _context.TimeTableManagement
                          join standard in _context.Standards on timetable.StandardId equals standard.Id into standardGroup
                          from standard in standardGroup.DefaultIfEmpty()
                          join teacher in _context.Users on timetable.TeacherId equals teacher.Id into teacherGroup
                          from teacher in teacherGroup.DefaultIfEmpty()
                          join subject in _context.Subjects on timetable.SubjectId equals subject.Id into subjectGroup
                          from subject in subjectGroup.DefaultIfEmpty()
                          where timetable.Id == Id
                          select new TimeTableManagementViewModel
                          {
                              Id = timetable.Id,
                              FromTime = timetable.FromTime,
                              ToTime = timetable.ToTime,
                              DurationOfLecture = timetable.DurationOfLecture,
                              TimeTableName = timetable.TimeTableName,
                              description = timetable.description,
                              isActive = timetable.isActive,
                              Day = timetable.Day,

                              Standard = (standard != null) ? new StandardView
                              {
                                  Id = standard.Id,
                                  Name = standard.Name
                              } : null,

                              Teacher = (teacher != null) ? new TeacherView
                              {
                                  Id = teacher.Id,
                                  Name = teacher.FirstName
                              } : null,

                              Subject = (subject != null) ? new SubjectView
                              {
                                  Id = subject.Id,
                                  Name = subject.SubjectName
                              } : null
                          }).FirstOrDefault();

            return result;
                
                
                }

        public async Task<bool> UpdateTimeTableManagement(TimeTableManagementDomainModel request)
        {
            var timeTableManagement = await _context.TimeTableManagement.FindAsync(request.Id);
            if (timeTableManagement != null)
            {
                timeTableManagement.StandardId = request.StandardId;
                timeTableManagement.TeacherId = request.TeacherId;
                timeTableManagement.SubjectId = request.SubjectId;
                timeTableManagement.FromTime = request.FromTime;
                timeTableManagement.ToTime = request.ToTime;
                timeTableManagement.DurationOfLecture = request.DurationOfLecture;
                timeTableManagement.TimeTableName = request.TimeTableName;
                timeTableManagement.description = request.description;
                timeTableManagement.isActive = request.isActive;
                timeTableManagement.Day = request.Day;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
        public  async Task<bool> DeleteTimeTableManagement(int TimeTableManagementId)
        {
            var management = await _context.TimeTableManagement.Select(x => new TimeTableManagementDomainModel { Id = x.Id , FromTime = x.FromTime}).FirstOrDefaultAsync(f => f.Id == TimeTableManagementId);

            if(management != null)
            {
                management.isActive = false;
            }
            _context.TimeTableManagement.Attach(management);
            _context.Entry(management).Property(X => X.isActive).IsModified = true;
            var result = await _context.SaveChangesAsync();
            return result >0 ? true : false;
        }



    }
}

            

