using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cwiczenie1.Tests
{
    public class CalcTests
    {
        // JEZELI_podam_liczbe_5_i_10_WOWCZAS_Suma_zwraca_15

        [Fact]
        public void Dodawanie_zwraca_sume_dwoch_liczb()
        {
                
            //arrange
            var calculator = new Calc(20, 15);

            //act
            var result = calculator.Suma();

            //assert
            Assert.Equal(35, result);
        }

        [Fact]
        public void Odejmowanie_zwraca_roznice_dwoch_liczb()
        {

            //arrange
            var calculator = new Calc(10, 5);

            //act
            var result = calculator.Roznica();

            //assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Iloraz_zwraca_wynik_dzielenia_dwoch_liczb()
        {

            //arrange
            var calculator = new Calc(10, 5);

            //act
            var result = calculator.Iloraz();

            //assert
            Assert.Equal(2, result);
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
