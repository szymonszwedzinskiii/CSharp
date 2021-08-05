using System;
using System.Collections.Generic;
using System.Text;

namespace obiektowelab3_podejscie_2
{
    class Czasopismo:Pozycja
    {
        private int numer;

        public int Numer
        {
            get { return numer; }
            set { numer = value; }
        }

        public Czasopismo()
        {
            numer = 0;
        }

        public Czasopismo(string tytul_, int id_, string wydawnictwo_, int rokWydania_, int numer_)
        {
            tytul = tytul_;
            id = id_;
            wydawnictwo = wydawnictwo_;
            rokWydania = rokWydania_;
            numer = numer_;
        }

        public override void WypiszInfo()
        {
            Console.WriteLine(tytul);
            Console.WriteLine(wydawnictwo);
            Console.WriteLine(id);
            Console.WriteLine(rokWydania);
            Console.WriteLine(numer);

        }
    }
}
