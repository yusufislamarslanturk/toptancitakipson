using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace toptnacitakipson
{
    public partial class SatışListele : Form
    {
        public SatışListele()
        {
            
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Stok_Takip;Integrated Security=True");
        DataSet daset = new DataSet();

        private void satisliste()
        {
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from satis", baglanti);
            adptr.Fill(daset, "satis");
            dataGridView1.DataSource = daset.Tables["satis"];
            baglanti.Close();
        }
        private void SatışListele_Load(object sender, EventArgs e)
        {
            satisliste();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(toplamfiyati) from satis",baglanti);
            SqlDataReader reader = komut2.ExecuteReader();
            while(reader.Read())
            {
                label3.Text = reader[0].ToString();

            }
            baglanti.Close();
            reader.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
