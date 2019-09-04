using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestOnLine.Business.Interfaces;
using TestOnLine.Common;

namespace TestOnLine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateBusiness _candidateBusiness;

        public CandidateController(ICandidateBusiness candidateBusiness)
        {
            _candidateBusiness = candidateBusiness;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> Get()
        {
            return Ok(await _candidateBusiness.GetCandidatesAsync());
        }

        // GET api/candidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateModel>> Get(int id)
        {
            return await _candidateBusiness.GetCandidateByIdAsync(id);
        }

        // POST api/candidate
        [HttpPost]
        public async Task Post([FromBody] CandidateModel candidateModel)
        {
           await _candidateBusiness.CreateCandidateAsync(candidateModel);

        }

        // PUT api/candidate/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CandidateModel candidateModel)
        {
           await _candidateBusiness.UpdateCandidateAsync(id, candidateModel);
        }

        // DELETE api/candidate/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _candidateBusiness.DeleteCandidateAsync(id);
        }
    }
}
