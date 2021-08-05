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
    /// Logika interakcji dla klasy OcenaWindow.xaml
    /// </summary>
    /// 
    public partial class OcenaWindow : Window
    {
        public Ocena ocena;
        public OcenaWindow(Ocena ocena =null)
        {
            InitializeComponent();
            if (ocena != null)
            {
                PrzedmiotField.Text = ocena.Przedmiot;
                WartoscField.Text = ocena.Wartosc.ToString(); 
            }
            this.ocena = ocena ?? new Ocena();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!Regex.IsMatch(PrzedmiotField.Text, @"^\p{Lu}\p{Ll}{1,12}$") ||
            !Regex.IsMatch(WartoscField.Text, @"^[0.0-9]{1,10}$"))
            {
                MessageBox.Show("Niepoprawne dane", "Błąd");
                return;
            }
           ocena.Przedmiot = PrzedmiotField.Text;
           ocena.Wartosc = Double.Parse(WartoscField.Text);
           this.DialogResult = true;
        }
        
    }
}
