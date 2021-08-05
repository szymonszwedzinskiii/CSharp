using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweWPF2
{
    public class Student
    {
        private string imie;
        public string Imie
        {
            set { imie = value; }
            get { return imie; }
        }
        private string nazwisko;
        public string Nazwisko
        {
            set { nazwisko=value; }
            get { return nazwisko; }
        }
        private int nrIndeksu { set; get; }
        public int NrIndeksu 
        {
            set { nrIndeksu = value; }
            get { return nrIndeksu; }
        }
        private string wydzial { set; get; }
        public string Wydzial
        {
            set { wydzial = value; }
            get { return wydzial; }
        }
        public Student() { }
        public Student(string imie,string nazwisko,int numer,string wydzial)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.nrIndeksu = numer;
            this.wydzial = wydzial;
        }
        //public List<Ocena> oceny { set; get; }


    }

}
