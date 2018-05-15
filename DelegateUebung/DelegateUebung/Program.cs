using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateUebung
{
    class Program
    {
        delegate bool MeinTest<TYP>(TYP x);
        delegate double MeineFkt(double x); //Delegate sagt: "MeineFkt" ist Stellvertreter für alle Funktionen die double-Wert als Eingabe und Rückgabe haben
        static double[] ApplyAll(MeineFkt fkt, params double[] werte) //Bekommt meine Delegate-Funktion und ein double Array.
        {                                                             //Delegate-Funktion wird durch eigene Funktion beim Aufruf ersetzt.
            double[] erg = new double[werte.Length];
            for (int i = 0; i < werte.Length; i++)
            {
                erg[i] = fkt(werte[i]); //Hier wird ein double erwartet, da dies durch die delegate-Funktion vorgegeben ist
                Console.WriteLine(erg[i]);
            }
            return erg;
        }
        static TYP[] Select<TYP>(MeinTest<TYP> test, params TYP[] werte) //TYP für Generische Funktion (ersetzen mit double)
        {
            List<TYP> erg = new List<TYP>();
            for (int i = 0; i < werte.Length; i++)
            {
                if (test(werte[i]) == true)
                {
                    Console.WriteLine(werte[i]);
                    erg.Add(werte[i]);
                }
            }
            return erg.ToArray();
        }
        static double Gehaltserhoeung(double x)
        {
            return x * 1.02;
        }
        static void Main(string[] args)
        {
            ApplyAll(x => x*1.02, 10, 30, 40, 50, 60, 70, 80, 100); //Lambda-Schreibweise x=> x*1.02 ("x wird abgebildet auf x*1.02")
            ApplyAll(Gehaltserhoeung, 10, 30, 40, 50, 60, 80, 100); //Selbes wie drüber nur länger/ausführlicher
            ApplyAll(delegate (double x) { return x * 1.02; }, 30, 40, 50, 60, 70, 80, 100);
            //delegate ~ Anweisung an Compiler: Im Anschluss folgt Programmcode 
            //und aus diesem eine anonyme Methode machen (d.h. NUR der Compiler kennt Namen der Funktion, bzw genauer die Referenz auf diese Funktion)
            //Diese Funktionsreferenz wird dann an fkt übergeben.
            ApplyAll(x => x* x, ApplyAll(x => x + 1, 10, 20, 30, 40, Math.PI, 60)); //Zweites ApplyAll liefert neues double[] womit das erste ApplyAll dann rechnet
            Select(x => x >= 30 && x <= 60, 10, 20, 30, 40, 50, 60, 70, 80);
            Select(x => x % 15 == 0, 10, 20, 30, 40, 50, 60, 70, 80);
            Select(x => x.Contains("er"), "Berta", "Claudia", "Dieter");
            Select(x => x.StartsWith("C"), "Berta", "Claudia", "Dieter");
        }
    }
}