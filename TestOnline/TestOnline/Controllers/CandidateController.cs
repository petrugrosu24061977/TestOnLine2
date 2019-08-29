using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TestOnline.Common;
using TestOnLine.Business;

namespace TestOnLineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
            [HttpGet]
        public IEnumerable<CandidateModel> Get()
        {
            return CandidateBusiness.Get();
        }

        // GET api/candidate/5
        [HttpGet("{id}")]
        public ActionResult<CandidateModel> Get(int id)
        {
                 return CandidateBusiness.Get(id);
        }

        // POST api/candidate
        [HttpPost]
        public void Post([FromBody] CandidateModel candidateModel)
        {
            CandidateBusiness.Post(candidateModel);

        }

        // PUT api/candidate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CandidateModel candidateModel)
        {
            CandidateBusiness.Put(id, candidateModel);
        }

        // DELETE api/candidate/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CandidateBusiness.Delete(id);
        }
    }
}
