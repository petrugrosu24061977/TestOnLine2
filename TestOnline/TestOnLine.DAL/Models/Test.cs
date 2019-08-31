﻿using System;
using System.Collections.Generic;

namespace TestOnline.DAL
{
    public partial class Test
    {
        public Test()
        {
            Candidate = new HashSet<Candidate>();
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Candidate> Candidate { get; set; }
        public ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
