using System;
using System.Globalization;
using System.Threading;

namespace MiejscaZerowe
{
    public class Program
    {

        public static void Main(string[] args)
        {

            //CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread......;
            //customCulture.NumberFormat.NumberDecmalSeparator = ".";
            //customCulture.NumberFormat.NumberNegativePattern = 1;
            //customCulture.NumberFormat.NumberGroupSeparator = "";
            //System.Threading.Thread.CurrentThread.CurrentCulture = customculture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            if (args.Length == 0)
            {
                Console.Write("Podaj wartość współczynnika: a = ");
                string a = Console.ReadLine();
                   

                Console.Write("Podaj wartość współczynnika: b = ");
                string b = Console.ReadLine();
                

                Console.Write("Podaj wartość współczynnika: c = ");
                string c = Console.ReadLine();
                

                var odp = Calculate(new string[] { a, b, c }); 
                Console.WriteLine(odp);


            }
            else
            {
                Console.WriteLine(Calculate(args));
            }
            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public static string Calculate(string[] args)
        {
            
            if (args.Length == 0)
            {
                string OczekiwanyWynik = "Nie podano żadnych współczynników.";
                return OczekiwanyWynik;
            }
            else if (args.Length == 1)
            {
                string OczekiwanyWynik = "Podano 1 zamiast 3 współczynników.";
                return OczekiwanyWynik;
            }
            else if (args.Length == 2)
            {
                string OczekiwanyWynik = "Podano 2 zamiast 3 współczynników.";
                return OczekiwanyWynik;
            }
            else if (args.Length == 3)
            {

                bool niepA = double.TryParse(args[0], out double a);
                bool niepB = double.TryParse(args[1], out double b);
                bool niepC = double.TryParse(args[2], out double c);
             // convert i catch zamiast TryParse

                if (niepA == false)
                {
                    string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'a' funkcji.";
                    return OczekiwanyWynik;
                }
                else if (niepB == false)
                {
                    string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'b' funkcji.";
                    return OczekiwanyWynik;
                }
                else if (niepC == false)
                {
                    string OczekiwanyWynik = "Niepoprawna wartość współczynnika 'c' funkcji.";
                    return OczekiwanyWynik;
                }
                else if (a == 0 && b == 0 && c == 0)
                
                {
                    string OczekiwanyWynik = "Nieskończenie wiele miejsc zerowych.";
                    return OczekiwanyWynik;
                }
                else if (a == 0 && b == 0 && c != 0)

                {
                    string OczekiwanyWynik = "Brak miejsc zerowych.";
                    return OczekiwanyWynik;
                }
                else if (a == 0 && c == 0 && b != 0 )

                {
                    string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0";
                    return OczekiwanyWynik;
                }
                else if (b == 0 && c == 0 && a != 0)

                {
                    string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = 0";
                    return OczekiwanyWynik;
                }

                double x1 = 0;
                double x2 = 0;





                var delta = b*b - 4*a*c;

                if (a==0 && c != 0 && b != 0)
                {
                    x1 = -c / b;

                    string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = " + x1;
                    return OczekiwanyWynik;
                }
                    
                if (a !=0 && b == 0 && c != 0)
                {
                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                    string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = " + Math.Round(x1,2) + ", x2 = " + Math.Round(x2,2);
                    return OczekiwanyWynik;
                }
                if (a != 0 && b != 0 && c == 0)
                {
                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                    string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = " + Math.Round(x1, 2) + ", x2 = " + Math.Round(x2, 2);
                    return OczekiwanyWynik;
                }
                else if (delta > 0)
                {
                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);

                    string OczekiwanyWynik = "Dwa miejsca zerowe: x1 = " + x1 + ", x2 = " + x2;
                    return OczekiwanyWynik;

                }
                else if (delta == 0)
                {
                    x1 = -b / (2 * a);

                    string OczekiwanyWynik = "Jedno miejsce zerowe: x0 = " + x1;
                    return OczekiwanyWynik;

                }

                else if (delta < 0)
                {
                        string OczekiwanyWynik = "Brak miejsc zerowych.";
                        return OczekiwanyWynik;

                }
                
                
            }
            else if (args.Length > 3)
            {
                string OczekiwanyWynik = "Podano więcej niż 3 współczynniki.";
                return OczekiwanyWynik;
            }
                

            // Napisz implementację metody 'Calculate' obliczającej miejsca zerowe funkcji kwadratowej
            // o podanych współczynnikach a, b oraz c.
            //
            // Metoda ta przyjmuje jako argumenty jednowymiarowy string array 'args'
            // gdzie poszczególne elementy tego string array 'args' to współczynnyki a, b oraz c funkcji kwadratowej.
            //
            // Metoda ma zwracć informację o wyliczonych miejscach zerowych jako string, przy czym:
            // - pierwszy element string array 'args' to współczynnik a, drugi to współczynnik b, trzeci to współczynnik c
            // - wymagane jest podanie dokładnie trzech współczynników a. b oraz c
            // - jeśli string array 'args' zawiera mniej lub więcej niż trzy elementy, metoda zwrócić ma informację o błędzie
            // - jeśli wartość któregoś ze współczynników (elementy string array 'args') nie może zostać zapisana jako zmienna
            //   typu double, metoda zwrócić ma informację o błędnej wartości współczynnika
            // - dokładność wyliczenia miejsc zerowych to dwa miejsca po przecinku
            // - wartości ułamkowe współczynników mogą być podane wyłącznie z kropką jako separatorem części dziesiętnych,
            //   np. 1.3 lub 7.985 (wartość 1,3 lub 7,985 powinny być uznane za błędne)
            // - wartości ujemne współczynników oznaczane są poprzez - przed liczbą, np. -1.7 (wartość - 1.7 będzie zatem błędna)
            //
            // Aby ułatwić wykonanie tego zadania, w ramach solution dodany został drugi projekt 'TestMejscZerowych',
            // w którym zdefiniowane zostały testy sprawdzające poprawnośc implementacji metody 'Calculate'. Aby wykonać te testy,
            // otwóz Test Explorer (wybierz menu 'Test' -> 'Windows' -> 'Test Explorer') i kliknij 'Run All'.
            //
            // Metoda 'Main' pozwala na uruchomienie aplikacji 'MejscaZerowe' i zweryfikowania (manualnego) jakie rezultaty zwraca
            // metoda 'Calculate' (na początku próba dokonania obliczeń skończy się wyjątkiem, ponieważ metoda 'Calculate' nie
            // jest jeszcze zaimplementowana. Aby uruchomić 'MiejscaZerowe' po prostu klikniej 'Start' na pasku narzędzi.
            //
            // Zalecamy nie zmieniać implementacji metody 'Main', ponieważ nie to jest celem tego zadania.
            //
            // Wykonanie zadania NIE WYMAGA żadnych modyfikacji projektu 'TestMejscZerowych'.
            //
            // Aby możliwe było wykonanie testów, metoda 'Calculate' musi być metodą publiczną (to pozwala na dostęp do niej
            // z poziomu projektu TestMiejscZerowych.
        }
    }
}
