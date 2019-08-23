using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFramexorkClassLibrary;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using TestOnline.Common;
using TestOnLine.Business;
using TestOnLine.Common;

namespace TestOnLineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class questionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<QuestionModel> Get()
        {
            return ServiceQuestion.Get();
        }

        // GET api/question/5
        [HttpGet("{id}")]
        public ActionResult<QuestionModel> Get(int id)
        {
            return ServiceQuestion.Get(id);
        }

        // POST api/question
        [HttpPost]
        public void Post([FromBody] QuestionModel questionModel)
        {
            ServiceQuestion.Post(questionModel);

        }

        // PUT api/question/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] QuestionModel questionModel)
        {
            ServiceQuestion.Put(id, questionModel);
        }

        // DELETE api/question/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ServiceQuestion.Delete(id);
        }
    }
}
