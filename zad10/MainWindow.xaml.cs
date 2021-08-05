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
using System.Data.Sql;
using System.Data.SqlClient;
using static ProgramowanieObiektoweWPF4_3.MainWindow;
using System.Reflection;
using System.Data;

namespace ProgramowanieObiektoweWPF4_3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Samochod> cars { get; set; }
        public List<Wlasciciel> owners { get; set; }
        public static int tempSender = 0;

        protected string DBConnectionString = @"TU DODAJ SWOJ CONNECTION STRING KAZDY MA INNY W PDF W INSTRUKCJI JEST POKAZANE JAK TO ZROBIC";
        public List<Samochod> SqlCarSelect()
        {
            var list = new List<Samochod>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Id],[Brand],[Model],[ProdDate] FROM [dbo].[Car]";
                cmd.CommandType = CommandType.Text;
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Samochod() { Id = res.GetInt32(0), Marka = res.GetString(1), Model = res.GetString(2), RokProdukcji = res.GetInt32(3) });
                }
            }
            return list;
        }
        public List<Wlasciciel> SqlOwnerSelect()
        {
            var list = new List<Wlasciciel>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Id],[Name],[SurName],[CarID] FROM [dbo].[Owner]";
                cmd.CommandType = CommandType.Text;
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    list.Add(new Wlasciciel() { Id = res.GetInt32(0), Imie = res.GetString(1), Nazwisko = res.GetString(2), DataUrodzenia = res.GetDateTime(3) });
                }
            }
            return list;
        }

        public void SqlCarInsert(Samochod c)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Samochod]([Id],[Marka],[Model],[RokProdukcji],[Pojemnosc]) VALUES(@id,@ma,@mo,@Rk,@po)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(@"id", c.Id);
                cmd.Parameters.AddWithValue(@"b", c.Marka);
                cmd.Parameters.AddWithValue(@"m", c.Model);
                cmd.Parameters.AddWithValue(@"p", c.RokProdukcji);
                cmd.Parameters.AddWithValue(@"po", c.Poj);
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }
        public void SqlOwnerInsert(Wlasciciel o)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Wlasciciel]([Id],[Imie],[Nazwisko],[DataUrodzenia]) VALUES(@id,@n,@s,@c)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(@"id", o.Id);
                cmd.Parameters.AddWithValue(@"n", o.Imie);
                cmd.Parameters.AddWithValue(@"s", o.Nazwisko);
                cmd.Parameters.AddWithValue(@"c", o.DataUrodzenia);
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }

        public void SqlCarRemove(Samochod c)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Samochod] WHERE [Id]=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(@"id", c.Id);
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }
        public void SqlOwnerRemove(Samochod o)
        {
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM [dbo].[Wlasciciel] WHERE [Id]=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(@"id", o.Id);
                db.Open();
                var res = cmd.ExecuteNonQuery();
            }
        }


        [System.AttributeUsage(System.AttributeTargets.Class)]
        public class DBTabAttribute : System.Attribute
        {
            public String Name { get; set; }
        }

        [System.AttributeUsage(System.AttributeTargets.Property)]
        public class DBCollAttribute : System.Attribute
        {
            public String Title { get; set; }
            public String Name { get; set; }
            public String ForeignKey { get; set; }
        }


        public List<T> SqlSelect<T>() where T : new()
        {
            var list = new List<T>();
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return null;
            var prop = t.GetProperties().Where(p => p.GetCustomAttribute<DBCollAttribute>() != null).ToList();
            var names = prop.Select(p => $"[{p.GetCustomAttribute<DBCollAttribute>().Name ?? p.Name}]").ToList();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = $"SELECT {string.Join(",", names)} FROM [dbo[.[{t.Name}]";
                cmd.CommandType = CommandType.Text;
                db.Open();
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var ob = new T();
                    int i = 0;
                    prop.ForEach(p => p.SetValue(ob, res[i++]));
                    list.Add(ob);
                }
            }
            return list;
        }


        public void SetGrid<T>(List<T> list)
        {
            Type t = typeof(T);
            if (t.GetCustomAttribute<DBTabAttribute>() == null)
                return;
            foreach (var p in t.GetProperties())
            {
                var coll = p.GetCustomAttribute<DBCollAttribute>();
                if (coll != null)
                    OwnerGrid.Columns.Add(new DataGridTextColumn() { Header = coll.Title ?? p.Name, Binding = new Binding(p.Name) });
            }
            OwnerGrid.AutoGenerateColumns = false;
            OwnerGrid.ItemsSource = list;
        }


        public MainWindow()
        {
            InitializeComponent();
            OwnerGrid.Columns.Add(new DataGridTextColumn() { Header = "Id", Binding = new Binding("Id") });
            OwnerGrid.Columns.Add(new DataGridTextColumn() { Header = "Marka", Binding = new Binding("Marka") });
            OwnerGrid.Columns.Add(new DataGridTextColumn() { Header = "Model", Binding = new Binding("Model") });
            OwnerGrid.Columns.Add(new DataGridTextColumn() { Header = "Data Produkcji", Binding = new Binding("DataProdukcji") });

            CarGrid.Columns.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("Id") });
            CarGrid.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("Imie") });
            CarGrid.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            CarGrid.Columns.Add(new DataGridTextColumn() { Header = "Data Urodzenia", Binding = new Binding("DataUrodzenia") });

            OwnerGrid.AutoGenerateColumns = false;
            CarGrid.AutoGenerateColumns = false;
            OwnerGrid.ItemsSource = SqlCarSelect();
            CarGrid.ItemsSource = SqlOwnerSelect();
            OwnerGrid.Items.Refresh();
            CarGrid.Items.Refresh();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CarWindow();
            if (dialog.ShowDialog() == true)
            {
                SqlCarInsert(dialog.sam);
                OwnerGrid.ItemsSource = SqlCarSelect();
                OwnerGrid.Items.Refresh();
            }
        }

        private void RemoveCar_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerWindow.SelectedItem is Samochod)
            {
                SqlCarRemove((Samochod)OwnerGrid.SelectedItem);
                CarGrid.ItemsSource = SqlOwnerSelect();
                CarGrid.Items.Refresh();
                CarGrid.ItemsSource = SqlCarSelect();
                CarGrid.Items.Refresh();
            }
        }

        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            if (OwnerGrid.SelectedItem is Samochod)
            {
                Samochod car = (Samochod)OwnerGrid.SelectedItem;
                tempSender = car.Id;
                var dialog = new OwnerWindow();
                if (dialog.ShowDialog() == true)
                {
                    SqlOwnerInsert(dialog.owner);
                    CarGrid.ItemsSource = SqlOwnerSelect();
                    CarGrid.Items.Refresh();
                }
            }
        }

        private void RemoveOwner_Click(object sender, RoutedEventArgs e)
        {
            if (CarGrid.SelectedItem is Wlasciciel)
            {
                SqlOwnerRemove((Wlasciciel)CarGrid.SelectedItem);
                CarGrid.ItemsSource = SqlOwnerSelect();
                CarGrid.Items.Refresh();
                CarGrid.ItemsSource = SqlCarSelect();
                CarGrid.Items.Refresh();
            }
        }

        private void SqlOwnerRemove(Wlasciciel selectedItem)
        {
            throw new NotImplementedException();
        }


    }
}
