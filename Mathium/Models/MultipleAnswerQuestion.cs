using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public class MultipleAnswerQuestion : MathQuestion
    {
        public List<double> Answers { get; set; }

        public MultipleAnswerQuestion(
            string question,
            GradeLevel gradeLevel,
            List<double> answers)
            : base(question, gradeLevel)
        {
            Answers = answers;
        }
    }
}
