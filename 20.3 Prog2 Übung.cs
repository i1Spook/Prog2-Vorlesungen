using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Bruch b1 = new Bruch(1, 2);
            Bruch b2 = new Bruch(3);
            Bruch b3 = b1 * b2;
            Console.WriteLine($"{b3}");
            Bruch b4 = b1 + b2;
            Console.WriteLine($"{b4}");
            Bruch b5 = b1 - b2;
            Console.WriteLine($"{b5}");
            Bruch b6 = b1 / b2;
            Console.WriteLine($"{b6}");
            Bruch b7 = b1 + 2 * b2;

        }
    }
    class Bruch
    {
        int zaehler, nenner;
        public Bruch(int zaehler, int nenner = 1)
        {
            this.zaehler = zaehler;
            this.nenner = nenner;
        }
        public static Bruch operator * (Bruch b1, Bruch b2)
        {
            Bruch b = new Bruch(b1.zaehler * b2.zaehler, b1.nenner * b2.nenner);
            return b;
        }
        public static Bruch operator + (Bruch b1, Bruch b2)
        {
            Bruch b = new Bruch((b1.zaehler * b2.nenner) + (b2.zaehler * b1.nenner), b1.nenner * b2.nenner);
            return b;
        }
        public static Bruch operator - (Bruch b1, Bruch b2)
        {
            Bruch b = new Bruch((b1.zaehler * b2.nenner) - (b2.zaehler * b1.nenner), b1.nenner * b2.nenner);
            return b;
        }
        public static Bruch operator / (Bruch b1, Bruch b2)
        {
            Bruch b = new Bruch((b1.zaehler * b2.nenner), (b2.zaehler * b1.nenner));
            return b;
        }
        public static Bruch Kuerzen (Bruch b)
        {
            int t;
            int u = b.zaehler;
            int v = b.nenner;

            while (v != 0)
            {
                t = u % v;
                u = v;
                v = t;
            }
            b.zaehler /= u;
            b.nenner /= u;
            return b; //new Bruch(zaehler/u, nenner/u);
        }
        //alternativ, per Lambda-Schreibweise
        //public static Bruch operator * (Bruch b1, Bruch b2) => Kuerzen(new Bruch(b1.zaehler *b2.zaehler, b1.nenner*b2.nenner));
        //"links" wird abgebildet auf "rechts"
        public override string ToString() => $"{zaehler}/{nenner}"; //überschreibt Standard-Ausgabeform

        //Überschreiben = Neue Implementierung, welche bestehende ersetzt
        //Überladen = weitere Implementierung für neuen Datentyp

        public static implicit operator Bruch (int x) => new Bruch (x,1); //implizierte Konvertierung von int in Bruch
    }
}
