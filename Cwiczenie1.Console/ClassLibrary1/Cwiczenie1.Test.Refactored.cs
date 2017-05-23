using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cwiczenie1.Tests
{
    public class CalcTestsRefactored
    {
        private Calc _calculator;

        public CalcTestsRefactored() //construktor
        {
            _calculator = new Calc(9, 3);
        }

        [Fact]
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
            var result = _calculator.Suma();
            Assert.Equal(12, result);
        }

        [Theory] //zawsze zamiast [Fact] przy wprowadzaniu zmiennych
        [InlineData(1,2,-1)] //zawsze zamiast [Fact] przy wprowadzaniu zmiennych
        public void Odejmowanie_zwraca_roznice_dwoch_liczb(int x, int y, int expected)
        {

            //arrange
            var calculator = new Calc(x, y);

            //act
            var result = calculator.Roznica();

            //assert
            Assert.Equal(expected, result);
        }

        [Theory] 
        [InlineData(1, 2, 0.5)]
        public void Iloraz_zwraca_wynik_dzielenia_dwoch_liczb(int x, int y, double expected)
        {

            //arrange
            var calculator = new Calc(x, y);

            //act
            var result = calculator.Iloraz();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Iloczyn_zwraca_wynik_mnozenia_dwoch_liczb()
        {

            //arrange
            var calculator = new Calc(10, 15);

            //act
            var result = calculator.Iloczyn();

            //assert
            Assert.Equal(150, result);
        }
    }
}
