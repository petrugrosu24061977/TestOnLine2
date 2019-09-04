using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Common;

namespace TestOnLine.Business.Interfaces
{
    public interface ICandidateBusiness
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();


        Task<CandidateModel> GetCandidateByIdAsync(int id);


        Task CreateCandidateAsync(CandidateModel candidateModel);

        Task UpdateCandidateAsync(int id, CandidateModel candidateModel);


        Task DeleteCandidateAsync(int id);
    }
}