using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QuizProgramMVC.Models;
using QuizProgramMVC.DAL;
using QuizLibrary;

namespace QuizProgramMVC.Controllers
{
    public class QuizController : Controller
    {

        //db context
        private QuizDbContext db = new QuizDbContext();

        private Student SelectRandomStudent(List<Student> students)
        {
            Random rand = new Random();
            Student selected = students[rand.Next(students.Count)];
            students.Remove(selected);
            return selected;

        }

        private Question SelectRandomQuestion(List<Question> questions)
        {
            Random rand = new Random();
            Question selected = questions[rand.Next(questions.Count)];
            questions.Remove(selected);
            return selected;
        }

        private QuizViewModel GetQuizViewModel()
        {
            QuizViewModel qvm = new QuizViewModel();
            qvm.Questions = db.Questions.ToList();
            qvm.Students = db.Students.ToList();

            return qvm;
        }

        // GET: Quiz
        public ActionResult Index()
        {

            QuizViewModel qvm;

            if (Session["QuizViewModel"] == null)
            {
                qvm = GetQuizViewModel();
                Session["QuizViewModel"] = qvm;
            }
            else
            {
                qvm = Session["QuizViewModel"] as QuizViewModel;
            }

            //check to see if we've emptied things out
            if (qvm.Questions.Count == 0 || qvm.Students.Count == 0)
            {
                qvm = GetQuizViewModel();
            }

            qvm.SelectedQuestion = SelectRandomQuestion(qvm.Questions);
            qvm.SelectedStudent = SelectRandomStudent(qvm.Students);

            //save after operations
            Session["QuizViewModel"] = qvm;

            return View(qvm);
        }

        [HttpPost]
        public ActionResult AnsweredCorrectly(int? id)
        {
            Student student = null;
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Quiz View Model is valid");

                student = db.Students.Find(id);

                student.Attempts++;
                student.Correct++;

                db.SaveChanges();

                Debug.WriteLine("First Name: {0} - Last Name: {1}",
                                 student.FirstName,
                                 student.LastName);
            }
            else
            {
                Debug.WriteLine("Model state invalid?");
            }

            return View(student);

        }

        [HttpPost]
        public ActionResult AnsweredIncorrectly(int? id)
        {
            Student student = null;
            if (ModelState.IsValid)
            {
                Debug.WriteLine("Quiz View Model is valid");

                student = db.Students.Find(id);

                student.Attempts++;

                db.SaveChanges();

                Debug.WriteLine("First Name: {0} - Last Name: {1}",
                                 student.FirstName,
                                 student.LastName);
            }
            else
            {
                Debug.WriteLine("Model state invalid?");
            }

            return View(student);
        }
    }
}