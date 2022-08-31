using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Stackoverflow.Model;

namespace Stackoverflow.Data.Dal
{
    public class EfContext:DbContext
    {
        public EfContext(DbContextOptions<EfContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Data Source= 10.30.50.92;Initial Catalog=CForum;Integrated Security=True");
        //}
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
