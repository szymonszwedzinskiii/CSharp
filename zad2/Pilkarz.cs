using System;
using System.Collections.Generic;
using System.Text;

namespace zad2_programowanieObiektowe
{
    class Pilkarz : Osoba
    {
        private string pozycja;
        private string klub;
        private int liczbaGoli = 0;

        public Pilkarz(string imie_, string nazwisko_, string dataUrodzenia_, string pozycja_, string klub_ ):base(imie_,nazwisko_,dataUrodzenia_)
        {
            pozycja = pozycja_;
            klub = klub_;

        }
        public override void wypiszInfo()
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Informacje o pilkarzu: ");
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Nazwisko: " + nazwisko);
            Console.WriteLine("Data urodzenia: " + dataUrodzenia);
            Console.WriteLine("pozycja: " + pozycja);
            Console.WriteLine("klub: " + klub);
            Console.WriteLine("Liczba goli: " + liczbaGoli + "\n" );
            Console.WriteLine("=====================================================================");
        }
        public virtual void strzelGola()
        {
            liczbaGoli++;
        }
    }
}
