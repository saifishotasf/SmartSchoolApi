using Contracts.DataContracts;
using DomainModels;
using DomainModels.Request.Standard;
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
    public class SubjectData : ISubjectData
    {
        private readonly ApplicationDbContext _context;
        public SubjectData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateSubject(SubjectDomainModel request)
        {
            var subject = _context.Subjects.Add(new Subject
            {
                Id = request.Id,
                SubjectName = request.SubjectName,
                isActive = true
            });
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<SubjectRequest> GetAllSubjects()
        {

            var result = _context.Subjects.Where(x => x.isActive).Select(record => 
                         new SubjectRequest
                         {
                             Id = record.Id,
                             SubjectName = record.SubjectName
                         }).ToList();

            return result;
        }

        public async Task<SubjectDomainModel> GetSubject(int SubjectId)
        {
            var subject = _context.Subjects.Where(x => x.Id == SubjectId && x.isActive).Select(sub =>

             new SubjectDomainModel
            {

                SubjectName = sub.SubjectName,
                isActive = sub.isActive
            }).FirstOrDefault();

            return subject;

        }

        public async Task<bool> UpdateSubject(SubjectDomainModel request)
        {
            
            var subject = await _context.Subjects.FindAsync(request.Id);
            if (subject != null)
            {
                subject.SubjectName = request.SubjectName;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteSubject(int SubjectId)
        {
            var subject = await _context.Subjects.Select(x => new Subject { Id = x.Id, SubjectName = x.SubjectName }).FirstOrDefaultAsync(f => f.Id == SubjectId);

            if (subject != null)
            {
                subject.isActive = false;
            }
            _context.Subjects.Attach(subject);
            _context.Entry(subject).Property(X => X.isActive).IsModified = true;

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
