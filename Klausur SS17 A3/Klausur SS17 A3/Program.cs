using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klausur_SS17_A3
{
    class Program
    {
        static Auswahlmethode Auswahl;
        static void Main(string[] args)
        {
            Liste sortiment = new Liste();
            sortiment.Hinzufügen("Kaffee", 2);
            sortiment.Hinzufügen("Zucker", 4);
            sortiment.Hinzufügen("Mehl", 10);
            sortiment.Hinzufügen("Kaffee", 3);

            //Anzahl <= 5
            Liste bestellListe = sortiment.Bestellung(/*Hier Ihre Implementierung mittels anonymer Funktion (oder alternativ Lambda‐Ausdruck):*/);
            // bestellListe enthält nun (nur) die Einträge mit den Artikelnamen „Kaffee“ und „Zucker“   

        }
    }
    // Hier Ihre Deklaration des Delegate‐Typs:
    delegate bool Auswahlmethode(int x);
    
    class Liste
    {
        
        class LElement
        {
            public string name;

            public int anzahl;
            public LElement next;
            public LElement(string name, int anzahl)
            {
                this.name = name;
                this.anzahl = anzahl;
            }
        }
        LElement root;
        public void Hinzufügen(string name, int anzahl)
        {
            // Hier Ihre ergänzende Implementierung der Methode Hinzufügen():

            //Artikel existiert? Anzahl +1
            if (SucheArtikel(name))
            {
                anzahl += anzahl;
            }
            //Artikel existiert nicht? Vorne einfügen
            else
            {
                LElement neu = new LElement(name, anzahl);
                neu.next = root;
                root = neu;
            }           
        }

        // Hier Ihre Implementierung der privaten Methode SucheArtikel():
        private bool SucheArtikel(string name)
        {
            //Liste per Name durchsuchen
            //exisitert? = true zurück
            LElement neu = new LElement(name, 0);
            bool existiert = false;
            while (neu.next != null)
            {
                if (neu.name == name)
                    existiert = true;
                else
                    existiert = false;
            }
            return existiert;           
        }

        // Hier Ihre Implementierung der öffentlichen Methode Bestellung():
        //Erzeugung einer Liste aller Artikel unterhalb der Mindestanzahl
        public void Bestellung(Auswahlmethode Auswahl)
        {
            
            //??????
        }
    }
}
