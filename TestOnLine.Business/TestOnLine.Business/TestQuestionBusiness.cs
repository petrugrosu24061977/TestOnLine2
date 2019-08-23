namespace TestOnline.Business
{
    using System;
    using System.Collections.Generic;
    using TestOnLine.Business;

    public partial class TestQuestionBusiness
    {
        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
    
        public virtual QuestionBusiness Question { get; set; }
        public virtual TestBusiness Test { get; set; }
    }
}
