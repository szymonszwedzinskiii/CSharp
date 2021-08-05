using System;
using System.Collections.Generic;
using System.Text;

namespace obiektowelab3_podejscie_2
{
    class Autor:Ksiazka
    {
        private string imie, nazwisko;
        public Autor()
        {
            imie = "Nieznane";
            nazwisko = "Nieznane";
        }
        public Autor(string imie_,string nazwisko_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
        }
        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
    }
}
