using DomainModels;
using DomainModels.Request.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface ISubjectData
    {
        Task<bool> CreateSubject(SubjectDomainModel request);
        IEnumerable<SubjectRequest> GetAllSubjects();
        Task<SubjectDomainModel> GetSubject(int SubjectId);
        Task<bool> UpdateSubject(SubjectDomainModel request);
        Task<bool> DeleteSubject(int SubjectId);
    }
}
