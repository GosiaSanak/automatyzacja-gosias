﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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
    /*var suma = new Calc(10, 20);
    var roznica = new Calc(2, 9);
    var iloczyn = new Calc(4, 5);
    var iloraz = new Calc(6, 7);
    */
}