using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var candidates = await _ctx.Candidate.ToListAsync();
            return candidates.Select(c => new CandidateModel
            {
                Id = c.Id
            });
        }
    }
}
