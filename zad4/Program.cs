using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace zadaniaObiektowe
{
    public partial class MyCollection<T> : IEnumerable<T>
    {
        class MyEnumerator : IEnumerator<T>
        { 
        Node fisrst, current;
        public MyEnumerator(Node first)
        {

        }

            public T Current => this.current.value;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if (current != null)
                    current = current.next;
                return current != null;
            }

            public void Reset()
            {
                current = fisrst;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(first);
        }
    }




    public partial class MyCollection<T>
    {
        private class Node
        {
            public T value { get; set; }
            public Node next;
        }
        private Node first =null;
        private Node last = null;

        public void Add(T element)
        {
            if(first == null) { first = last = new Node() { value = element }; }
            else { last = last.next = new Node() { value = element }; }
        }

        public void Insert(int i, T element) 
        {
            var e = first;
            var temp = first;
            int j = 0;
            if (i == 0)
            {
                if (e == null) 
                { 
                    first=last = new Node() { value = element };
                    return; 
                    
                    
                }
                
            }
            while (j <= i)
            {
                if (e == null)
                {
                    e = new Node() { value = element };
                    //Console.WriteLine("ASDAS");
                    break;
                }
                else
                {
                    e = e.next;
                    j++;
                    continue;
                }
            }
            e = first;
            j = 1;

            while (j < i)
            {
                e = e.next;
                j++;

            }
            temp = e.next;
            e.next = new Node() { value = element };
            e.next.next = temp;
            temp = null;
        }
        public void RemoveAt_(int i)
        {
            var e = first;
            var temp = first;
            int j = 0;
            if (i == 0) {
                if (e == null) { throw new IndexOutOfRangeException(); }
                else if (temp != null)
                {
                    e = first = first.next;

                    return;
                }
            }
            while (j <= i)
            {
                if (e == null) {

                    Console.WriteLine("ASDAS");
                    return;
                }
                else
                {
                    e = e.next;
                    j++;
                    continue;
                }
            }
            e = first;
            j = 1;

            while (j < i)
            {
                e = e.next;
                j++;

            }
            temp = e.next;
            e.next = temp.next;
            temp.next = null;
            temp = null;
        }
        public void Remove(T element)
        {
            var e = first;
            int i = 0;
            while (e != null)
            {
                if (e.value.Equals(element))
                {
                    e = e.next;
                    RemoveAt_(i);
                }
                else
                {
                    e = e.next;
                    i++;
                }
            }
        }
        private Node Get(int i )
        {
            var e = first;
            while(i-- > 0 && e!=null)
            {
                e = e.next;
            }
            if (e == null)
            {
                Console.WriteLine("Lista pusta");
            }
            return e;
        }
        public int SprawdzIleElementow
        {
            get { 
            var e = first;
            int i = 0;
            if (e == null)
            {
                return 0;
            }
            while (e != null)
            {
                e = e.next;
                i++;
            }
            return i;
            }

        }
        public T this[int i] { get => Get(i).value; set => Get(i).value = value; }

        
    }
    class Person
    {
        public int Id { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        static int _id = 101;

        public Person(string FirstName,string LastName,int Age)
        {
            this.Id = _id++;
            this.Firstname = FirstName;
            this.Lastname = LastName;
            this.Age = Age;
        }
        public override string ToString() => $"{Firstname} age: {Age} id: {Id}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> abc = new MyCollection<int>();
            abc.Add(0);
            abc.Add(1);
            abc.Add(2);
            abc.Add(3);
            abc.Add(4);
            abc.Add(5);
            abc.Add(6);
            Console.WriteLine("-----------------Pierwsza skecja bez użycia żadnych metod---------------");
            Console.WriteLine("Liczba Elementów wynosi: " + abc.SprawdzIleElementow);
            for(int i = 0; i<abc.SprawdzIleElementow;i++)
            {
                Console.WriteLine(abc[i]) ;
            }
            abc.Remove(4);
            Console.WriteLine("-----------------Test Remove---------------");
            Console.WriteLine("Liczba Elementów wynosi: " + abc.SprawdzIleElementow);
            for (int i = 0; i < abc.SprawdzIleElementow; i++)
            {
                Console.WriteLine(abc[i]);
            }
            Console.WriteLine("-----------------Test Instert---------------");
            MyCollection<int> abcd = new MyCollection<int>();
            abcd.Insert(0, 0);
            abcd.Insert(1, 1);
            abcd.Insert(2, 2);
            abcd.Insert(3, 3);
            Console.WriteLine("Liczba Elementów wynosi: " + abcd.SprawdzIleElementow);
            for (int i = 0; i < abcd.SprawdzIleElementow; i++)
            {
                Console.WriteLine(abcd[i]);
            }
            Console.WriteLine("-----------------Test RemoveAt_---------------");
            Console.WriteLine("Liczba Elementów wynosi: " + abc.SprawdzIleElementow);
            abc.RemoveAt_(0);
            for (int i = 0; i < abc.SprawdzIleElementow; i++)
            {
                Console.WriteLine(abc[i]);
            }
            Console.WriteLine("-----------------KOD TESTOWY PERSON---------------");
            var perlist = new MyCollection<Person>
            {
                new Person("Jan","Kowalski",13),
                new Person("Andrzej","Kowalski",13),
                new Person("Michał","Kowalski",20),
                new Person("Alicja","Kowalska",18),
                new Person("Julia","Guła",20),
                new Person("Matylda","Kowalksa",13),
            };
            foreach(var i in perlist)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("-----------------KOD TESTOWY PERSON linq(Osoby pełnoletnie)---------------");
            var listaOsobPelnoletnich = perlist.Where(e => e.Age >= 18).ToList();
            Console.WriteLine("Liczba osob pelnoletnich: " + listaOsobPelnoletnich.Count);
            foreach(var i in listaOsobPelnoletnich)
            {
                Console.WriteLine(i);
            }
        }

    }
}
