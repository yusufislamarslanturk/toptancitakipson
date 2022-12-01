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
    public partial class Ürün_Listele : Form
    {
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Stok_Takip;Integrated Security=True");
        
        

        private void ÜrünListele()
        {
            DataSet daset = new DataSet();
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from urun", baglanti);
            adptr.Fill(daset, "urun");
            dataGridView2.DataSource = daset.Tables["urun"];
            baglanti.Close();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BarkodNotxt.Text = dataGridView2.CurrentRow.Cells["barkodno"].Value.ToString();
            Kategoritxt.Text = dataGridView2.CurrentRow.Cells["kategori"].Value.ToString();
            Markatxt.Text = dataGridView2.CurrentRow.Cells["marka"].Value.ToString();
            ÜrünAdıtxt.Text = dataGridView2.CurrentRow.Cells["urunadi"].Value.ToString();
            Miktaritxt.Text = dataGridView2.CurrentRow.Cells["miktari"].Value.ToString();
            AlışFiyatıtxt.Text = dataGridView2.CurrentRow.Cells["alisfiyati"].Value.ToString();
            SatışFiyatıtxt.Text = dataGridView2.CurrentRow.Cells["satisfiyati"].Value.ToString();
            lblMiktarı.Text = dataGridView2.CurrentRow.Cells["miktari"].Value.ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urun set urunadi=@urunadi,miktari=@miktari,alisfiyati=@alisfiyati,satisfiyati@satisfiyati where barkodno=@barkodno",baglanti);
            komut.Parameters.AddWithValue("@barkodno",BarkodNotxt.Text);
            komut.Parameters.AddWithValue("@urunadi", ÜrünAdıtxt.Text);
            komut.Parameters.AddWithValue("@miktari", Miktaritxt.Text);
            komut.Parameters.AddWithValue("@alisfiyati", AlışFiyatıtxt.Text);
            komut.Parameters.AddWithValue("@satisfiyati", SatışFiyatıtxt.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme yapıldı.");
            foreach(Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BarkodNotxt.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update urun set kategori=@kategori,marka=@marka,where barkodno=@barkodno", baglanti);
                komut.Parameters.AddWithValue("@barkodno", BarkodNotxt.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@miktari", comboMarka.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme yapıldı.");
            }
            else
            {
                MessageBox.Show("Barkod no boş bırakılamaz.");
            }
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void Ürün_Listele_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
