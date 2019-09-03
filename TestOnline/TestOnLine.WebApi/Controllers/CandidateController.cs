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
        public ActionResult<CandidateModel> Get(int id)
        {
            return _candidateBusiness.Get(id);
        }

        // POST api/candidate
        [HttpPost]
        public void Post([FromBody] CandidateModel candidateModel)
        {
            _candidateBusiness.Post(candidateModel);

        }

        // PUT api/candidate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CandidateModel candidateModel)
        {
            _candidateBusiness.Put(id, candidateModel);
        }

        // DELETE api/candidate/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _candidateBusiness.Delete(id);
        }
    }
}
