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

namespace programowanieObiektoweWPF1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string dzialanie = null;
        private string temp = "0";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            string liczba = przycisk.Content.ToString();
            if (Ekran.Text == "0")
            {
                if (liczba != "0")
                {
                    Ekran.Text = liczba;
                }
                if(liczba == ",")
                {
                    Ekran.Text = "0";
                    Ekran.Text = Ekran.Text + liczba;
                }
            }
            else
            {
                Ekran.Text = Ekran.Text + liczba; // Jak nie zapomnce to dodam sprawdzenie, zeby max jeden przecinek był 
            }
        }

        private void Button_Function(object sender, RoutedEventArgs e)
        {
            Button przycisk = (Button)sender;
            dzialanie = przycisk.Content.ToString();
            temp = Ekran.Text;
            
            Ekran.Text = "0";
            Label.Content = temp + dzialanie;
            if (dzialanie == "C")
            {
                Ekran.Text = "0";
                temp = "0";
                Label.Content = " ";
                
            }
            //if (dzialanie == "CE") na razie mam problemy z tym przyciskiem
            //{
            //    Ekran.Text = "0";
            //    Label.Content = " ";

            //}
        }

        private void ButtonRownaSie_Click(object sender, RoutedEventArgs e)
        {
            string liczba = Ekran.Text;
            if (dzialanie == "+")
            {
                Ekran.Text = (Double.Parse(liczba) + Double.Parse(temp)).ToString();
                Label.Content = $"{temp} + {liczba}";
                
            }
            if (dzialanie == "-")
            {
                Ekran.Text = (Double.Parse(temp) - Double.Parse(liczba)).ToString();
                Label.Content = $"{temp} - {liczba}";
            }
            if(dzialanie == "*")
            {
                Ekran.Text = (Double.Parse(liczba) * Double.Parse(temp)).ToString();
                Label.Content = $"{temp} * {liczba}";
            }
            if (dzialanie == "/")
            {
                if (liczba != "0")
                {
                    Ekran.Text = (Double.Parse(temp) / Double.Parse(liczba)).ToString();
                    Label.Content = $"{temp} / {liczba}";
                }
                else
                {
                    MessageBox.Show("Nie można dzielić przez 0", "Błąd podczas podawania danych");
                }
            }
            if (dzialanie == "%")
            {
                Ekran.Text = (Double.Parse(temp) / Double.Parse(liczba)*100).ToString() +"%";
                Label.Content = $"{temp} % {liczba}";
            }

        }


    }
}
