using System;
using System.Collections.Generic;
using System.Text;

namespace obiektowelab3_podejscie_2
{
    class Ksiazka:Pozycja
    {
        private int liczbaStron;
        private List<Autor> autorzy = new List<Autor>();
        public int LiczbaStron
        {
            get { return liczbaStron; }
            set { liczbaStron = value; }
        }

        public Ksiazka()
        {
            liczbaStron = 0;
        }

        public Ksiazka(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int liczbaStron_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
            liczbaStron = liczbaStron_;
        }

        public void DodajAutora(Autor a)
        {
            autorzy.Add(a);
        }

        public override void WypiszInfo()
        {
            
            Console.WriteLine("Tytul: " + tytul);
            Console.WriteLine("Wydawnictwo: " + wydawnictwo);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Rok Wydania: " + rokWydania);
            Console.WriteLine("Liczba stron: " + liczbaStron);
        }

        public void WypiszAutora()
        {
            int i = 0;
            foreach (Autor element in autorzy)
                Console.WriteLine($"Autorem ksiazki : {tytul}, jest {element.Imie} {element.Nazwisko}!");
            i++;
        }
    }
}

