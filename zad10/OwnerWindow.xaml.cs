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
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProgramowanieObiektoweWPF4_3
{
    /// <summary>
    /// Logika interakcji dla klasy OwnerWindow.xaml
    /// </summary>
    public partial class OwnerWindow : Window
    {
        protected string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\szymo\source\repos\ProgramowanieObiektoweWPF4-3\ProgramowanieObiektoweWPF4-3\Database1.mdf;Integrated Security=True";
        public void SqlOwnerInsert(Wlasciciel w)
        {
            using (var db = new SqlConnection(connectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [DBO].[Wlasciciel] ([Imie],[Nazwisko],[DataUrodzenia]) VALUES(@i,@n,@du)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@i", w.Imie);
                cmd.Parameters.AddWithValue("@n", w.Nazwisko);
                cmd.Parameters.AddWithValue("@du", w.DataUrodzenia);

                db.Open();
                var res = cmd.ExecuteNonQuery();
                db.Close();
            }
        }
        public Wlasciciel wl = new Wlasciciel();
        public OwnerWindow()
        {
            InitializeComponent();
        }


        private void AddOwnerW_Click(object sender, RoutedEventArgs e)
        {
            if(tbImie.Text != "" && tbNazwisko.Text !="" && tbDataUrodzenia != null )
            {
                wl.Imie = tbImie.Text;
                wl.Nazwisko = tbNazwisko.Text;
                wl.DataUrodzenia = Convert.ToDateTime(tbDataUrodzenia.Text);
                this.DialogResult = true;
                SqlOwnerInsert(wl);
            }
            else
            {
                MessageBox.Show("Błędne dane", "BŁĄD");
            }
            
        }
        
    }
}
