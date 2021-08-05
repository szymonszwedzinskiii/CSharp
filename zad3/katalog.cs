using System;
using System.Collections.Generic;
using System.Text;

namespace obiektowelab3_podejscie_2
{
    class Katalog
    {
        private string dzialTematyczny;
        private List<Pozycja> pozycje = new List<Pozycja>();

        public string DzialTematyczny
        {
            get { return dzialTematyczny; }
            set { dzialTematyczny = value; }
        }

        public Katalog()
        {
            dzialTematyczny = null;
        }

        public Katalog(string dzialTematyczny_)
        {
            dzialTematyczny = dzialTematyczny_;
        }
        public void DodajPozycje(Pozycja p)
        {
            pozycje.Add(p);
        }

        public void WypiszWszystkiePozycje()
        {
            int i = 0;
            foreach (Pozycja element in pozycje)
            {
                Console.WriteLine("Tytul: " + element.Tytul);
                Console.WriteLine("Wydawnictwo: " + element.Wydawnictwo);
                Console.WriteLine("ID: " + element.Id);
                Console.WriteLine("Rok Wydania: " + element.RokWydania);
                i++;
            }
        }


        public void ZnajdzPozycje(string tytul)
        {
            int a = 0;
            foreach (Pozycja element in pozycje)
            {
                if (element.Tytul == tytul)
                {
                    Console.WriteLine("Tytul: " +element.Tytul);
                    Console.WriteLine("Wydawnictwo: " + element.Wydawnictwo);
                    Console.WriteLine("ID: " + element.Id);
                    Console.WriteLine("Rok Wydania: " +element.RokWydania);

                }

            }
        }

        public void ZnajdzPozycje(int ID)
        {
            int a = 0;
            foreach (Pozycja element in pozycje)
            {
                if (element.Id == ID)
                {
                    Console.WriteLine("Tytul: " +element.Tytul);
                    Console.WriteLine("ID: " +element.Id);
                    Console.WriteLine("Rok Wydania: " +element.RokWydania);
                    Console.WriteLine("Wydawnictwo: " + element.Wydawnictwo);
                }

            }
        }
    }
}

