using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFramexorkClassLibrary;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TestOnLineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        TestOnlineEntities entities = new TestOnlineEntities();

        [HttpGet]
        public ActionResult<IEnumerable<Answer>> Get()
        {
            return entities.Answer.ToList();
        }

        // GET api/answer/5
        [HttpGet("{id}")]
        public ActionResult<Answer> Get(int id)
        {
            var answer = entities.Answer.Find(id);

            return answer;
        }

        // POST api/answer
        [HttpPost]
        public void Post([FromBody] Answer answer)
        {
            if( ModelState.IsValid)
            {
                entities.Answer.Add(answer);
                entities.SaveChanges();
            }

        }

        // PUT api/answer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Answer answer)
        {
            var updatedAnswer = entities.Answer.FirstOrDefault(c => c.Id == id);
            
            updatedAnswer.Code   = answer.Code;
            updatedAnswer.Label  = answer.Label;
            updatedAnswer.IsGood = answer.IsGood;

            entities.SaveChanges();

        }

        // DELETE api/answer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            entities.Answer.Remove(entities.Answer.FirstOrDefault(c => c.Id == id));
            entities.SaveChanges();

        }
    }
}
