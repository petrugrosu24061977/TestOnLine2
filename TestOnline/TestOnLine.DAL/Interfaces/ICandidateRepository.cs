using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Common;

namespace TestOnLine.Dal.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();
    }
}