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
    public class ValuesController : ControllerBase
    {
        private readonly ICandidateBusiness _candidateBusiness;

        public ValuesController(ICandidateBusiness candidateBusiness)
        {
            _candidateBusiness = candidateBusiness;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> Get()
        {
            return Ok(await _candidateBusiness.GetCandidatesAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
