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

namespace programowanieObiektoweLab11
{
    /// <summary>
    /// Logika interakcji dla klasy InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public Invoice invoice;
        public static int i = 1;
        public int j = 0;
        public InvoiceWindow(Invoice invoice = null)
        {
            InitializeComponent();
            if(invoice != null)
            {
                tbDate.Text = invoice.Date.ToString();
                tbCustomer.Text = invoice.Customer;
                tbAdres1.Text = invoice.Adress;
                tbValue.Text = invoice.Value.ToString();
            }
            this.invoice = invoice ?? new Invoice();
        }

        private void SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            invoice.Date = Convert.ToDateTime(tbDate.Text);
            invoice.Adress = tbAdres1.Text;
            invoice.Customer = tbCustomer.Text;
            invoice.Value = float.Parse(tbValue.Text);
            if (invoice.Id == 0)
            {
                invoice.Id = i;
                i++;
            }
            this.DialogResult = true;

        }
    }
}
