using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toptnacitakipson
{
    public partial class Kar_zarar : Form
    {
        public Kar_zarar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Stok_Takip;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Kar_zarar_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from karlar", baglanti);
            adptr.Fill(daset, "karlar");
            dataGridView1.DataSource = daset.Tables["karlar"];
            baglanti.Close();


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kar) from karlar", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader[0].ToString();

            }
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(alisfiyati)*sum(miktari) from karlar", baglanti);
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                label7.Text = reader2[0].ToString();

            }
            baglanti.Close();
            

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(satisfiyati)*sum(miktari) from karlar", baglanti);
            SqlDataReader reader3 = komut3.ExecuteReader();
            while (reader3.Read())
            {
                label5.Text = reader3[0].ToString();

            }
            baglanti.Close();
            reader3.Close();


        }
  
        
        private void karliste()
        {
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from karlar", baglanti);
            adptr.Fill(daset, "karlar");
            dataGridView1.DataSource = daset.Tables["karlar"];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
