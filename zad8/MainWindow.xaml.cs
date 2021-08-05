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

namespace ProgramowanieObiektoweWPF2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public List<Student> list { get; set; }
        public List<Ocena> list2 { get; set; }

        public MainWindow()
        {
            list = new List<Student>() {  
                new Student() { Nazwisko="Kowalski",Imie="Jan",NrIndeksu=1023,Wydzial="WIMiI"},
                new Student() { Nazwisko = "Nowak", Imie = "Michał", NrIndeksu = 1013, Wydzial = "WIMiI" },
                new Student() { Nazwisko = "Magiera", Imie = "JAcek", NrIndeksu = 1033, Wydzial = "WIMiI" }
            };
            list2 = new List<Ocena>()
            {
                new Ocena(){Przedmiot="Programowanie Obiektowe",Wartosc=2.5}
            };
            InitializeComponent();

            table.Columns.Add(new DataGridTextColumn() { Header = "Imię", Binding = new Binding("Imie") });
            table.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            table.Columns.Add(new DataGridTextColumn() { Header = "NRIndeksu", Binding = new Binding("NrIndeksu") });
            table.Columns.Add(new DataGridTextColumn() { Header = "Wydział", Binding = new Binding("Wydzial") });
            table.AutoGenerateColumns = false;
            table.ItemsSource = list;

            OcenaTable.Columns.Add(new DataGridTextColumn() { Header = "Przedmiot", Binding = new Binding("Przedmiot") });
            OcenaTable.Columns.Add(new DataGridTextColumn() { Header = "Wartość",Binding=new Binding("Wartosc") });


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

        private void DodajOcene_Click(object sender, RoutedEventArgs e)
        {
            
            if (table.SelectedItem is Student)
            {
                var dialog = new OcenaWindow();
                if (dialog.ShowDialog() == true)
                {
                    Student s = (Student)table.SelectedItem;
                    s.oceny.Add(dialog.ocena);
                    table.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Błąd! Wybierz studenta, któremu chcesz dodać ocenę!", "Błąd!");
            }
        }
        

        private void UsunOcene_Click(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem is Ocena)
            {
                var dialog = new OcenaWindow();
                if(dialog.ShowDialog()==true)
                {
                    Student s = (Student)table.SelectedItem;
                    s.oceny.Remove(dialog.ocena);
                    table.Items.Refresh();

                }
            }

            table.Items.Refresh();
        }
    }
}
