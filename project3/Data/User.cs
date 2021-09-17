using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project3.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
