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


        public async Task<CandidateModel> GetCandidateByIdAsync(int id)
        {
            return await _candidateRepository.GetCandidateByIdAsync(id);
        }


        public async Task CreateCandidateAsync(CandidateModel candidateModel)
        {
           await _candidateRepository.CreateCandidateAsync(candidateModel);
        }


        public  async Task UpdateCandidateAsync(int id, CandidateModel candidateModel)
        {
            await _candidateRepository.UpdateCandidateAsync(id, candidateModel);
        }


        public  async Task  DeleteCandidateAsync(int id)
        {
            _candidateRepository.DeleteCandidateAsync(id);
        }

    }
}
