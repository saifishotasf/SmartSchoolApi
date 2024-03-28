using Contracts.DataContracts;
using Contracts.DomainContracts;
using Data.Migrations;
using DomainModels;
using DomainModels.Request.FeesManagement;
using DomainModels.Request.TimeTableManagement;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FeesManagementData : IFeesManagementData
    {
        private readonly ApplicationDbContext _context;

        public FeesManagementData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FeesManagementModel> CreateFeesManagement(FeesManagementModel request)
        {
            var feesManagement = _context.FeesManagement.Add(new FeesManagementModel
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
            });
            var result = _context.SaveChanges();
            return feesManagement.Entity;
        }

        public IEnumerable<FeesManagementViewModel> GetAllFeesManagement()
        {
            var management = (from fees in _context.FeesManagement
                              join student in _context.Students on fees.StudentId equals student.Id
                              join standard in _context.Standards on fees.StandardId equals standard.Id
                              join teacher in _context.Users on fees.TeacherId equals teacher.Id
                              join devision in _context.Divisions on fees.DevisionId equals devision.Id
                              select new FeesManagementViewModel
                              {
                                  StudentId = fees.StudentId,
                                  Fees=fees.Fees,
                                  PendingFees=fees.PendingFees,
                                  PaidFees=fees.PaidFees,
                                  Date = fees.Date,
                                  isActive=fees.isActive,

                                  Standards = new StandardsView
                                  {
                                      Id = standard.Id,
                                      Name = standard.Name
                                  },

                                  Teachers = new TeachersView
                                  {
                                      Id = teacher.Id,
                                      Name = teacher.FirstName
                                  },

                                  Student = new StudentView
                                  {
                                      Id = student.Id,
                                      Name = student.FirstName
                                  },

                                  Devision=new DevisionView
                                  {
                                    Id=devision.Id,
                                    Name= devision.Name
                                   }
                              }).ToList();
            return management;
        }

        public async Task<FeesManagementViewModel> GetFeesManagementById(int StudentId)
        {
            var result = (from fees in _context.FeesManagement
                              join student in _context.Students on fees.StudentId equals student.Id
                              join standard in _context.Standards on fees.StandardId equals standard.Id
                              join teacher in _context.Users on fees.TeacherId equals teacher.Id
                              join devision in _context.Divisions on fees.DevisionId equals devision.Id
                              where fees.StudentId==StudentId
                              select new FeesManagementViewModel
                              {
                                  StudentId = fees.StudentId,
                                  Fees = fees.Fees,
                                  PendingFees = fees.PendingFees,
                                  PaidFees = fees.PaidFees,
                                  Date = fees.Date,
                                  isActive = fees.isActive,

                                  Standards = new StandardsView
                                  {
                                      Id = standard.Id,
                                      Name = standard.Name
                                  },

                                  Teachers = new TeachersView
                                  {
                                      Id = teacher.Id,
                                      Name = teacher.FirstName
                                  },

                                  Student = new StudentView
                                  {
                                      Id = student.Id,
                                      Name = student.FirstName
                                  },

                                  Devision = new DevisionView
                                  {
                                      Id = devision.Id,
                                      Name = devision.Name
                                  }
                              }).FirstOrDefault(); 
            return result;
        }

        public async Task<bool> UpdateFeesManagement(FeesManagementModel request)
        {
            var feesManagement = _context.FeesManagement.Where(f=>f.StudentId==request.StudentId).FirstOrDefault();
            if (feesManagement != null)
            {
                feesManagement.StudentId = request.StudentId;
                feesManagement.Fees = request.Fees;
                feesManagement.PendingFees= request.PendingFees;
                feesManagement.PaidFees = request.PaidFees;
                feesManagement.Date=request.Date;
                feesManagement.StandardId = request.StandardId;
                feesManagement.TeacherId = request.TeacherId;
                feesManagement.DevisionId=request.DevisionId;
                feesManagement.isActive= request.isActive;
                 await _context.SaveChangesAsync();
               return true;
            }
            return false;
        }

        public async Task<bool> DeleteFeesManagement(int StudentId)
        {
            var feesManagement = await _context.FeesManagement.FirstOrDefaultAsync(f => f.StudentId == StudentId);

            if (feesManagement != null)
            {
                feesManagement.isActive = false;
            }
                _context.FeesManagement.Attach(feesManagement);
                _context.Entry(feesManagement).Property(X => X.isActive).IsModified = true;
            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

    }
}
