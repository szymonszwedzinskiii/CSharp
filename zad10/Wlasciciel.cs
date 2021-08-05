using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweWPF4_3
{
    public class Wlasciciel
    {
        int id = 0;
        static int staticid = 0;
        public int Id { get { return id; } set { id = value; } }
        string imie;
        public string Imie
        {
            set { imie = value; }
            get { return imie; }
        }
        string nazwisko;
        public string Nazwisko
        {
            set { nazwisko = value; }
            get { return nazwisko; }
        }

        DateTime dataUrodzenia;
        public DateTime DataUrodzenia
        {
            set { dataUrodzenia = value; }
            get { return dataUrodzenia; }
        }
        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\szymo\source\repos\ProgramowanieObiektoweWPF4-3\ProgramowanieObiektoweWPF4-3\Database1.mdf;Integrated Security=True";

        public List<Wlasciciel> SqlOwnerSelect()
        {
            var list = new List<Wlasciciel>();
            using (var db = new SqlConnection(DBConnectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT [Id],[Imie],[Nazwisko],[DataUrodzenia] FROM [dbo].[Wlasciciel]";
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


        public Wlasciciel() { }
        public Wlasciciel(int idd, string namee, string surnamee, DateTime data)
        {
            id = idd; Imie = namee; Nazwisko = surnamee; DataUrodzenia = data;
        }
        public Wlasciciel(string namee, string surnamee, DateTime data)
        {
            Imie = namee; Nazwisko = surnamee; DataUrodzenia = data;
            staticid++;
            id = staticid;
        }
        public Wlasciciel(string namee, string surnamee)
        {
            Imie = namee; Nazwisko = surnamee;

            int counter = 0;
            id = SqlOwnerSelect().Count + 1;

            foreach (Wlasciciel item in SqlOwnerSelect())
            {
                id = SqlOwnerSelect().ElementAt(counter).Id + 1;
                counter++;
            }

        }
    }
}
