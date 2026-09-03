using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public class SingleAnswerQuestion : MathQuestion
    {
        public double Answer { get; protected set; }

        public SingleAnswerQuestion(
            GradeLevel gradeLevel,
            string question,
            double answer)
            : base(gradeLevel, question)
        {
            Answer = answer;
        }
    }
}
