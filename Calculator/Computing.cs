namespace Calculator
{
    public class Computing
    {
        public string OddOrEven(int value)
        {
            return value % 2 == 0 ? "Even" : "Odd";
        }

        public int CalculateAge(int birthDate, int currentYear)
        {
            if (birthDate < 0)
            {
                return 0;
            }

            if (birthDate == 0 || currentYear == 0)
            {
                throw new ArgumentException();
            }

            return currentYear - birthDate;
        }


        public bool IsPrime(int value)
        {
            if(value<2)
            {
                return false;
            }
            //sqrt of 25 is 5
            for(int diviser=2; diviser<=Math.Sqrt(value); ++diviser)
            {
                if (value % diviser == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
