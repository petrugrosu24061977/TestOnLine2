


using EntityFramexorkClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TestOnline.Business;
using TestOnline.Common;
using TestOnLine.Common;

namespace TestOnLine.Business
{

public  class ServiceQuestion
    {



        public static IEnumerable<QuestionModel> Get()
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionModel>();
            });
            var candidates = entities.Question.ToList();
            var candidatesModel = new List<QuestionModel>();

            foreach (Question candidate in candidates)
            {
                IMapper iMapper = config.CreateMapper();
                var candidateModel = iMapper.Map<Question, QuestionModel>(candidate);
                candidatesModel.Add(candidateModel);
            }

            return candidatesModel;
        }



        public static QuestionModel Get(int id)
        {
            TestOnlineEntities entities = new TestOnlineEntities();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionModel>();
            });

            var candidate = entities.Question.FirstOrDefault(c => c.Id == id);

            IMapper iMapper = config.CreateMapper();
            var candidateModel = iMapper.Map<Question, QuestionModel>(candidate);

            return candidateModel;
        }

        public static void Post(QuestionModel candidateModel)
        {
            TestOnlineEntities entities = new TestOnlineEntities();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionModel, Question>();
            });

            IMapper iMapper = config.CreateMapper();
            var candidate = iMapper.Map<QuestionModel, Question>(candidateModel);

            entities.Question.Add(candidate);
            entities.SaveChanges();
        }



        public static void Put(int id, QuestionModel candidateModel)
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            var updatedQuestion = entities.Question.FirstOrDefault(c => c.Id == id);

            updatedQuestion.Statement = candidateModel.Statement;

            entities.SaveChanges();

        }


         public static void Delete(int id)
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            var entity = entities.Question.FirstOrDefault(c => c.Id == id);
            if (entity != null)
            {
                entities.Question.Remove(entity);
                entities.SaveChanges();
            }
        }



    }
}
