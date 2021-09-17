using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project3.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options) 
        {

        }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
