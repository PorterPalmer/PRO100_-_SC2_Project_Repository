using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public abstract class MathQuestion
    {
        public string Question { get; set; }
        public GradeLevel GradeLevel { get; set; }

        protected MathQuestion(string question, GradeLevel gradeLevel)
        {
            Question = question;
            GradeLevel = gradeLevel;
        }
    }
}
