
namespace TestOnLine.Business 
{
    using System;
    using System.Collections.Generic;
    using TestOnline.Business;

    public partial class ResultBusiness
    {
        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public Nullable<int> AnswerId { get; set; }
    
        public virtual BusinessAnswer Answer { get; set; }
        public virtual QuestionBusiness Question { get; set; }
        public virtual TestBusiness Test { get; set; }
    }
}
