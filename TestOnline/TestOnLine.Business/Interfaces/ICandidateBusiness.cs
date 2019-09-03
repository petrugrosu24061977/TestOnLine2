using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Common;

namespace TestOnLine.Business.Interfaces
{
    public interface ICandidateBusiness
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();


        CandidateModel Get(int id);


        void Post(CandidateModel candidateModel);

        void Put(int id, CandidateModel candidateModel);


        void Delete(int id);
    }
}