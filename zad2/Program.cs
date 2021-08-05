using System;
using System.Collections.Generic;

namespace zad2_programowanieObiektowe
{
    class Program
    {
        static void Main(string[] args)
        {
            //zad1


            Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
            Osoba o2 = new Student("Michał", "Kot", "13.04.1990", 2, 1, 12345);
            Osoba o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "obrońca", "FC Czestochowa");

            o.wypiszInfo();
            o2.wypiszInfo();
            o3.wypiszInfo();

            Student s = new Student("Krzysztof", "Jeż", "22.12.1990", 2, 5, 54321);
            Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");

            s.wypiszInfo();
            p.wypiszInfo();

            ((Pilkarz)o3).strzelGola();
            p.strzelGola();
            p.strzelGola();

            o3.wypiszInfo();
            p.wypiszInfo();


            Console.ReadKey();

            //zad2


            ((Student)o2).DodajOcene("PO", "20.02.2011", 5.0);
            ((Student)o2).DodajOcene("Bazy Danych", "13.02.2011", 4.0);

            o2.wypiszInfo();

            s.DodajOcene("Bazy danych", "01.05.2011", 5.0);
            s.DodajOcene("AWWW","11.05.2011",5.0);
            s.DodajOcene("AWWW","02.04.2011",4.5);

            s.wypiszInfo();

            s.UsunOcene("AWWW", "02.04.2011", 4.5);

            s.WypiszOceny();

            s.DodajOcene("AWWW","02.04.2011",4.5);
            s.UsunOceny("AWWW");

            s.wypiszInfo();

            s.DodajOcene("AWWW","02.04.2011",4.5);

            Console.ReadKey();


            s.WypiszOceny("AWWW");

            s.UsunOceny();

            s.wypiszInfo();

            //zad3

            Console.ReadKey();

            PilkarzNozny p1 = new PilkarzNozny("Filip", "Kulon", "02.02.1996", "Strzelec", "Fc Ulani");
            p1.strzelGola();
            p1.wypiszInfo();

            PilkarzReczny p2 = new PilkarzReczny("MArcin","Najman", "02.04.1910","Bramkarz", "AC Milan");
            p2.strzelGola();
            p2.wypiszInfo();


            Console.ReadKey();
        }
    }
}
