using System;
using System.Collections.Generic;

namespace Programowanie_obiektowe_lab5_zad1
{
    interface Iinfo
    {
        public void WypiszInfo();

    }
    class Wydzial
    {
       //private Przedmiot p;
       //private Student s;
        private List<Jednostka> jednostki = new List<Jednostka>();
        private List<Przedmiot> przedmioty = new List<Przedmiot>();
        private List<Student> studenci = new List<Student>();
        private List<Wykladowca> wykladowcy = new List<Wykladowca>();
        private List<OcenaKoncowa> oceny = new List<OcenaKoncowa>();


        public void DodajJednostke(string nazwa, string adres)
        {
            jednostki.Add(new Jednostka(nazwa, adres));
        }
        public void DodajPrzedmiot(Przedmiot p)
        {
            przedmioty.Add(p);
        }
        public void DodajStudenta(Student s)
        {
            studenci.Add(s);

        }
        public bool DodajWykladowce(Wykladowca w, string nazwaJedostki)
        {
            foreach (Wykladowca wyk in wykladowcy)
            {
                if (wyk.Equals(w))
                {
                    wykladowcy.Add(w);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public void InfoStudenci(bool infoOceny)
        {
            if (infoOceny == true)
            {
                foreach (Student s in studenci)
                {
                    Console.WriteLine($"{s.Imie} {s.Nazwisko}, data urodzenia: {s.DataUrodzenia}, numer indeksu {s.NrIndeksu} studiuje: {s.Specjalnosc} na {s.Kierunek}, w gtupie nr {s.Grupa} na  {s.Rok} roku");
                    foreach (OcenaKoncowa ocena in oceny)
                    {
                        Console.WriteLine($"Ocena {ocena.Wartosc} wystawiona {ocena.Data}");
                    }
                }


            }
            else
            {
                foreach(Student s in studenci)
                {
                    Console.WriteLine($"{s.Imie} {s.Nazwisko}, data urodzenia: {s.DataUrodzenia}, numer indeksu {s.NrIndeksu} studiuje: {s.Specjalnosc} na {s.Kierunek}, w gtupie nr {s.Grupa} na  {s.Rok} roku");
                }    

            }
        }
        public void InfoJednostki(bool infoWykladowcy)
        {
            if (infoWykladowcy == true)
            {
                foreach (Jednostka jedn in jednostki)
                {
                    Console.WriteLine($"{jedn.Nazwa}, która mieści się przy {jedn.Adres} ");
                    foreach (Wykladowca wykl in wykladowcy)
                    {
                        Console.WriteLine($"Wykładowcy {wykl.Imie} {wykl.Nazwisko}, data urodzenia: {wykl.DataUrodzenia}, tytuł naukowy: {wykl.TytulNaukowy}, stanowisko{wykl.Stanowisko}");
                    }
                }

            }
            else
            {
                foreach (Jednostka jedn in jednostki)
                {
                    Console.WriteLine($"Jednostka{jedn.Nazwa}, która mieści się przy {jedn.Adres} ");
                }
            }
        }

        public void InfoPrzedmioty()
            {
                foreach (Przedmiot p in przedmioty)
                {
                    Console.WriteLine($"{p.Nazwa},{p.Kierunek}, {p.Specjalnosc}, {p.Semestr}, {p.IlGodzin}");
                }
            }
        public bool DodajOceny(int nrIndeksu, Przedmiot p1,double ocena, string data)
        {
            int i=0;
            for(int j = 0; j < przedmioty.Count; j++)
            {
                if (przedmioty[j] == p1)
                {
                    i = 1;
                }
                
            }
            if (i == 0)
            {
                return false;
            }
            else
            {
                foreach(Student s in studenci)
                {
                    if(s.NrIndeksu == nrIndeksu)
                    {
                        s.DodajOcene(p1, ocena, data);
                    }
                }

            }


            return false;
        }
        public bool UsunStudenta(int nrIndeksu)
        {
            int i = 0;
            foreach(Student s in studenci)
            {
                if (s.NrIndeksu == nrIndeksu)
                {
                    studenci.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            return false;
        }
        public bool PrzeniesWykladowce(Wykladowca w, string obecnaJendostka,string nowaJednostka)
        {

            bool w1 = true;
            foreach(Jednostka jed in jednostki)
            {
                if(jed.Nazwa == obecnaJendostka)
                {
                    w1 = jed.UsunWykladowce(w);
                }
            }
            if (w1 == false)
            {
                return false;
            }
            else
            {
                foreach(Jednostka j in jednostki)
                {
                    if (j.Nazwa == nowaJednostka)
                    {
                        j.DodajWykladowce(w);
                        return true;
                    }
                }
            }
            return false;
        }

    }
    class Przedmiot : Iinfo {
        private string nazwa = "";
        private string kierunek = "";
        private string specjalnosc = "";
        private int semestr = 0;
        private int ilGodzin = 0;
        public string Nazwa { get { return nazwa; } set { nazwa = value; } }
        public string Kierunek { get { return kierunek; } set { kierunek = value; } }
        public string Specjalnosc { get { return specjalnosc; } set { specjalnosc = value; } }
        public int Semestr { get { return semestr; } set { semestr = value; } }
        public int IlGodzin { get { return ilGodzin; } set { ilGodzin = value; } }




        public Przedmiot(string nazwa, string kierunek, string specjalnosc, int semestr, int ilGodzin)
        {
            this.nazwa = nazwa;
            this.kierunek = kierunek;
            this.specjalnosc = specjalnosc;
            this.semestr = semestr;
            this.ilGodzin = ilGodzin;
        }

        void Iinfo.WypiszInfo()
        {
            Console.WriteLine("Informacje o przedmiocie: \n");
            Console.WriteLine(nazwa + "\n");
            Console.WriteLine(kierunek + "\n");
            Console.WriteLine(specjalnosc + "\n");
            Console.WriteLine(semestr + "\n");
            Console.WriteLine(ilGodzin + "\n");




        }
    }
    class OcenaKoncowa : Iinfo
    {
        private double wartosc = 0.0;
        public double Wartosc { get { return wartosc; } set { wartosc = value; } }

        private string data = "";
        public string Data { get { return data; } set { data = value; } }
        private Przedmiot p;

        public OcenaKoncowa(double ocena_, string data_, Przedmiot przed)
        {
            wartosc = ocena_;
            data = data_;
            p = przed;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Informacje o ocenach: ");
            Console.WriteLine(wartosc);
            Console.WriteLine(data + "\n");
            Console.WriteLine(p.Nazwa);
        }
    }

    class Student : Osoba
    {
        private string kierunek = "";
        public string Kierunek { get { return kierunek; } set { kierunek = value; } }
        private string specjalnosc = "";
        public string Specjalnosc { get { return specjalnosc; } set { specjalnosc = value; } }

        private int rok = 0;
        public int Rok { get { return rok; } set { rok = value; } }

        private int grupa = 0;
        public int Grupa { get { return grupa; } set { grupa = value; } }

        private int nrIndeksu = 0;
        public int NrIndeksu { get { return nrIndeksu; } set { nrIndeksu = value; } }
        public List<OcenaKoncowa> oceny = new List<OcenaKoncowa>(); 
           
        public Student() : base("", "", "")
        {

            kierunek = " ";
            specjalnosc = " ";
            rok = 0;
            grupa = 0;
            nrIndeksu = 0;
        }
        public Student(string imie_, string nazwisko_, string dataUrodzenia_, string kierunek_, string specjalnosc_, int rok_, int grupa_, int nrIndeksu_) : base(imie_, nazwisko_, dataUrodzenia_)
        {
            kierunek = kierunek_;
            specjalnosc = specjalnosc_;
            rok = rok_;
            grupa = grupa_;
            nrIndeksu = nrIndeksu_;


        }
        public void WpiszInfo()
        {
            Console.WriteLine($"Student: {imie} {nazwisko},kierunek: {kierunek},specjalność: {specjalnosc},rok: {rok},grupa: {grupa}, nr indeksu: {NrIndeksu} \n");
        }
        public void InfoOceny()
        {
            for(int i = 0; i < oceny.Count; i++)
        {
            oceny[i].WypiszInfo();
        }

        }
        public bool DodajOcene(Przedmiot p1,double ocena,string data)
        {
        OcenaKoncowa o1 = new OcenaKoncowa(ocena, data, p1);
        oceny.Add(o1);
        return true;
        }


    }
    class Osoba : Iinfo
    {
        protected string imie = "";
        public string Imie { get { return imie; } set { imie = value; } }
        protected string nazwisko = "";
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        protected string dataUrodzenia = "";
        public string DataUrodzenia { get { return dataUrodzenia; } set { dataUrodzenia = value; } }

        public Osoba(string imie_, string nazwisko_, string dataUrodzenia_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            dataUrodzenia = dataUrodzenia_;
        }
        public void WypiszInfo()
        {
            Console.WriteLine($"{imie} {nazwisko}, data urodzenia{dataUrodzenia}");
        }

    }
    class Wykladowca : Osoba
    {
        private string tytulNaukowy = "";
        public string TytulNaukowy
        {
            get { return tytulNaukowy; }
            set { tytulNaukowy = value; }
        }

        private string stanowisko = "";
        public string Stanowisko
        {
            get { return stanowisko; }
            set { stanowisko = value; }
        }
        public Wykladowca() : base("", "", "")
        {
                
            tytulNaukowy = "";
            stanowisko = "";
        }
        public Wykladowca(string imie,string nazwisko,string dataUrodzenia,string tytulNaukowy_, string stanowisko_) : base(imie,nazwisko,dataUrodzenia)
        {
            tytulNaukowy = tytulNaukowy_;
            stanowisko = stanowisko_;

        }
        public void WypiszInfo()
        {
            Console.WriteLine("Informacje o wykladowcy: \n");
            Console.WriteLine(Imie + "\n");
            Console.WriteLine(Nazwisko + "\n");
            Console.WriteLine(dataUrodzenia + "\n");
            Console.WriteLine(tytulNaukowy + "\n");
            Console.WriteLine(stanowisko + "\n");

        }
    }
    class Jednostka : Iinfo
    {
        private string nazwa = "";
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        private string adres = "";
        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }

        private List<Wykladowca> wykladowcy = new List<Wykladowca>();
        public Jednostka(string nazwa_, string adres_)
        {
            nazwa = nazwa_;
            adres = adres_;
        }
        public void DodajWykladowce(Wykladowca w)
        {
            wykladowcy.Add(w);
        }
        public bool UsunWykladowce(Wykladowca w)
        {
            int i = 0;
            foreach (Wykladowca wyklad in wykladowcy)
            {
                if (wyklad == w)
                {
                    wykladowcy.RemoveAt(i);
                    return true;
                }
                else
                {
                    i++;
                    return false;
                }
            }
            return false;
        }
        public bool UsunWykladowce(string imie, string nazwisko)
        {
            int i = 0;
            foreach (Wykladowca w in wykladowcy)
            {
                if (imie == w.Imie && nazwisko == w.Nazwisko)
                {
                    wykladowcy.RemoveAt(i);
                return true; 
                }
                else
                {
                    i++;
                    return false;
                }
            }
            return false;

        }
        public void InfoWykladowcy()
        {
            Console.WriteLine("Info Wykladowcy: \n");
            foreach (Wykladowca w in wykladowcy)
            {
                Console.WriteLine($"Wykladowca: {w.Imie} {w.Nazwisko}, tytuł: {w.TytulNaukowy}, stanowisko: {w.Stanowisko}");
            }

        }
        public void WypiszInfo()
        {
            Console.WriteLine($"Jednostka { nazwa }, adres { adres} ilosc wykladowców {wykladowcy.Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        Wydzial wy1 = new Wydzial();
        Jednostka j1 = new Jednostka("Katedra informatykii", "Dabrowskiego");
        Wykladowca w1 = new Wykladowca("Andrzej","Konieczny","12.12.1999","Dyrektor", "Doktor");
        Student s1 = new Student("Marcin","Marcisz","01.01.1999","Informatyka","Inzynieria oprogramowania",1,2,123456);
        Student s2 = new Student("Antek", "Szczur", "12.12.1999", "Informatyka", "programownie", 1, 2, 234567);
        Przedmiot p1 = new Przedmiot("Matematyka dyskretna", "Informatyka", "Brak", 1, 30);
        s1.WypiszInfo();
        j1.WypiszInfo();
        wy1.DodajJednostke("Katedra Informatyki", "Dabrowskiego");
        wy1.InfoJednostki(true);
        wy1.DodajStudenta(s2);
        wy1.DodajPrzedmiot(p1);
        wy1.DodajStudenta(s1);
        wy1.DodajWykladowce(w1,"Katedra informatyki");
        wy1.DodajOceny(123456,p1,2,"01.01.1999"); 
        wy1.InfoStudenci(true);
        wy1.InfoPrzedmioty();
        }
    }
} 

