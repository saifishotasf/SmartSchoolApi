using Azure.Core;
using Azure.Identity;
using Contracts.DataContracts;
using Data.Migrations;
using DomainModels;
using DomainModels.Request.Student;
using DomainModels.Request.Subject;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentData : IStudentData
    {
        private readonly ApplicationDbContext _context;

        public StudentData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStudent(StudentDomainModel request)
        {
            var student = _context.Students.Add(new EntityModels.Student
            {
                Id = request.Id,
               FirstName = request.FirstName,
               LastName = request.LastName,
               BirthDate = request.BirthDate,
               Gender = request.Gender,
               Address = request.Address,
               City = request.City,
               State = request.State,
               Country = request.Country,
               photo = request.photo,
               StandardId = request.StandardId,
               DevisionId = request.DevisionId,
               AadhaarNumber=request.AadhaarNumber,
               AadhaarPhoto=request.AadhaarPhoto,
               MotherName=request.MotherName,
               MotherContact=request.MotherContact,
               MotherEmail=request.MotherEmail,
               FatherName=request.FatherName,
               FatherContact=request.FatherContact,
               FatherEmail=request.FatherEmail,
               GuardianName=request.GuardianName,
               GuardianContact=request.GuardianContact,
               GuardianEmail=request.GuardianEmail,
                isActive = true
            });
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<StudentViewModel> GetAllStudents()
        {

            var student = (from stud in _context.Students
                           join standard in _context.Standards on stud.StandardId equals standard.Id
                           join Div in _context.Divisions on stud.DevisionId equals Div.Id
                           where  stud.isActive
                           select new StudentViewModel
                           {
                               Id = stud.Id,
                               FirstName = stud.FirstName,
                               LastName = stud.LastName,
                               BirthDate = stud.BirthDate,
                               Gender = stud.Gender,
                               Address = stud.Address,
                               City = stud.City,
                               State = stud.State,
                               Country = stud.Country,
                               photo = stud.photo,

                               isActive = stud.isActive,
                               AadhaarNumber = stud.AadhaarNumber,
                              AadhaarPhoto = stud.AadhaarPhoto,
                              MotherName = stud.MotherName,
                              MotherContact = stud.MotherContact,
                              MotherEmail = stud.MotherEmail,

                              FatherName = stud.FatherName,

                              FatherContact = stud.FatherContact,

                              FatherEmail = stud.FatherEmail,

                              GuardianName = stud.GuardianName,
                              GuardianContact = stud.GuardianContact,
                              GuardianEmail = stud.GuardianEmail,

                               Standard = new StandardView
                               {
                                   Id = standard.Id,
                                   Name = standard.Name
                               },
                               Division = new DivisionView
                               {
                                   Id = Div.Id,
                                   Name = Div.Name
                               }
                           }).ToList();

            return student;
        }

        public async Task<StudentViewModel> GetStudent(int StudentId)
        {
            var student = (from stud in _context.Students
                           join standard in _context.Standards on stud.StandardId equals standard.Id
                           join Div in _context.Divisions on stud.StandardId equals Div.Id
                           where stud.Id == StudentId && stud.isActive
                           select new StudentViewModel
                           {
                               Id = stud.Id,
                               FirstName = stud.FirstName,
                               LastName = stud.LastName,
                               BirthDate = stud.BirthDate,
                               Gender = stud.Gender,
                               Address = stud.Address,
                               City = stud.City,
                               State = stud.State,
                               Country = stud.Country,
                               photo = stud.photo,
                               isActive = stud.isActive,
                               AadhaarNumber = stud.AadhaarNumber,
                               AadhaarPhoto = stud.AadhaarPhoto,
                               MotherName = stud.MotherName,
                               MotherContact = stud.MotherContact,
                               MotherEmail = stud.MotherEmail,
                               FatherName = stud.FatherName,
                               FatherContact = stud.FatherContact,
                               FatherEmail = stud.FatherEmail,
                               GuardianName = stud.GuardianName,
                               GuardianContact = stud.GuardianContact,
                               GuardianEmail = stud.GuardianEmail,
                               Standard = new StandardView
                               {
                                   Id = standard.Id,
                                   Name = standard.Name
                               },
                               Division = new DivisionView
                               {
                                   Id = Div.Id,
                                   Name = Div.Name
                               }

                           }).FirstOrDefault();

            return student;
        }

        public async Task<bool> UpdateStudent(StudentDomainModel request)
        {

            var student = await _context.Students.FindAsync(request.Id);
            if (student != null)
            {
                student.FirstName = request.FirstName;
                student.LastName = request.LastName;
                student.BirthDate = request.BirthDate;
                student.Gender = request.Gender;
                student.Address = request.Address;
                student.City = request.City;
                student.State = request.State;
                student.Country = request.Country;
                student.photo = request.photo;
                student.StandardId = request.StandardId;
                student.DevisionId = request.DevisionId;
                student.AadhaarNumber = request.AadhaarNumber;
                student.AadhaarPhoto = request.AadhaarPhoto;
                student.MotherName = request.MotherName;
                student.MotherContact = request.MotherContact;
                student.MotherEmail = request.MotherEmail;
                student.FatherName = request.FatherName;
                student.FatherContact = request.FatherContact;
                student.FatherEmail = request.FatherEmail;
                student.GuardianName = request.GuardianName;
                student.GuardianContact = request.GuardianContact;
                student.GuardianEmail = request.GuardianEmail;
                 await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStudent(int StudentId)
        {
            var student = await _context.Students.Select(x => new EntityModels.Student { Id = x.Id, FirstName = x.FirstName }).FirstOrDefaultAsync(f => f.Id == StudentId);

            if (student != null)
            {
                student.isActive = false;
            }
            _context.Students.Attach(student);
            _context.Entry(student).Property(X => X.isActive).IsModified = true;
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}
