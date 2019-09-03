using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestOnLine.Common;
using TestOnLine.Dal.Interfaces;
using TestOnLine.Dal.Models;

namespace TestOnLine.Dal.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly TestOnLineContext _ctx;

        public CandidateRepository(TestOnLineContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<IEnumerable<CandidateModel>> GetCandidatesAsync()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateModel>();
            });
            var candidates = await _ctx.Candidate.ToListAsync();
            var candidatesModel = new List<CandidateModel>();

            foreach (Candidate candidate in candidates)
            {
                IMapper iMapper = config.CreateMapper();
                var candidateModel = iMapper.Map<Candidate, CandidateModel>(candidate);
                candidatesModel.Add(candidateModel);
            }

            return candidatesModel;
        }



        public CandidateModel Get(int id)
        {

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateModel>();
            });

            var candidate = _ctx.Candidate.FirstOrDefault(c => c.Id == id);

            IMapper iMapper = config.CreateMapper();
            var candidateModel = iMapper.Map<Candidate, CandidateModel>(candidate);

            return candidateModel;
        }

        public void Post(CandidateModel candidateModel)
        {

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CandidateModel, Candidate>();
            });

            IMapper iMapper = config.CreateMapper();
            var candidate = iMapper.Map<CandidateModel, Candidate>(candidateModel);

            _ctx.Candidate.Add(candidate);
            _ctx.SaveChanges();
        }



        public void Put(int id, CandidateModel candidateModel)
        {
            var updatedCandidate = _ctx.Candidate.FirstOrDefault(c => c.Id == id);

            updatedCandidate.LastName = candidateModel.LastName;
            updatedCandidate.FirstName = candidateModel.FirstName;

            _ctx.SaveChanges();

        }


        public void Delete(int id)
        {
            var candidat = _ctx.Candidate.FirstOrDefault(c => c.Id == id);
            if (candidat != null)
            {
                _ctx.Candidate.Remove(candidat);
                _ctx.SaveChanges();
            }
        }


    }
}
