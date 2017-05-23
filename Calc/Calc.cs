namespace Calculator
{
    public class Calc
    {
        private double a, b;
        public Calc(double liczba1, double liczba2)
        {
            a = liczba1;
            b = liczba2;
        }
        public double Suma()
        {
            return a + b;
        }
        public double Roznica()
        {
            return a - b;
        }

        public double Iloczyn()
        {
            return a * b;
        }

        public double Iloraz()
        {
            return a / b;
        }

    }
}
