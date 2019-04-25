using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace AlgDSPraktikum
{
    class Program
    {
        static void Main(string[] args)
        {

            IDictionary dictionary;


            Abfrage();
            Abfrage();
            // Auswahl des eigentlichen Typen
            // Abfrage: Welchen Interface-Typen wollen sie verwenden (IMultiSetUnsorted, IMultiSetSorted, ISetUnsorted, ISetSorted)

            #region Interface-Typ-Abfrage
            Console.WriteLine("Welchen Interface-Typen wollen sie verwenden?");
            Console.WriteLine("1. IMultiSetUnsorted");
            Console.WriteLine("2. IMultiSetSorted");
            Console.WriteLine("3. ISetUnsorted");
            Console.WriteLine("4. ISetSorted");
            Console.WriteLine("Bitte Nummer eingeben:");

            string input = "";

            int decision = 0;
            bool correctInput = false;
            do
            {
                input = Console.ReadLine();      

                if ((!(Regex.IsMatch(input, @"^[a-zA-Z]+$"))) && (Regex.IsMatch(input, @"^[1-4]+$")) && input.Length == 1)
                {
                    decision = Convert.ToInt32(input);
                    correctInput = true;
                    Clear();
                }
                else
                {
                    Console.WriteLine("Bitte geben Sie eine gültige Nummer ein!");
                } 
            } while (!correctInput);

            switch (decision)
            {
                case 1:
                    input = "IMultiSetUnsorted";
                    break;
                case 2:
                    input = "IMultiSetSorted";
                    break;
                case 3:
                    input = "ISetUnsorted";
                    break;
                case 4:
                    input = "ISetSorted";
                    break;

            }
            Console.WriteLine($"Sie haben {input} gewählt.");
            #endregion




            // Abfrage: Welchen konkreten Typen wollen sie verwenden
            // Erstellung dieses Typen

            // Execution Phase umgeben von while-schleife (Programm soll ohne Beendigung neu angefangen werden können)
            // Ausführen der Methoden für den gewählten Typ (print, insert, delete, search)



        }
        private static void Abfrage()
        {

        }
    }
}
