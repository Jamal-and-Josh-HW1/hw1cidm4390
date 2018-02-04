using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using QuizLibrary;

namespace QuizProgramMVC.DAL
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext() : base("QuizDbContext")
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuestionAsked> QuestionsAsked { get; set; }

        //public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}