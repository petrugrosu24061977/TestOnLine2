﻿using System.Collections.Generic;

namespace TestOnLine.Dal.Models
{
    public partial class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Statement { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
