using System;
using System.Collections.Generic;

namespace DzielenieProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<double> liczby = WczytajLiczby();

                if (liczby.Count == 0)
                {
                    throw new InvalidOperationException("Nie wprowadzono żadnych liczb.");
                }

                Console.WriteLine("\nWprowadzone liczby: " + string.Join(", ", liczby));
                Console.WriteLine("\nWyniki dzielenia:");

                for (int i = 0; i < liczby.Count; i++)
                {
                    WykonajDzielenia(liczby, i);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram zakończył działanie. Naciśnij dowolny klawisz...");
                Console.ReadKey();
            }
        }

        static List<double> WczytajLiczby()
        {
            List<double> liczby = new List<double>();

            Console.WriteLine("Program dzieli każdą liczbę przez kolejne liczby w tablicy.");
            Console.WriteLine("Wprowadź liczby (aby zakończyć wprowadzanie, wpisz 'koniec'):");

            while (true)
            {
                Console.Write("Podaj liczbę (lub 'koniec'): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "koniec")
                {
                    break;
                }

                try
                {
                    double liczba = Convert.ToDouble(input);
                    liczby.Add(liczba);
                    Console.WriteLine($"Dodano liczbę: {liczba}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Błąd: Wprowadzona wartość nie jest poprawną liczbą. Spróbuj ponownie.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Błąd: Wprowadzona liczba jest zbyt duża lub zbyt mała. Spróbuj ponownie.");
                }
            }

            return liczby;
        }

        static void WykonajDzielenia(List<double> liczby, int indeksPoczatkowy)
        {
            double aktualnyWynik = liczby[indeksPoczatkowy];
            Console.Write($"{aktualnyWynik}");

            for (int j = indeksPoczatkowy + 1; j < liczby.Count; j++)
            {
                try
                {
                    if (liczby[j] == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    aktualnyWynik /= liczby[j];
                    Console.Write($" / {liczby[j]} = {aktualnyWynik}");
                }
                catch (DivideByZeroException)
                {
                    Console.Write($" / {liczby[j]} = Błąd: Nie można dzielić przez zero!");
                    break;
                }
            }

            Console.WriteLine();
        }
    }
}