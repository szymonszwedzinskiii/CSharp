using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Samochod
    {
        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;


        private static int iloscSamochodow=0;
        public Samochod()
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            iloscSamochodow++;
            
        }
        public Samochod( string marka_,string model_,int iloscDrzwi_,int pojemnoscSilnika_,double srednieSpalanie_)
        {
            marka = marka_;
            model = model_;
            iloscDrzwi = iloscDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;
            iloscSamochodow++;
            
        }
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }
        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }
        private double obliczSpalanie(double dlugoscTrasy)
        {
            return (srednieSpalanie * dlugoscTrasy) / 100;
        }
        public double obliczKosztPrzejazdu(double dlugoscTrasy,double cenaPaliwa)
        {
            return (obliczSpalanie(dlugoscTrasy) *cenaPaliwa);
        }
        public void wypiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("ilosc drzwi: " + iloscDrzwi);
            Console.WriteLine("Pojemnosc silnika: " + pojemnoscSilnika);
            Console.WriteLine("Srednie spalanie: " + srednieSpalanie);
            
        }
        public static void wypiszIloscSamochodow()
        {
            Console.WriteLine("Ilosc samochodow: " + iloscSamochodow);
        }

    }

}
