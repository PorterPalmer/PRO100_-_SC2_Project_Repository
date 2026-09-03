using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public abstract class MathQuestion
    {
        public GradeLevel GradeLevel { get; protected set; }
        public string Question { get; protected set; }

        protected MathQuestion(GradeLevel gradeLevel, string question)
        {
            GradeLevel = gradeLevel;
            Question = question;
        }
    }
}
