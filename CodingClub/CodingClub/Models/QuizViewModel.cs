using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using QuizProgramMVC.DAL;
using QuizLibrary;

namespace QuizProgramMVC.Models
{
    public class QuizViewModel
    {
        public List<Student> Students { get; set; }

        public Student SelectedStudent { get; set; }
        public List<Question> Questions { get; set; }

        public Question SelectedQuestion { get; set; }

        public QuizViewModel()
        {

            Students = new List<Student>();
            Questions = new List<Question>();

        }
    }
}