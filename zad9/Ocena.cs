using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweWPF2
{
    public class Ocena
    {
        private double wartosc;
        private string przedmiot;
        public double Wartosc
        {
            set { wartosc = value; }
            get { return wartosc; }
        }

        public string Przedmiot
        {
            set { przedmiot = value; }
            get { return przedmiot; }
        }


    }
}
