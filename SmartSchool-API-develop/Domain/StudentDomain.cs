using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels.Request.Subject;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.Student;

namespace Domain
{
    public class StudentDomain : IStudent
    {
        private readonly IStudentData _studentdata;

        public StudentDomain(IStudentData studentdata)
        {
            _studentdata = studentdata;
        }

        public async Task<bool> CreateStudent(StudentRequest request)
        {
            var domainModel = new StudentDomainModel
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
                AadhaarNumber = request.AadhaarNumber,
                AadhaarPhoto = request.AadhaarPhoto,
                MotherName = request.MotherName,
                MotherContact = request.MotherContact,
                MotherEmail = request.MotherEmail,
                FatherName = request.FatherName,
                FatherContact = request.FatherContact,
                FatherEmail = request.FatherEmail,
                GuardianName = request.GuardianName,
                GuardianContact = request.GuardianContact,
                GuardianEmail = request.GuardianEmail,
            };
            return await _studentdata.CreateStudent(domainModel);
        }

        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            return _studentdata.GetAllStudents();
        }

        public async Task<StudentViewModel> GetStudent(int StudentId)
        {
            return await _studentdata.GetStudent(StudentId);
        }

        public async Task<bool> UpdateStudent(StudentRequest request)
        {
            var dominModel = new StudentDomainModel
            {
                Id = request.Id,
                FirstName= request.FirstName,
                LastName= request.LastName,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                Address = request.Address,
                City = request.City,
                State = request.State,
                Country = request.Country,
                photo= request.photo,
                StandardId = request.StandardId,
                DevisionId = request.DevisionId,
                AadhaarNumber = request.AadhaarNumber,
                AadhaarPhoto = request.AadhaarPhoto,
                MotherName = request.MotherName,
                MotherContact = request.MotherContact,
                MotherEmail = request.MotherEmail,
                FatherName = request.FatherName,
                FatherContact = request.FatherContact,
                FatherEmail = request.FatherEmail,
                GuardianName = request.GuardianName,
                GuardianContact = request.GuardianContact,
                GuardianEmail = request.GuardianEmail,
            };
            return await _studentdata.UpdateStudent(dominModel);
        }

        public async Task<bool> DeleteStudent(int StudentId)
        {
            return await _studentdata.DeleteStudent(StudentId);
        }
    }
}
