using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public class MultipleAnswerQuestion : MathQuestion
    {
        public List<double> Answers { get; protected set; }

        public MultipleAnswerQuestion(
            GradeLevel gradeLevel,
            string question,
            List<double> answers)
            : base(gradeLevel, question)
        {
            Answers = answers;
        }
    }
}
