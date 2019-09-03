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


        public  CandidateModel Get(int id)
        {
            return _candidateRepository.Get(id);
        }


        public  void Post(CandidateModel candidateModel)
        {
            _candidateRepository.Post(candidateModel);
        }


        public  void Put(int id, CandidateModel candidateModel)
        {
            _candidateRepository.Put(id, candidateModel);
        }


        public  void Delete(int id)
        {
            _candidateRepository.Delete(id);
        }

    }
}
