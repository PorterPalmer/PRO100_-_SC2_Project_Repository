using Mathium.Models;
using Mathium.Utility;

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

                // These grade levels will be implemented later.
                case GradeLevel.SixthGrade:
                case GradeLevel.SeventhGrade:
                case GradeLevel.EighthGrade:
                case GradeLevel.NinthGrade:
                case GradeLevel.TenthGrade:
                case GradeLevel.EleventhGrade:
                case GradeLevel.TwelfthGrade:
                    throw new NotImplementedException(
                        "Question generation for this grade level has not been implemented yet.");

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
    }
}