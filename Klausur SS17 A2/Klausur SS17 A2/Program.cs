using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausur_SS17_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            CPoint p1 = new CPoint(10, 10);
            CPoint p2 = p1 * 2;   // Skalarprodukt (alle Komponenten werden mit dem Faktor multipliziert)
            CPoint p3 = p2 - p1;  // Differenz zweier Vektoren
            double d = p3;        // Vektorlänge (mittels Konvertierung nach double)
            if (p2 - p1 == p1) Console.WriteLine("Punkte sind gleich!");
            Console.WriteLine(p2 * 3 - p1);
            Console.WriteLine(d);
        }
    }
    class CPoint
    {
        double x, y;
        public CPoint(double x, double y) { this.x = x; this.y = y; }
        public override string ToString() => $"({x},{y})";

        public static implicit operator double(CPoint p1)
        {
            return Math.Sqrt((p1.x * p1.x) + (p1.y * p1.y));
        }
        public static CPoint operator *(CPoint p1, double faktor)
        {
            CPoint p2 = new CPoint(0, 0);
            p2.x = p1.x * faktor;
            p2.y = p1.y * faktor;
            return p2;
        }
        public static CPoint operator -(CPoint p1, CPoint p2)
        {
            //p1-p2 = p1 + (-p2)
            
            CPoint p3 = new CPoint(0,0);
            p3.x = p1.x + (-p2.x);
            p3.y = p1.y + (-p2.y);
            return p3;
        } 
        public static bool operator ==(CPoint p1, CPoint p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }
        public static bool operator !=(CPoint p1, CPoint p2)
        {
            return !(p1.x == p2.x && p1.y == p2.y);
        } 
    }
}
