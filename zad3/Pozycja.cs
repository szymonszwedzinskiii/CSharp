using System;
using System.Collections.Generic;
using System.Text;

namespace obiektowelab3_podejscie_2
{
    abstract class Pozycja : Katalog
    {
        protected string tytul, wydawnictwo;
        protected int id, rokWydania;

        public string Tytul
        {
            get { return tytul; }
        }
        public string Wydawnictwo
        {
            get { return wydawnictwo; }
        }
        public int Id
        {
            get { return id; }
        }
        public int RokWydania
        {
            get { return rokWydania; }
        }

        public Pozycja()
        {
            tytul = null;
            wydawnictwo = null;
            id = 0;
            rokWydania = 0;
        }

        public Pozycja(string tytul, int id, string wydawnictwo, int rokWydania)
        {
            this.tytul = tytul;
            this.id = id;
            this.wydawnictwo = wydawnictwo;
            this.rokWydania = rokWydania;
        }

        public abstract void WypiszInfo();
    }
}
