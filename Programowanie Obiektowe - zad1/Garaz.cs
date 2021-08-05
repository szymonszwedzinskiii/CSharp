using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
            
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set { 
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }
        public Garaz()
        {
            adres = "nieznany";
            pojemnosc = 0;
            samochody = null;
            
        }
        public Garaz(string adres_,int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;
            samochody = new Samochod[pojemnosc_];
        }
        public void wprowadzSamochod(Samochod s)
        {
            if (this.pojemnosc == this.liczbaSamochodow)
            {
                Console.WriteLine("Garaż pełny");
                return;
            }
            else
            {
                this.samochody[liczbaSamochodow++] = s;

            };
        }
        public Samochod wyprowadzSamochod()
        {
            if (this.liczbaSamochodow == 0)
            {
                Console.WriteLine("Obecnie garaż jest pusty, nie ma czego usuwac \n" );
                return null;
            }
            else
            {
                
                Samochod wyprowadzanko=samochody[liczbaSamochodow-1];
                samochody[liczbaSamochodow-1]=null;
                liczbaSamochodow--;
                //this.samochody[liczbaSamochodow-1] = null;
                //liczbaSamochodow--;
                return wyprowadzanko;

            }
        }

        public void wypiszInfo()
        {
            Console.WriteLine(adres);
            Console.WriteLine(pojemnosc);
            if (liczbaSamochodow==0)
            {

                Console.WriteLine("Garaz pusty\n");

            }
            else { 
                for (int i= 0;i< liczbaSamochodow; i++)
                {
                        if(samochody[i] != null)
                        {
                            Console.WriteLine("\n");
                            samochody[i].wypiszInfo();
                            Console.WriteLine("\n");
                        }
                }
            }
        }

    }
}
