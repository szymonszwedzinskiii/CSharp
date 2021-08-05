using System;
using System.Collections.Generic;
using System.Text;

namespace zad2_programowanieObiektowe
{
    class Student : Osoba
    {
        private int rok;
        private int grupa;
        private int nrIndeksu;
        private List<Ocena> oceny = new List<Ocena>();

        public Student(string imie_, string nazwisko_, string dataUrodzenia_, int rok_, int grupa_, int nrIndeksu_) : base(imie_, nazwisko_, dataUrodzenia_)
        {
            rok = rok_;
            grupa = grupa_;
            nrIndeksu = nrIndeksu_;
        }

        public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            oceny.Add(new Ocena(nazwaPrzedmiotu,data,wartosc) );
            
        }
        public void WypiszOceny()
        {
            Console.WriteLine("Oceny studenta: \n");
            for(int i = 0; i < oceny.Count; i++)
            {
                Console.WriteLine("=====================================================================");

                Console.WriteLine("Przedmiot: " + oceny[i].NazwaPrzedmiotu);
                Console.WriteLine("Data wystawienia oceny: " + oceny[i].Data) ;
                Console.WriteLine("Ocena: " + oceny[i].Wartosc);

                Console.WriteLine("\n");
                Console.WriteLine("=====================================================================");

            }
        }
        public void WypiszOceny(string nazwaPrzedmiotu)
        {
            
            for(int i = 0; i < oceny.Count; i++)
            {
                if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    Console.WriteLine("=====================================================================");

                    Console.WriteLine(oceny[i].NazwaPrzedmiotu);
                    Console.WriteLine(oceny[i].Data);
                    Console.WriteLine(oceny[i].Wartosc);
                    Console.WriteLine("=====================================================================");

                }
            }
        }
        public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            for(int i =0; i<oceny.Count;)
            {
                Ocena o = oceny[i];
                if (o.NazwaPrzedmiotu == nazwaPrzedmiotu && o.Data == data && o.Wartosc == wartosc)
                {
                    oceny.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
        }
        public void UsunOceny()
        {
            oceny.Clear();
        }
        public void UsunOceny(string nazwaPrzedmiotu)
        {
            for(int i = 0; i < oceny.Count;)
            {
                Ocena o = oceny[i];
                if (o.NazwaPrzedmiotu == nazwaPrzedmiotu)
                {
                    oceny.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
        }
        public override void wypiszInfo()
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Informacje o studencie: ");
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Nazwisko: " + nazwisko);
            Console.WriteLine("Data urodzenia: " + dataUrodzenia);
            Console.WriteLine("rok: " + rok);
            Console.WriteLine("grupa: " + grupa);
            Console.WriteLine("nrIndeksu: " + nrIndeksu + "\n");
            WypiszOceny();
            Console.WriteLine("=====================================================================");


        }
    }
    public class Ocena
    {
        private string nazwaPrzedmiotu;
        private string data;
        private double wartosc;

        public Ocena(string nazwaPrzedmiotu_, string data_, double wartosc_)
        {
            nazwaPrzedmiotu = nazwaPrzedmiotu_;
            data = data_;
            wartosc = wartosc_;
        }
        public string NazwaPrzedmiotu
        {
            get { return nazwaPrzedmiotu; }
            set { nazwaPrzedmiotu = value; }
        }
        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public double Wartosc
        {
            get { return wartosc; }
            set { this.wartosc = value; }
        }
        public void wypiszInfo()
        {
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Przedmiot: " + nazwaPrzedmiotu);
            Console.WriteLine("Data: " + data);
            Console.WriteLine("Ocena: " + wartosc);
            Console.WriteLine("=====================================================================");

        }
    }
}



