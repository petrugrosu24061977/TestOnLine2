using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Common;

namespace TestOnLine.Business.Interfaces
{
    public interface ICandidateBusiness
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();
    }
}