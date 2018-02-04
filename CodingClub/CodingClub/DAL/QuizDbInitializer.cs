using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuizLibrary;

namespace QuizProgramMVC.DAL
{
    public class QuizDbInitializer : DropCreateDatabaseIfModelChanges<QuizDbContext>
    //public class QuizDbInitializer : DropCreateDatabaseAlways<QuizDbContext>
    {

        protected override void Seed(QuizDbContext context)
        {
            var students = new List<Student>
            {
                new Student() {FirstName = "Freddy", LastName = "Krueger" },
                new Student() {FirstName = "Michael", LastName = "Myers" },
                new Student() {FirstName = "Jason", LastName = "Voorhees" },
                new Student() {FirstName = "Hannibal", LastName="Lecter" },
                new Student() {FirstName = "Samara", LastName="Morgan" },
                new Student() {FirstName = "Norman", LastName="Bates" },
                new Student() {FirstName = "Carrie", LastName="White" },
                new Student() {FirstName = "Jacquotte", LastName="Delahaye" },
                new Student() {FirstName = "Jeanne", LastName="de Clisson" },
                new Student() {FirstName = "Grace", LastName="O'Malley" }
            };

            //ForEach is a LINQ function
            students.ForEach(s => context.Students.Add(s));

            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            var questions = new List<Question>
            {
                new Question() { QuestionText = "Classes are like",
                                 AnswerText = "Blueprints",
                                 QuestionDate=DateTime.Now},
                new Question() { QuestionText = "An int is a ",
                                 AnswerText = "Whole Number",
                                 QuestionDate=DateTime.Now },
                new Question() { QuestionText = "C# is a",
                                 AnswerText = "Object-Oriented Programming Language",
                                 QuestionDate=DateTime.Now },
                new Question() { QuestionText = "Constructors",
                                 AnswerText = "Have no return type",
                                 QuestionDate=DateTime.Now },
                new Question() { QuestionText = "Methods",
                                 AnswerText = "Are modular building blocks for your program",
                                 QuestionDate=DateTime.Now }
            };

            questions.ForEach(q => context.Questions.Add(q));
            try
            {
                //_context.SaveChanges();
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}