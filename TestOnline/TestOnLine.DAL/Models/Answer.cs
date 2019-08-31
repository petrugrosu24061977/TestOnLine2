using System;
using System.Collections.Generic;

namespace TestOnline.DAL
{
    public partial class Answer
    {
        public Answer()
        {
            Result = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public bool IsGood { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}
