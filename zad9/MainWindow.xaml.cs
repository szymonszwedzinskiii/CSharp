using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Web;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProgramowanieObiektoweWPF2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }
        //public List<Ocena> list2 { get; set; }

        public MainWindow()
        {
            
            list = new List<Student>() {  
                new Student() { Nazwisko="Kowalski",Imie="Jan",NrIndeksu=1023,Wydzial="WIMiI"},
                new Student() { Nazwisko = "Nowak", Imie = "Michał", NrIndeksu = 1013, Wydzial = "WIMiI" },
                new Student() { Nazwisko = "Magiera", Imie = "JAcek", NrIndeksu = 1033, Wydzial = "WIMiI" }
            };
            //list2 = new List<Ocena>()
            //{
            //    new Ocena(){Przedmiot="Programowanie Obiektowe",Wartosc=2.5}
            //};
            InitializeComponent();

            table.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new System.Windows.Data.Binding("Imie") });
            table.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new System.Windows.Data.Binding("Nazwisko") });
            table.Columns.Add(new DataGridTextColumn() { Header = "NRIndeksu", Binding = new System.Windows.Data.Binding("NrIndeksu") });
            table.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new System.Windows.Data.Binding("Wydzial") });
            table.AutoGenerateColumns = false;
            table.ItemsSource = list;
            
            




            //OcenaTable.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Przedmiot") });
            //OcenaTable.Columns.Add(new DataGridTextColumn() { Header = "Wartość",Binding=new Binding("Wartosc") });


        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {
                list.Add(dialog.student);
                table.Items.Refresh();
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if(table.SelectedItem is Student)
                list.Remove((Student)table.SelectedItem);

            table.Items.Refresh();
            
        }
        void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.FullName}]]");
            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(ob));

            }
            sw.WriteLine($"[[]]");
        }
        private void saveToFile_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new  FileStream("data.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

                foreach(Student s in list)
                {
                    sw.WriteLine("[[Student]]");
                    sw.WriteLine("[FirstName]");
                    sw.WriteLine(s.Imie);
                    sw.WriteLine("[Surname]");
                    sw.WriteLine(s.Nazwisko);
                    sw.WriteLine("[Numer Indeksu]");
                    sw.WriteLine(s.NrIndeksu);
                    sw.WriteLine("[Wydział]");
                    sw.WriteLine(s.Wydzial);
                    sw.WriteLine("[[]]");
                    sw.WriteLine();
                }
            

            System.Windows.MessageBox.Show("Data exported");
            sw.Close();

        }

        T Load<T>(StreamReader sr) where T :new()
        {
            T ob = default(T);
            Type tob = null;
            PropertyInfo property = null;

            while (!sr.EndOfStream)
            {
                var ln = sr.ReadLine();
                if (ln == "[[]]")
                    return ob;
                else if (ln.StartsWith("[["))
                {
                    tob = Type.GetType(ln.Trim('[', ']'));
                    if (typeof(T).IsAssignableFrom(tob))
                        ob = (T)Activator.CreateInstance(tob);
                }
                else if (ln.StartsWith("[") && ob != null)
                    property = tob.GetProperty(ln.Trim('[', ']'));
                else if (ob != null && property != null)
                    property.SetValue(ob, Convert.ChangeType(ln, property.PropertyType));
            }
            return default(T);
        }

        private void loadFromFile_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                FileStream fs = new FileStream("data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                list.Clear();
                while (!sr.EndOfStream)
                {
                    var ln = sr.ReadLine();
                    if(ln.Contains("[[Student]]"))
                    {
                        string name, surname, number, wydzial = null;
                        int numerin =0;
                        sr.ReadLine();
                        name = sr.ReadLine();
                        sr.ReadLine();
                        surname = sr.ReadLine();
                        sr.ReadLine();
                        number =sr.ReadLine();
                        sr.ReadLine();
                        wydzial = sr.ReadLine();
                        numerin = int.Parse(number);
                        list.Add(new Student(name, surname, numerin, wydzial));

                    }
                }
                System.Windows.MessageBox.Show($"SIEMA", "Info");
                //System.Windows.MessageBox.Show("Data imported");
                sr.Close();

                table.Items.Refresh();
            }

        }


        //private void DodajOcene_Click(object sender, RoutedEventArgs e)
        //{

        //    if (table.SelectedItem is Student)
        //    {
        //        var dialog = new OcenaWindow();
        //        if (dialog.ShowDialog() == true)
        //        {
        //            Student s = (Student)table.SelectedItem;
        //            s.oceny.Add(dialog.ocena);
        //            table.Items.Refresh();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Błąd! Wybierz studenta, któremu chcesz dodać ocenę!", "Błąd!");
        //    }
        //}


        //private void UsunOcene_Click(object sender, RoutedEventArgs e)
        //{
        //    if (table.SelectedItem is Ocena)
        //    {
        //        var dialog = new OcenaWindow();
        //        if(dialog.ShowDialog()==true)
        //        {
        //            Student s = (Student)table.SelectedItem;
        //            s.oceny.Remove(dialog.ocena);
        //            table.Items.Refresh();

        //        }
        //    }

        //    table.Items.Refresh();
        //}
    }
}
