using System.Collections.Generic;
using System.Threading.Tasks;
using TestOnLine.Business.Interfaces;
using TestOnLine.Common;
using TestOnLine.Dal.Interfaces;

namespace TestOnLine.Business
{
    public class CandidateBusiness : ICandidateBusiness
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateBusiness(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<IEnumerable<CandidateModel>> GetCandidatesAsync()
        {
            return await _candidateRepository.GetCandidatesAsync();
        }
    }
}
