using System;
using System.Collections.Generic;
using System.Text;
using Mathium.Models;

namespace Mathium.Utility
{
    internal class MathSystem
    {
        //Helper Method for Fraction simplifying
        private int GCD(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);

            return GCD(b, a % b);
        }
        //Helper Method for fraction operations
        private int LCM(int a, int b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        //Addition, rounds to 3 decimals
        internal double Add(double a, double b)
        {
            return Math.Round(a + b, 3);
        }
        //Subtraction, rounds to 3 decimals
        internal double Sub(double a, double b)
        {
            return Math.Round(a - b, 3);
        }
        //Multiplcation, rounds to 3 decimals
        internal double Mult(double a, double b)
        {
            return Math.Round(a * b, 3);
        }
        //Division, rounds to 3 decimals
        internal double Divide(double a, double b)
        {
            return Math.Round(a / b, 3);
        }
        //Addition, but you find x instead of the answer
        internal double AddAlgebra(double a, double answer)
        {
            return Math.Round(answer - a, 3);
        }
        //Subtraction, but you find x instead of the answer
        internal double SubAlgebra(double a, double answer)
        {
            return Math.Round(answer + a, 3);
        }
        //Multiplication, but you find x instead of the answer
        internal double MultAlgebra(double a, double answer)
        {
            return Math.Round(answer / a, 3);
        }
        //Division, but you find x instead of the answer
        internal double DivideAlgebra(double a, double answer)
        {
            return Math.Round(answer * a, 3);
        }
        //Add, but for fractions
        internal Fraction AddFraction(Fraction a, Fraction b)
        {
            int lcm = LCM(a.Denominator, b.Denominator);

            int firstMult = (int)MultAlgebra(a.Denominator, lcm);
            int secondMult = (int)MultAlgebra(b.Denominator, lcm);

            Fraction temp = new Fraction((int)((a.Numerator * firstMult) + (b.Numerator * secondMult)), lcm);
            int gcd = GCD(temp.Numerator, temp.Denominator);
            Fraction answer = new Fraction((temp.Numerator / gcd), (temp.Denominator / gcd));

            return answer;
        }
        //Sub, but for fractions
        internal Fraction SubFraction(Fraction a, Fraction b)
        {
            int lcm = LCM(a.Denominator, b.Denominator);

            int firstMult = (int)MultAlgebra(a.Denominator, lcm);
            int secondMult = (int)MultAlgebra(b.Denominator, lcm);

            Fraction temp = new Fraction((int)((a.Numerator * firstMult) - (b.Numerator * secondMult)), lcm);
            int gcd = GCD(temp.Numerator, temp.Denominator);
            Fraction answer = new Fraction((temp.Numerator / gcd), (temp.Denominator / gcd));

            return answer;
        }
        //Mult, but for fractions
        internal Fraction MultFraction(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Numerator;
            int newDenominator = a.Denominator * b.Denominator;

            int gcd = GCD(newNumerator, newDenominator);

            Fraction answer = new Fraction((newNumerator / gcd), (newDenominator / gcd));
            return answer;
        }
        //Divide, but for fractions
        internal Fraction DivideFraction(Fraction a, Fraction b)
        {
            int newNumerator = a.Numerator * b.Denominator;
            int newDenominator = a.Denominator * b.Numerator;

            int gcd = GCD(newNumerator, newDenominator);

            Fraction answer = new Fraction((newNumerator / gcd), (newDenominator / gcd));
            return answer;
        }
    }
}
