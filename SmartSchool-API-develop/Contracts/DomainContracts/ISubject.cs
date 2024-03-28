using DomainModels;
using DomainModels.Request.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface ISubject
    {
        Task<bool> CreateSubject(SubjectRequest request);
        IEnumerable<SubjectRequest> GetAllSubjects();
        Task<SubjectDomainModel> GetSubject(int SubjectId);
        Task<bool> UpdateSubject(SubjectRequest request);
        Task<bool> DeleteSubject(int SubjectId);
    }
}
