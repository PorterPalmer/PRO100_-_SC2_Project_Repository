using System;
using System.Collections.Generic;
using System.Text;

namespace Mathium.Models
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        //Constructor checks for denominator of 0, throws an error
        //also checks for negative denominator, for ease, itll switch so the denominator is always positive, and make the numerator negative
        //Should work for double negatives, as itll just flip the numerator into a positive
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be 0");
            }
            else if (denominator < 0)
            {
                Numerator = -numerator;
                Denominator = Math.Abs(denominator);
            }
            else
            {
                Numerator = numerator;
                Denominator = denominator;
            }
        }
    }

}
