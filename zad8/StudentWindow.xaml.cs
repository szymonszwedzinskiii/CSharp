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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ProgramowanieObiektoweWPF2
{
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public Student student;
        public StudentWindow( Student student = null)
        {
            
            InitializeComponent();
            if (student != null)
            {
                NameField.Text = student.Imie;
                NazwiskoField.Text = student.Nazwisko;
                NrIndeksuField.Text = student.NrIndeksu.ToString();
                WydzialField.Text = student.Wydzial;
            }
            this.student = student ?? new Student();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(NameField.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(NazwiskoField.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
                !Regex.IsMatch(NrIndeksuField.Text, @"^[0-9]{4,10}$"))
            {
                MessageBox.Show("Niepoprawne dane","Błąd");
                return;
            }
            student.Imie = NameField.Text;
            student.Nazwisko = NazwiskoField.Text;
            student.NrIndeksu = Int32.Parse(NrIndeksuField.Text);
            student.Wydzial = WydzialField.Text;
            this.DialogResult = true;

        }
    }
}
