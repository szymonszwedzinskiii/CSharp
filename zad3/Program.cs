using System;
using System.Collections.Generic;

namespace obiektowelab3_podejscie_2
{
  

    class Program
    {
        static void Main(string[] args)
        {
            Katalog k1 = new Katalog("Katalog nr 1");
            Katalog k2 = new Katalog("Katalog nr 2");
            Pozycja p1 = new Czasopismo("Playboy", 1, "Playboy", 2012, 24);
            Pozycja p2 = new Ksiazka("Harry pottee: więzień Askabanu", 2, "J.K Rowling", 2004, 400);

            p1.WypiszInfo();
            p2.WypiszInfo();



            Ksiazka k = new Ksiazka("Jas i Małgosia", 3, "Nie wiem", 1990, 198);
            Czasopismo cz = new Czasopismo("Świerszczyk", 4, "Polska",2007, 14);

            k.WypiszInfo();
            cz.WypiszInfo();

            k1.DodajPozycje(p1);

            k1.WypiszWszystkiePozycje();
            k1.DodajPozycje(p2);
            k1.WypiszWszystkiePozycje();

            k2.DodajPozycje(cz);
            k1.ZnajdzPozycje(2);
            k2.ZnajdzPozycje("Playboy");

            Autor a1 = new Autor("Tomasz", "Chada");

            k.DodajAutora(a1);
            k.WypiszAutora();




            Console.ReadLine();
        }
    }
}
