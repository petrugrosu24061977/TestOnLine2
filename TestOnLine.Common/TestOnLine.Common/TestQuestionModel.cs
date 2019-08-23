namespace TestOnline.Common
{
    using System;
    using System.Collections.Generic;
    using TestOnLine.Common;

    public partial class TestQuestionModel
    {
        public int Id { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
    
        public virtual QuestionModel Question { get; set; }
        public virtual TestModel Test { get; set; }
    }
}
