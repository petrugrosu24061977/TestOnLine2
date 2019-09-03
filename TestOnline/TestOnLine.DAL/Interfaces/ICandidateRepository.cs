using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Common;

namespace TestOnLine.Dal.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();
        CandidateModel Get(int id);
        
        void Post(CandidateModel candidateModel);

        void Put(int id, CandidateModel candidateModel);

        void Delete(int id);


    }
}