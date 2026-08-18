using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mathium.Models
{
    public class QuestionGenerator
    {
        private readonly Random rand = new Random();

        public MathQuestion GenerateQuestion(GradeLevel gradeLevel)
        {
            switch (gradeLevel)
            {
                case GradeLevel.Kindergarten:
                    return GenerateKindergartenQuestion();

                case GradeLevel.FirstGrade:
                    return GenerateFirstGradeQuestion();

                // More grades to come

                default: 
                    throw new ArgumentOutOfRangeException(nameof(gradeLevel));
            }
        }

        private MathQuestion GenerateKindergartenQuestion()
        {
            int num1 = rand.Next(1, 10);
            int num2 = rand.Next(1, 10);
            int answer = num1 + num2;

            return new SingleAnswerQuestion(
                $"{num1} = {num2}",
                GradeLevel.Kindergarten,
                answer);
        }

        private MathQuestion GenerateFirstGradeQuestion()
        {
            int num1 = rand.Next(1, 20);
            int num2 = rand.Next(1, 20);
            int answer = num1 + num2;

            return new SingleAnswerQuestion(
                $"{num1} + {num2}",
                GradeLevel.FirstGrade,
                answer);
        }
    }
}
