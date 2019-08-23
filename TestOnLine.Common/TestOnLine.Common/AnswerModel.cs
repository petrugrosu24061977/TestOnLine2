namespace TestOnline.Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnswerModel
    {
   
        public int Id { get; set; }
        public string Code { get; set; }
        public string Label { get; set; }
        public bool IsGood { get; set; }
    
    }
}

