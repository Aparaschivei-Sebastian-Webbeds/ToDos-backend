using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project3.Data
{
    public class Objective
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool completed { get; set; }
    }
}
