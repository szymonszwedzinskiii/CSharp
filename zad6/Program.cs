using System;
using System.Collections.Generic;

namespace programowanie_obiektowezad6
{
    class Zwierze
    {
        protected string pochodzenie;
        public string Pochodzenie
        {
            get { return pochodzenie; }
            set { pochodzenie = value; }
        }
        protected string gatunek;
        public string Gatunek
        {
            get { return gatunek; }
            set { gatunek = value; }
        }
        protected string rodzajPozywenia;
        public string RodzajPozywenia
        {
            get { return rodzajPozywenia; }
            set { rodzajPozywenia = value; }
        }
        public Zwierze() { }
        public Zwierze(string pochodzenie,string gatunek,string rodzajPozywienia)
        {
            this.pochodzenie = pochodzenie;
            this.gatunek = gatunek;
            this.rodzajPozywenia = rodzajPozywienia;
        }
        public virtual void WypiszInfo()
        {
            Console.WriteLine($"Zwierzę {gatunek} pochodzi z {pochodzenie}, a jego pożywieniem jest {rodzajPozywenia}");

        }

    }
    class Ssak:Zwierze
    {
        private string naturalneSrodowisko;
        public string NaturalneSrodowisko
        {
            set { naturalneSrodowisko = value; }
        }

        public Ssak() { }
        public Ssak(string naturalneSrodowisko)
        {
            this.naturalneSrodowisko = naturalneSrodowisko;
        }
        public Ssak(Zwierze z1, string naturalneSrodowisko)
            : base(z1.Pochodzenie, z1.Gatunek, z1.RodzajPozywenia)
        {
            this.naturalneSrodowisko = naturalneSrodowisko;
        }
        public Ssak(string pochodzenie, string gatunek,string rodzajPozywienia, string naturalneSrodowisko)
            : base(pochodzenie, gatunek, rodzajPozywienia)
        {
            
            this.naturalneSrodowisko = naturalneSrodowisko;
        }
        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine($" Naturalnym środowiskiem jest {naturalneSrodowisko}");
        }

    }
    class Ptak:Zwierze
    {

        private double maxDlugoscLotu;
        public double MaxDlugoscLotu {
            get { return maxDlugoscLotu; } 
        
            set { maxDlugoscLotu = value; }
        }

        private double rozpietoscSkrzydel;
        public double RozpietoscSkrzydel
        {
            get { return rozpietoscSkrzydel; }

            set { rozpietoscSkrzydel = value; }
        }
        private double wytrzymalosc;
        public double Wytrzymalosc
        {
            get { return wytrzymalosc; }

            set { wytrzymalosc = value; }
        }

        public Ptak() { }
        public Ptak(double rozpietoscSkrzydel,double wytrzymalosc)
        {
            
            
            this.rozpietoscSkrzydel = rozpietoscSkrzydel;
            this.wytrzymalosc = wytrzymalosc;
            this.maxDlugoscLotu = rozpietoscSkrzydel * wytrzymalosc;

        }
        public Ptak(string pochodzenie, string gatunek, string rodzajPozywienia, double rozpietoscSkrzydel, double wytrzymalosc)
            :base(pochodzenie,gatunek,rodzajPozywienia)
        {
            this.rozpietoscSkrzydel = rozpietoscSkrzydel;
            this.wytrzymalosc = wytrzymalosc;
            this.maxDlugoscLotu = rozpietoscSkrzydel * wytrzymalosc;

        }
        public Ptak( Zwierze z1, double rozpietoscSkrzydel, double wytrzymalosc) 
        :base(z1.Pochodzenie,z1.Gatunek,z1.RodzajPozywenia)
        {

            this.rozpietoscSkrzydel = rozpietoscSkrzydel;
            this.wytrzymalosc = wytrzymalosc;
            this.maxDlugoscLotu = rozpietoscSkrzydel * wytrzymalosc;
        }


        public override void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine($"Maksymalna długość lotu tego ptaka to {maxDlugoscLotu}, rozpietosc skrzydeł {rozpietoscSkrzydel}, oraz wytrzymałośc na poziomie {wytrzymalosc} ");


        }
    }
    class Gad:Zwierze
    {
        private bool isVenomous;
        public bool IsVenomous
        {
            get { return isVenomous; }
            set { isVenomous = value; }
        }

        public Gad() { }
        public Gad(bool isVenomous) 
        {
            this.isVenomous = isVenomous;

        }
        public Gad(string pochodzenie,string gatunek, string rodzajPozywienia, bool isVenomous)
            :base(pochodzenie,gatunek,rodzajPozywienia)
        {
            this.isVenomous = isVenomous;

        }
        public Gad(Zwierze z1, bool isVenomous)
            :base(z1.Pochodzenie,z1.Gatunek,z1.RodzajPozywenia)
        {
            this.isVenomous = isVenomous;

        }
        public override void WypiszInfo()
        {
            string jadowity;
            base.WypiszInfo();
            if (isVenomous) { jadowity = "jest jadowity"; }
            else { jadowity = "nie jest jadowity"; }
            Console.WriteLine($"Gad ten {jadowity}");

        }
    }
    class Osoba
    {
        protected string imie;
        public string Imie { get { return imie; } set { imie = value; } }
        protected string nazwisko;
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public Osoba() { }
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
    class Opiekun:Osoba
    {
        List<Klatka> klatki = new List<Klatka>();
        public Opiekun() { }
        public Opiekun(string imie, string nazwisko) :base(imie,nazwisko)
        {

        }
        public void PosprzatajKlatke(Klatka k1)
        {
            k1.PosprzatajKlatke();

        }
    }

    class Klatka
    {
        private int pojemnosc;
        public int Pojemnosc { get { return pojemnosc; } set { pojemnosc = value; } }
        private static int id;
        public int Id { get { return id; } }
        int liczbaklatek;
        public int liczbaZwierzat = 0;
        public static List<Opiekun> opiekunowie = new List<Opiekun>();

        public static List<Zwierze> zwierzetawklatce = new List<Zwierze>();

        public Klatka() { }
        public Klatka(int pojemnosc) {
            this.pojemnosc = pojemnosc;
            id = liczbaklatek + 1;
            liczbaklatek++;
            Dyrekcja.klatki.Add(this);
        }
        public void PosprzatajKlatke()
        {
            Console.WriteLine($"Klatka została posprzątana \n");
        }
        public void DodajOpiekuna(Opiekun o1)
        {
            opiekunowie.Add(o1);
        }
    }
    class Dyrekcja
    {
        public static List<Klatka> klatki = new List<Klatka>();
        public static List<Opiekun> opiekunowie = new List<Opiekun>();
        public static List<Zwierze> zwierzeta = new List<Zwierze>();

        public void DodajKlatke(int pojemnosc)// int id - moj blad podczas rysowania umla
        {
            klatki.Add(new Klatka(pojemnosc));
        }
        public void PowiekszKlatke(Klatka k1, int poj)
        {
            foreach (Klatka element in klatki)
            {
                if (k1 == element)
                {
                    k1.Pojemnosc = poj;
                }
            }
        }
        public void DodajZwierzeDoKlatki(Klatka k1, Zwierze z1)
        {
            if(k1.Pojemnosc == k1.liczbaZwierzat)
            {
                Console.WriteLine("KLatka pełna \n");
            }
            else
            {
                k1.zwierzetawklatce.Add(z1);
                k1.liczbaZwierzat++;
                
            }
        }
        public void InfoKlatki()
        {
            Console.WriteLine($"Ilosc klatek:{klatki.Count}");
            foreach(Klatka k1 in klatki)
            {
                Console.WriteLine($"Klatka {k1.Id} ma pojemnosc {k1.Pojemnosc}, do tej pory w klatce znajduje się {k1.liczbaZwierzat} zwierząt ");

            }
        }
        public void InfoOpiekunowie()
        {
            Console.WriteLine($"Ilosc opiekunow to: {Klatka.opiekunowie.Count}");

        }
        public void ZatrudnijPracownika(Osoba o1)
        {
            o1 = new Opiekun(o1.Imie, o1.Nazwisko);
            Console.WriteLine($" Zatrudniono osobe {o1.Imie} {o1.Nazwisko}\n");

        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Zwierze zwierz = new Zwierze("ptak","Wróbel","Robaki");
            Zwierze zwierz1 = new Zwierze("wąż", "boa", "Robaki");
            Ptak p1 = new Ptak(zwierz,20,10);
            Ssak s1 = new Ssak(zwierz, "Jungla");
            Gad g1 = new Gad(zwierz1,true);
            

            p1.WypiszInfo();
            s1.WypiszInfo();
            g1.WypiszInfo();
        }
    }
}
