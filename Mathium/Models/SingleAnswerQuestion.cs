using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public class SingleAnswerQuestion : MathQuestion
    {
        public double Answer { get; set; }
        
        public SingleAnswerQuestion(string question, GradeLevel gradeLevel, double answer) : base(question, gradeLevel)
        {
            Answer = answer;
        }
    }
}
