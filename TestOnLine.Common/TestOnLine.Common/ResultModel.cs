
namespace TestOnLine.Common 
{
    using System;
    using System.Collections.Generic;
    using TestOnline.Common;

    public partial class ResultModel
    {
        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public Nullable<int> AnswerId { get; set; }
    
        public virtual AnswerModel Answer { get; set; }
        public virtual QuestionModel Question { get; set; }
        public virtual TestModel Test { get; set; }
    }
}
