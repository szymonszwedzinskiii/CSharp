using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ProgramowanieObiektoweWPF4_3
{
    public class Samochod
    {
        int id = 0;
        public int Id { get { return id; } set { id = value; } }
        private string marka;
        public string Marka
        {
            set {marka=value; }
            get { return marka; }
        }
        private string model;
        public string Model
        {
            set { model = value; }
            get { return model; }
        }
        private int rokProdukcji;
        public int RokProdukcji
        {
            set { rokProdukcji = value; }
            get { return rokProdukcji; }
        }
        private float poj;
        public float Poj
        {
            set { poj = value; }
            get { return poj; }
        }
        protected string DBConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\szymo\source\repos\ProgramowanieObiektoweWPF4-3\ProgramowanieObiektoweWPF4-3\Database1.mdf;Integrated Security=True";
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
                    list.Add(new Samochod() { id = res.GetInt32(0), Marka = res.GetString(1), Model = res.GetString(2),RokProdukcji = Convert.ToInt32(res.GetString(3)) });
                }
            }
            return list;
        }
        public Samochod() { }
        public Samochod(int idd, string brandd, string modell, int data)
        {
            id = idd; marka = brandd; model = modell; rokProdukcji = data;
        }
        public Samochod(string brandd, string modell, int data)
        {
            marka = brandd; model = modell; rokProdukcji = data;
            int counter = 0;
            id = SqlCarSelect().Count + 1;

            foreach (Samochod item in SqlCarSelect())
            {
                id = SqlCarSelect().ElementAt(counter).Id + 1;
                counter++;
            }

        }
    }
}
