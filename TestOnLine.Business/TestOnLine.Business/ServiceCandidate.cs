using EntityFramexorkClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TestOnline.Business;
using TestOnline.Common;

namespace TestOnLine.Business
{

public  class ServiceCandidate
    {



        public static IEnumerable<CandidateModel> Get()
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateModel>();
            });
            var candidates = entities.Candidate.ToList();
            var candidatesModel = new List<CandidateModel>();

            foreach (Candidate candidate in candidates)
            {
                IMapper iMapper = config.CreateMapper();
                var candidateModel = iMapper.Map<Candidate, CandidateModel>(candidate);
                candidatesModel.Add(candidateModel);
            }

            return candidatesModel;
        }



        public static CandidateModel Get(int id)
        {
            TestOnlineEntities entities = new TestOnlineEntities();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate, CandidateModel>();
            });

            var candidate = entities.Candidate.FirstOrDefault(c => c.Id == id);

            IMapper iMapper = config.CreateMapper();
            var candidateModel = iMapper.Map<Candidate, CandidateModel>(candidate);

            return candidateModel;
        }

        public static void Post(CandidateModel candidateModel)
        {
            TestOnlineEntities entities = new TestOnlineEntities();

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CandidateModel, Candidate>();
            });

            IMapper iMapper = config.CreateMapper();
            var candidate = iMapper.Map<CandidateModel, Candidate>(candidateModel);

            entities.Candidate.Add(candidate);
            entities.SaveChanges();
        }



        public static void Put(int id, CandidateModel candidateModel)
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            var updatedCandidate = entities.Candidate.FirstOrDefault(c => c.Id == id);

            updatedCandidate.LastName = candidateModel.LastName;
            updatedCandidate.FirstName = candidateModel.FirstName;

            entities.SaveChanges();

        }


         public static void Delete(int id)
        {
            TestOnlineEntities entities = new TestOnlineEntities();
            var entity = entities.Candidate.FirstOrDefault(c => c.Id == id);
            if (entity != null)
            {
                entities.Candidate.Remove(entity);
                entities.SaveChanges();
            }
        }



    }
}
