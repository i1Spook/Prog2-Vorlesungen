
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Personenliste freunde = new Personenliste();
            freunde.AnfuegenAmEnde("Anton");
            freunde.AnfuegenAmEnde("Berta");
            freunde.AnfuegenAmEnde("Claudia");

            freunde.AnfuegenAmAnfang("Aaron");
            freunde.EinfuegenVor(3, "Barbara");
            freunde.EinfuegenVor(5, "Zacharias");
            freunde.Ausgeben();
        }
    }
    class Personenliste
    {
        public class Person
        {
            public string name;
            public Person next;
            public Person(string name)
            {
                this.name = name; 
            }
        }
        Person anf, ende;
        int anz = 0;
        public void AnfuegenAmEnde(string name)
        {
            Person neu = new Person(name);
            anz++;
            if (anf == null)            
                anf = ende = neu;           
            else
                ende = ende.next = neu; //Rechtsassioziative Wertzuweisung - Reihenfolge ist wichtig
                //ende.next = neu;
                //ende = neu;
        }
        public void AnfuegenAmAnfang(string name)
        {
            Person neu = new Person(name);
            anz++;
            if (anf == null)
                anf = ende = neu;
            else
            {
                neu.next = anf;
                anf = neu;
            }

        }
        public void Ausgeben()
        {
            for (Person tmp=anf; tmp!=null;tmp=tmp.next)
            {
                Console.WriteLine(tmp.name);
            }
        }
        public void EinfuegenVor(int index, string name)
        {
            //Einfügen vor Element 1
            //tmp = Element0
            //neu = einzufügendes Element
            //1. neu.next = tmp.next;
            //2. tmp.next = neu;
            if(index == 0)
                AnfuegenAmAnfang(name);
            else if (index == anz)
                AnfuegenAmEnde(name);
            else
            {
                Person neu = new Person(name);
                anz++;
                Person tmp = anf;
                for (int i = 0; i < index - 1; i++)
                    tmp = tmp.next;
                neu.next = tmp.next;
                tmp.next = neu;
            }
        }
    }
}
