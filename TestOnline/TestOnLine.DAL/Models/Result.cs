﻿namespace TestOnLine.Dal.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int? AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
