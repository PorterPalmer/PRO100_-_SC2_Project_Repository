using Mathium.Models;
using Mathium.Utility;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mathium.Controllers
{
    public class QuestionGenerator
    {
        // MathSystem handles the actual mathematical operations.
        private readonly MathSystem ms = new MathSystem();

        // Random is used to generate different numbers for each question.
        private readonly Random rand = new Random();

        /// <summary>
        /// Generates a math question appropriate for the given grade level.
        /// </summary>
        public MathQuestion GenerateQuestion(GradeLevel gradeLevel)
        {
            switch (gradeLevel)
            {
                case GradeLevel.Kindergarten:
                    return GenerateKindergartenQuestion();

                case GradeLevel.FirstGrade:
                    return GenerateFirstGradeQuestion();

                case GradeLevel.SecondGrade:
                    return GenerateSecondGradeQuestion();

                case GradeLevel.ThirdGrade:
                    return GenerateThirdGradeQuestion();

                case GradeLevel.FourthGrade:
                    return GenerateFourthGradeQuestion();

                case GradeLevel.FifthGrade:
                    return GenerateFifthGradeQuestion();

                case GradeLevel.SixthGrade:
                    return GenerateSixthGradeQuestion();

                case GradeLevel.SeventhGrade:
                    return GenerateSeventhGradeQuestion();

                case GradeLevel.EighthGrade:
                    return GenerateEighthGradeQuestion();

                case GradeLevel.NinthGrade:
                    return GenerateNinthGradeQuestion();

                case GradeLevel.TenthGrade:
                    return GenerateTenthGradeQuestion();

                case GradeLevel.EleventhGrade:
                    return GenerateEleventhGradeQuestion();

                case GradeLevel.TwelfthGrade:
                    return GenerateTwelfthGradeQuestion();

                default:
                    throw new ArgumentOutOfRangeException(nameof(gradeLevel));
            }
        }

        /// <summary>
        /// Kindergarten:
        /// Basic addition using small whole numbers.
        /// </summary>
        private MathQuestion GenerateKindergartenQuestion()
        {
            int a = rand.Next(0, 11);
            int b = rand.Next(0, 11);

            double answer = ms.Add(a, b);

            return new SingleAnswerQuestion(
                GradeLevel.Kindergarten,
                $"{a} + {b} = ?",
                answer);
        }

        /// <summary>
        /// First grade:
        /// Addition and subtraction using larger whole numbers.
        /// </summary>
        private MathQuestion GenerateFirstGradeQuestion()
        {
            int a = rand.Next(1, 21);
            int b = rand.Next(1, 21);

            // Randomly choose between addition and subtraction.
            if (rand.Next(2) == 0)
            {
                double answer = ms.Add(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FirstGrade,
                    $"{a} + {b} = ?",
                    answer);
            }
            else
            {
                // Make sure the answer is not negative.
                if (b > a)
                {
                    (a, b) = (b, a);
                }

                double answer = ms.Sub(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FirstGrade,
                    $"{a} - {b} = ?",
                    answer);
            }
        }

        /// <summary>
        /// Second grade:
        /// Addition, subtraction, multiplication, and basic division.
        /// </summary>
        private MathQuestion GenerateSecondGradeQuestion()
        {
            int operation = rand.Next(4);

            int a;
            int b;
            double answer;

            switch (operation)
            {
                case 0:
                    a = rand.Next(1, 101);
                    b = rand.Next(1, 101);

                    answer = ms.Add(a, b);

                    return new SingleAnswerQuestion(
                        GradeLevel.SecondGrade,
                        $"{a} + {b} = ?",
                        answer);

                case 1:
                    a = rand.Next(1, 101);
                    b = rand.Next(1, a + 1);

                    answer = ms.Sub(a, b);

                    return new SingleAnswerQuestion(
                        GradeLevel.SecondGrade,
                        $"{a} - {b} = ?",
                        answer);

                case 2:
                    a = rand.Next(1, 13);
                    b = rand.Next(1, 13);

                    answer = ms.Mult(a, b);

                    return new SingleAnswerQuestion(
                        GradeLevel.SecondGrade,
                        $"{a} × {b} = ?",
                        answer);

                default:
                    // Generate a division question with a whole-number answer.
                    b = rand.Next(1, 13);
                    int quotient = rand.Next(1, 13);
                    a = b * quotient;

                    answer = ms.Divide(a, b);

                    return new SingleAnswerQuestion(
                        GradeLevel.SecondGrade,
                        $"{a} ÷ {b} = ?",
                        answer);
            }
        }

        /// <summary>
        /// Third grade:
        /// Multiplication/division and basic fraction concepts.
        /// </summary>
        private MathQuestion GenerateThirdGradeQuestion()
        {
            // For now, use multiplication and division.
            // Fraction questions can be expanded as the question system grows.
            if (rand.Next(2) == 0)
            {
                int a = rand.Next(1, 13);
                int b = rand.Next(1, 13);

                double answer = ms.Mult(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.ThirdGrade,
                    $"{a} × {b} = ?",
                    answer);
            }
            else
            {
                int b = rand.Next(1, 13);
                int quotient = rand.Next(1, 13);
                int a = b * quotient;

                double answer = ms.Divide(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.ThirdGrade,
                    $"{a} ÷ {b} = ?",
                    answer);
            }
        }

        /// <summary>
        /// Fourth grade:
        /// Larger multiplication/division problems and fraction operations.
        /// </summary>
        private MathQuestion GenerateFourthGradeQuestion()
        {
            if (rand.Next(2) == 0)
            {
                int a = rand.Next(10, 101);
                int b = rand.Next(2, 13);

                double answer = ms.Mult(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FourthGrade,
                    $"{a} × {b} = ?",
                    answer);
            }
            else
            {
                // Create a division problem with a whole-number answer.
                int b = rand.Next(2, 13);
                int quotient = rand.Next(2, 13);
                int a = b * quotient;

                double answer = ms.Divide(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FourthGrade,
                    $"{a} ÷ {b} = ?",
                    answer);
            }
        }

        /// <summary>
        /// Fifth grade:
        /// Fraction addition and subtraction.
        /// </summary>
        private MathQuestion GenerateFifthGradeQuestion()
        {
            int denominator = rand.Next(2, 11);

            int numeratorA = rand.Next(1, denominator);
            int numeratorB = rand.Next(1, denominator);

            Fraction a = new Fraction(numeratorA, denominator);
            Fraction b = new Fraction(numeratorB, denominator);

            Fraction answer;

            if (rand.Next(2) == 0)
            {
                answer = ms.AddFraction(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FifthGrade,
                    $"{a.Numerator}/{a.Denominator} + " +
                    $"{b.Numerator}/{b.Denominator} = ?",
                    answer.Numerator / (double)answer.Denominator);
            }
            else
            {
                // Keep the answer positive.
                if (numeratorB > numeratorA)
                {
                    (a, b) = (b, a);
                }

                answer = ms.SubFraction(a, b);

                return new SingleAnswerQuestion(
                    GradeLevel.FifthGrade,
                    $"{a.Numerator}/{a.Denominator} - " +
                    $"{b.Numerator}/{b.Denominator} = ?",
                    answer.Numerator / (double)answer.Denominator);
            }
        }

        private MathQuestion GenerateSixthGradeQuestion()
        {
            switch (rand.Next(4))
            {
                case 0:
                    {
                        int a = rand.Next(1, 21);
                        int b = rand.Next(1, 21);

                        double answer = a + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.SixthGrade,
                            $"{a} + {b} = ?",
                            answer);
                    }

                case 1:
                    {
                        double a = rand.Next(1, 101) / 10.0;
                        double b = rand.Next(1, 101) / 10.0;

                        double answer = a + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.SixthGrade,
                            $"{a} + {b} = ?",
                            answer);
                    }

                case 2:
                    {
                        int percent = rand.Next(10, 91) / 10 * 10;
                        int number = rand.Next(2, 11) * 10;

                        double answer = number * percent / 100.0;

                        return new SingleAnswerQuestion(
                            GradeLevel.SixthGrade,
                            $"What is {percent}% of {number}?",
                            answer);
                    }

                default:
                    {
                        int a = rand.Next(1, 10);
                        int b = rand.Next(1, 10);
                        int c = rand.Next(1, 10);

                        double answer = a + b * c;

                        return new SingleAnswerQuestion(
                            GradeLevel.SixthGrade,
                            $"{a} + {b} × {c} = ?",
                            answer);
                    }
            }
        }

        private MathQuestion GenerateSeventhGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        int x = rand.Next(1, 21);
                        int b = rand.Next(1, 21);

                        double answer = x + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.SeventhGrade,
                            $"x + {b} = {answer}; x = ?",
                            x);
                    }

                case 1:
                    {
                        int x = rand.Next(1, 21);
                        int multiplier = rand.Next(2, 10);

                        double answer = multiplier * x;

                        return new SingleAnswerQuestion(
                            GradeLevel.SeventhGrade,
                            $"{multiplier}x = {answer}; x = ?",
                            x);
                    }

                default:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer = a * b;

                        return new SingleAnswerQuestion(
                            GradeLevel.SeventhGrade,
                            $"What is {a} × {b}?",
                            answer);
                    }
            }
        }

        private MathQuestion GenerateEighthGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer = Math.Pow(a, 2) + Math.Pow(b, 2);

                        return new SingleAnswerQuestion(
                            GradeLevel.EighthGrade,
                            $"{a}² + {b}² = ?",
                            answer);
                    }

                case 1:
                    {
                        int x = rand.Next(1, 21);
                        int a = rand.Next(2, 10);
                        int b = rand.Next(1, 21);

                        double result = a * x + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.EighthGrade,
                            $"{a}x + {b} = {result}; x = ?",
                            x);
                    }

                default:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer = a * b;

                        return new SingleAnswerQuestion(
                            GradeLevel.EighthGrade,
                            $"What is the area of a rectangle with length {a} and width {b}?",
                            answer);
                    }
            }
        }

        private MathQuestion GenerateNinthGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        int x = rand.Next(1, 11);
                        int b = rand.Next(1, 21);
                        int c = x + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.NinthGrade,
                            $"x + {b} = {c}; x = ?",
                            x);
                    }

                case 1:
                    {
                        int x = rand.Next(1, 11);

                        double answer = Math.Pow(x, 2);

                        return new SingleAnswerQuestion(
                            GradeLevel.NinthGrade,
                            $"x² = {answer}; x = ?",
                            x);
                    }

                default:
                    {
                        int a = rand.Next(1, 11);
                        int b = rand.Next(1, 11);

                        double answer = a + b;

                        return new SingleAnswerQuestion(
                            GradeLevel.NinthGrade,
                            $"{a} + {b} = ?",
                            answer);
                    }
            }
        }

        private MathQuestion GenerateTenthGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        int a = rand.Next(1, 11);
                        int b = rand.Next(1, 11);

                        double answer = Math.Sqrt(
                            a * a + b * b);

                        return new SingleAnswerQuestion(
                            GradeLevel.TenthGrade,
                            $"√({a}² + {b}²) = ?",
                            answer);
                    }

                case 1:
                    {
                        int baseValue = rand.Next(2, 6);
                        int exponent = rand.Next(2, 5);

                        double answer =
                            Math.Pow(baseValue, exponent);

                        return new SingleAnswerQuestion(
                            GradeLevel.TenthGrade,
                            $"{baseValue}^{exponent} = ?",
                            answer);
                    }

                default:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer = a * b;

                        return new SingleAnswerQuestion(
                            GradeLevel.TenthGrade,
                            $"{a} × {b} = ?",
                            answer);
                    }
            }
        }

private MathQuestion GenerateEleventhGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        // Make sure a > b so the answer is positive.
                        int a = rand.Next(2, 11);
                        int b = rand.Next(1, a);

                        double answer =
                            Math.Pow(a, 2) - Math.Pow(b, 2);

                        return new SingleAnswerQuestion(
                            GradeLevel.EleventhGrade,
                            $"{a}² - {b}² = ?",
                            answer);
                    }

                case 1:
                    {
                        int baseValue = rand.Next(2, 6);
                        int exponent = rand.Next(2, 5);

                        double answer =
                            Math.Pow(baseValue, exponent);

                        return new SingleAnswerQuestion(
                            GradeLevel.EleventhGrade,
                            $"{baseValue}^{exponent} = ?",
                            answer);
                    }

                default:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer = (double)a / b;

                        return new SingleAnswerQuestion(
                            GradeLevel.EleventhGrade,
                            $"{a} ÷ {b} = ?",
                            answer);
                    }
            }
        }


        private MathQuestion GenerateTwelfthGradeQuestion()
        {
            switch (rand.Next(3))
            {
                case 0:
                    {
                        int x = rand.Next(1, 11);

                        double answer =
                            Math.Log10(Math.Pow(10, x));

                        return new SingleAnswerQuestion(
                            GradeLevel.TwelfthGrade,
                            $"log₁₀(10^{x}) = ?",
                            answer);
                    }

                case 1:
                    {
                        int x = rand.Next(1, 11);

                        double answer = Math.Pow(
                            Math.E,
                            x);

                        return new SingleAnswerQuestion(
                            GradeLevel.TwelfthGrade,
                            $"e^{x} = ?",
                            answer);
                    }

                default:
                    {
                        int a = rand.Next(2, 11);
                        int b = rand.Next(2, 11);

                        double answer =
                            Math.Pow(a, b);

                        return new SingleAnswerQuestion(
                            GradeLevel.TwelfthGrade,
                            $"{a}^{b} = ?",
                            answer);
                    }
            }
        }
    }
}