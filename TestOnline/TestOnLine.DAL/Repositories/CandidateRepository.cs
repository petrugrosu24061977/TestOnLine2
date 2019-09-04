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



        public async Task<CandidateModel> GetCandidateByIdAsync(int id)
        {

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateModel>();
            });

            var candidate = await  _ctx.Candidate.SingleOrDefaultAsync(c => c.Id == id);

            IMapper iMapper = config.CreateMapper();
            var candidateModel = iMapper.Map<Candidate, CandidateModel>(candidate);

            return candidateModel;
        }

        public async Task CreateCandidateAsync(CandidateModel candidateModel)
        {

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CandidateModel, Candidate>();
            });

            IMapper iMapper = config.CreateMapper();
            var candidate = iMapper.Map<CandidateModel, Candidate>(candidateModel);

            await _ctx.Candidate.AddAsync(candidate);
            _ctx.SaveChanges();
        }



        public async Task UpdateCandidateAsync(int id, CandidateModel candidateModel)
        {
            var updatedCandidate = await _ctx.Candidate.SingleOrDefaultAsync(c => c.Id == id);
            if (updatedCandidate != null)
            {

                updatedCandidate.LastName = candidateModel.LastName;
                updatedCandidate.FirstName = candidateModel.FirstName;

                _ctx.SaveChanges();
            }

        }


        public async Task DeleteCandidateAsync(int id)
        {
            var candidat = await _ctx.Candidate.SingleOrDefaultAsync(c => c.Id == id);
            if (candidat != null)
            {
                _ctx.Candidate.Remove(candidat);
                _ctx.SaveChanges();
            }
        }


    }
}
