using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Samochod s1 = new Samochod();
            s1.wypiszInfo();
            Console.WriteLine("\n");
            s1.Marka = "Fiat";
            s1.Model = "126p";
            s1.IloscDrzwi = 2;
            s1.Pojemnosc = 650;
            s1.SrednieSpalanie = 6.0;
            s1.wypiszInfo();
            Console.WriteLine("\n");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
            s2.wypiszInfo();
            Console.WriteLine("\n");
            double kosztPrzejazdu = s2.obliczKosztPrzejazdu(30.5, 4.85);
            Console.WriteLine(String.Format("Koszt przejazdu: "+"{0:N2} \n", kosztPrzejazdu));
            Samochod.wypiszIloscSamochodow();



            Garaz g1 = new Garaz();
            g1.Adres = "ul Garażowa 1";
            g1.Pojemnosc = 1;
            Garaz g2 = new Garaz("ul. Garażowa 2", 2);
            g1.wprowadzSamochod(s1);

            Console.WriteLine("Pdsumowanie\n");
            g1.wypiszInfo();
            Console.WriteLine("\n");
            g1.wprowadzSamochod(s2);

            g2.wprowadzSamochod(s2);
            g2.wprowadzSamochod(s1);
            Console.WriteLine("\n");
            g2.wypiszInfo();

            g2.wyprowadzSamochod();
            Console.WriteLine("\n");
            g2.wypiszInfo();

            g2.wyprowadzSamochod();
            g2.wyprowadzSamochod();




        }
    }

}
