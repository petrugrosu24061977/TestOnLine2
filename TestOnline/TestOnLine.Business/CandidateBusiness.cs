using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestOnline.Common;

namespace TestOnLine.Business
{

public  class CandidateRepository
    {



        public static IEnumerable<CandidateModel> Get()
        {
            return CandidateRepository.Get();
        }



        public static CandidateModel Get(int id)
        {
            return CandidateRepository.Get(id);
        }


        public static void Post(CandidateModel candidateModel)
        {
            CandidateRepository.Post(candidateModel);
        }


        public static void Put(int id, CandidateModel candidateModel)
        {
            CandidateRepository.Put(id, candidateModel);
        }


         public static void Delete(int id)
        {
            CandidateRepository.Delete(id);
        }



    }
}
