using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels.Request.Standard;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.Subject;

namespace Domain
{
    public class SubjectDomain : ISubject
    {
        private readonly ISubjectData _subjectData;
        public SubjectDomain(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public async Task<bool> CreateSubject(SubjectRequest request)
        {
            var domainModel = new SubjectDomainModel
            {
                Id = request.Id,
                SubjectName = request.SubjectName,
            };
            return await _subjectData.CreateSubject(domainModel);
        }

        public IEnumerable<SubjectRequest> GetAllSubjects()
        {
            return _subjectData.GetAllSubjects();
        }

        public async Task<SubjectDomainModel> GetSubject(int SubjectId)
        {
            return await _subjectData.GetSubject(SubjectId);
        }

        public async Task<bool> UpdateSubject(SubjectRequest request)
        {
            var dominModel = new SubjectDomainModel
            {
                Id = request.Id,
                SubjectName = request.SubjectName,
            };

            return await _subjectData.UpdateSubject(dominModel);
        }

        public async Task<bool> DeleteSubject(int SubjectId)
        {
            return  await _subjectData.DeleteSubject(SubjectId);
        }
    }
}
