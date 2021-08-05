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

namespace ProgramowanieObiektoweWPF4_3
{
    /// <summary>
    /// Logika interakcji dla klasy CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public Samochod sam;
        public CarWindow(Samochod sam = null)
        {

            InitializeComponent();
            if(sam!=null)
            {
                tbMarka.Text = sam.Marka;
                tbModel.Text = sam.Model;
                sam.RokProdukcji= Convert.ToInt32(tbRokProdukcji);
                sam.Poj = float.Parse(tbPojemnosc.Text);
            }
            this.sam = sam ?? new Samochod("","",0);
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            if (tbMarka.Text != "" && tbModel.Text != "" && tbPojemnosc != null && tbRokProdukcji != null)
            {
                sam.Marka = tbMarka.Text;
                sam.Model = tbModel.Text;
                sam.RokProdukcji = Convert.ToInt32(tbRokProdukcji.Text);
                sam.Poj = float.Parse(tbPojemnosc.Text);
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Proszę podać dane!", "Błąd");
            }
        }
    }
}
